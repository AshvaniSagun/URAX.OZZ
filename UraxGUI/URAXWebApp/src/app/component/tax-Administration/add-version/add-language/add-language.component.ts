import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { addLanguageService } from '../../../../service/TaxAdministration/add-version/add-language/add-language.service'
import { languagemodel, LanguageDropdown } from '../../../../model/tax-administration/add-version/add-lang/language.model';
import { shareddataservice, Errorlist } from '../../../../service/shared/shared.service'
declare var JQuery: any;
declare var $: any;
@Component({
  selector: 'urax-add-language',
  templateUrl: './add-language.component.html',
  styleUrls: ['./add-language.component.css'],
  providers: [addLanguageService]
})
export class AddLanguageComponent implements OnInit {
    private subscription: Subscription;
    public taxid: any;
    public isadd: boolean;
    public errorlist: Errorlist[]
    public active: string
    public langsetvalue: string
    public errorlistnew: Errorlist
    public count: number
    public LanguageId: string
    public cleardata() {
        try {
            this.languagemodellist = []
        } catch (e) {

        }
    }
    constructor(public _languageservice: addLanguageService, public _shareddataservice: shareddataservice)
    {
        this.subscription = this._shareddataservice.languageEvent.subscribe((newValue: any) => {
            this.taxid = newValue;
            this.languagemodellist=[]
            this.getlanguagedetail(this.taxid)
        })
        this.subscription = this._shareddataservice.TaxmarketCleardataEvent.subscribe((newValue: any) => {
            this.cleardata();
        })
        this.subscription = this._shareddataservice.Cleardata.subscribe((newValue: any) => {
            this.taxid = newValue;
            this.languagemodellist = []
        })
        this.subscription = this._shareddataservice.TaxmarketidEvent.subscribe((newValue: any) => {
            this.cleardata();

        })
    }

    public languagemodellist: languagemodel[];
    public language: languagemodel;

    public LanguageDropdown: LanguageDropdown[];
    public Errorlist: string[]
  
    ngOnInit() {
        this.isadd = true;
       // this.getlanguagedetail();
        this.GetLanguageDropdown();
        this.errorlist = []
        this.active = ''
        $('.pane-lang-hScroll').scroll(function () {
            $('.pane-lang-vScroll').width($('.pane-lang-hScroll').width() + $('.pane-lang-hScroll').scrollLeft());
        });

    }

    private getlanguagedetail(taxid:any) {
        this._languageservice.getlanguagedetail(taxid).subscribe(
            language => { this.languagemodellist = language },
            Error => {
                this.languagemodellist=[]
            }
        );
    }
    public GetLanguageDropdown() {
        this._languageservice.GetLangugeDropdown().subscribe(
            isLookUp => this.LanguageDropdown = isLookUp
        );
    }

    public validation(m: languagemodel, listm: languagemodel[], languageId: any, languageName: any, isupdate: boolean) {
        var validate = true;
        this.count = 0
        this.errorlist = [];
        if (typeof this.taxid === 'undefined' || this.taxid === '' || this.taxid === '0') {
            var errorlist = new Errorlist('', "Please select the Tax.");
            this.errorlist.push(errorlist);
            validate = false
        }
        if (typeof m.languageId === 'undefined' || m.languageId === '' ||  m.languageId ==='0') {
            var errorlist = new Errorlist('',"Please select the Language.");
            this.errorlist.push(errorlist);
            validate = false
        }
        if (typeof m.taxName === 'undefined' || m.taxName.trim() === '' || typeof m.taxName.replace(/^\s+|\s+$/g, "") === null || m.taxName.replace(/^\s+|\s+$/g, "") === '') {
            var errorlist = new Errorlist('',"Please provide the Tax Name.");
            this.errorlist.push(errorlist);
            validate = false
        }
        if (this.active == '0' || typeof m.isActive === 'undefined') {
            var errorlist = new Errorlist('',"Please select Default.");
            this.errorlist.push(errorlist);
            validate = false
        }
        //if (this.active == '1') {
        //    var count = 0;
        //    var id = 0
        //   // if (listm.length > 1) {
        //        if (isupdate) {

        //            for (var i = 0; i < listm.length; i++) {
        //                if (listm[i].isActive == true) {
        //                    count += 1
        //                    id = i
        //                }
        //            }
        //            if (count >= 1) {
        //                var errorlist = new Errorlist('', "Only one Language can be set default to 'YES'");
        //                this.errorlist.push(errorlist);
        //                validate = false

        //            }

        //        }
        //        else {
        //            for (var i = 0; i < listm.length; i++) {
        //                if (listm[i].isActive == true && listm[i].languageDetailid != '') {
        //                    count += 1
        //                    id = i

        //                }
        //            }
        //            if (count >= 1) {
        //                var errorlist = new Errorlist('', "Only one Language can be set default to 'YES'");
        //                this.errorlist.push(errorlist);
        //                validate = false

        //            }

        //        }
        //   // }
          
        //}
        if (this.LanguageId != '0' ) {
            try {
                var count = 0;
                var id = 0
                if (isupdate) {
                    for (var i = 0; i < listm.length; i++) {
                        if (listm[i].languageId.toString() === this.LanguageId && listm[i].languageDetailid != '')
                        {
                            count += 1
                            id = i
                        }
                    }
                    if (count >= 2) {
                        var errorlist = new Errorlist('', listm[id].languageName + "Language already exists.");
                        this.errorlist.push(errorlist);
                        validate = false

                    }
               
                }
                else {
                    for (var i = 0; i < listm.length; i++) {
                        if (listm[i].languageId.toString() === this.LanguageId && listm[i].languageDetailid != '') {
                            count += 1
                            id = i

                        }
                    }
                    if (count >= 1) {
                        var errorlist = new Errorlist('', listm[id].languageName + "Language already exists.");
                        this.errorlist.push(errorlist);
                        validate = false

                    }

                    }
                


            } catch (e) {

            }

        }
       
        
        if (!validate) {
            this._shareddataservice.Error(this.errorlist)

        }
        return validate;
    }
    SaveLanguage(model: languagemodel, listm: languagemodel[]) {

        if (this.validation(model, listm, model.languageId, model.languageName, false)) {

            this._shareddataservice.loadingstart("true");
            this._languageservice.SaveLanguage(model, this.taxid)
                .subscribe(response => {
                    this.errorlist = []
                    this.errorlist = response;
                    this._shareddataservice.loadingstart("true")
                    for (var i = 0; i < this.errorlist.length; i++) {
                        if (this.errorlist[i].errormsg.toString().trim() != '') {
                            var erlist = new Errorlist("", this.errorlist[i].successmsg.toString())
                            this.errorlist.push(erlist);
                            this._shareddataservice.Error(this.errorlist);
                            this._shareddataservice.loadingend(true)

                        }
                        else if (this.errorlist[i].successmsg.toString().trim() != '') {
                            this.isadd = true;
                            this.getlanguagedetail(this.taxid)
                            this._shareddataservice.Sucess("Language details are saved successfully.")
                            // alert("language added sussesfully.");
                            this._shareddataservice.loadingend(true)
                        }
                        break;
                    }
                },
                Error => {
                    this.isadd = true;
                    this._shareddataservice.loadingend(false)
                }
                );
                
            //this.getlanguagedetail();
        }
    }

    public UpdateLanguage(model: languagemodel, listm: languagemodel[]) {
        if (this.validation(model, listm, model.languageId, model.languageName, true)){
        this._shareddataservice.loadingstart("true");
        this._languageservice.UpdateLanguage(model, this.taxid)
            .subscribe(response => {
                this.errorlist = []
                this.errorlist = response;
                this._shareddataservice.loadingstart("true")
                for (var i = 0; i < this.errorlist.length; i++) {
                    if (this.errorlist[i].errormsg.toString().trim() != '') {
                        var erlist = new Errorlist("", this.errorlist[i].successmsg.toString())
                        this.errorlist.push(erlist);
                        this._shareddataservice.Error(this.errorlist);
                        this._shareddataservice.loadingend(true)

                    }
                    else if (this.errorlist[i].successmsg.toString().trim() != '') {
                        this.isadd = true;
                        this.getlanguagedetail(this.taxid)
                        this._shareddataservice.Sucess("Language details are updated successfully.")
                        // alert("language added sussesfully.");
                        this._shareddataservice.loadingend(true)
                    }
                    break;
                }
            },
            Error => {
                this.isadd = true;
                this._shareddataservice.loadingend(false)
            }
            );

        }

    }
    // Delete
   public deletelanguage(item: languagemodel) {
        this.language = item;
        var IsConf = confirm('You are about to delete ' + this.language.languageName + '. Are you sure?');
        if (IsConf) {
            this._shareddataservice.loadingstart("true");
            this._languageservice.DeleteLanguage(this.language.languageDetailid)
                .subscribe(
                resp => {
                    this.getlanguagedetail(this.taxid)
                    this._shareddataservice.Sucess("Language details are deleted successfully.")
                    this._shareddataservice.loadingend(true);

                },

                error => {
                    this.getlanguagedetail(this.taxid)
                    this._shareddataservice.loadingend(false);

                }
                );
        }
    }

   private addNew(list: languagemodel) {
       $('.pane-lang-vScroll').animate({
           scrollTop: '-=2000'
       }, 300);
       if (this.isadd) {
           this.isadd = false;
           var Objlanguagemodel = new languagemodel();
           if (typeof this.languagemodellist == 'undefined') {
               this.languagemodellist = [];
               this.languagemodellist.unshift(Objlanguagemodel);
               Objlanguagemodel.languageId = '0';
               Objlanguagemodel.isActive = false;
               Objlanguagemodel.showEdit = true;
               Objlanguagemodel.showupdate = false;
               Objlanguagemodel.cancel = true;
               Objlanguagemodel.isadd = true;
               Objlanguagemodel.showsave = true;
           }
           else {
               this.languagemodellist.unshift(Objlanguagemodel);
               Objlanguagemodel.languageId = '0';
               Objlanguagemodel.isActive = false;
               Objlanguagemodel.showEdit = true;
               Objlanguagemodel.showupdate = false;
               Objlanguagemodel.cancel = true;
               Objlanguagemodel.isadd = true;
               Objlanguagemodel.showsave = true;

           }

       }
       

    };
   public Checkactive(m: any) {
        if (m=='0') {
            this.active = '0';
        }
        if (m == 'true') {
            this.active='1'
        }
        if (m == 'false') {
            this.active = '2'
        }



    }
    public langugagechange(m: any) {
        try {
            
                this.LanguageId = m;
             

        } catch (e) {

        }
    }

  
    editVariable(m: languagemodel) {
        this.LanguageId = m.languageId
        if (this.isadd) {
            this.isadd = false;
            m.showupdate = true;
            m.cancel = true;
            m.showEdit = m.showEdit ? false : true;
            this.isadd = false;
        }

   


    }
    cancel(m: languagemodel) {
        if (m.isadd) {
            this.languagemodellist.shift();
            this.isadd = true;
            this.getlanguagedetail(this.taxid)
        }
        else {
            this.getlanguagedetail(this.taxid)
            m.showEdit = false;
            m.cancel = false;
            this.isadd = true;
            m.showupdate = false;

        }

    }


}
