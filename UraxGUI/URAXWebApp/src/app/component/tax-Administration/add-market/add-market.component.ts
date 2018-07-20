import { Component, OnInit, Provider } from '@angular/core';
import { Subscription } from 'rxjs';
import { addMarketService } from '../../../service/TaxAdministration/add-market/addmarket.service'
import { marketcodedropdown, marketcurencydropdown, marketmodel, subdivisionCode } from '../../../model/tax-administration/add-market/market.model'
import { shareddataservice, Errorlist } from '../../../service/shared/shared.service'
declare var JQuery: any;
declare var $: any;
@Component({
    selector: 'urax-add-market',
    templateUrl: './add-market.component.html',
    styleUrls: ['./add-market.component.css'],
    providers: [addMarketService]
})
export class AddMarketComponent implements OnInit {
    public errorlist: Errorlist[]
    private subscription: Subscription;

    constructor(public _marketservice: addMarketService, public _shareddataservice: shareddataservice) {
        this.subscription = this._shareddataservice.cleardataeventmarket.subscribe((newValue: any) => {
            this.cleardata();
        })
    }
    public cleardata() {
        try {
            this.getmarketcode();
            this.getmarketcurrency();
            this.getmarketdetail();
            this.isadd = true;
        } catch (e) {

        }
    }
    public marketcodelist: marketcodedropdown[];
    public marketcurrencylist: marketcurencydropdown[];
    public marketmodellist: marketmodel[];
    public subdivisionCodeList: subdivisionCode[];
    public Tempdivison: subdivisionCode[];

    public countryid = ''
    public variableId=''
    public active = ''
    public isadd: boolean;

    ngOnInit() {
        this.getmarketcode();
        this.getmarketcurrency();
        this.getmarketdetail();
        this.isadd = true;
        $('.pane-hScroll').scroll(function () {
            $('.pane-vScroll').width($('.pane-hScroll').width() + $('.pane-hScroll').scrollLeft());
        });
       
    }

    private shorting() {
       
    }
    //Get All 
    private getmarketcode() {
        this._marketservice.getmarketcode().subscribe(
            market => this.marketcodelist = market
        );
    }
    private getmarketcurrency() {
        this._marketservice.getmarketcurrency().subscribe(
            market => this.marketcurrencylist = market
        );
    }


    private getSubdivision(cid:any) {
        this._marketservice.getsubdivisioncode(cid).subscribe(
            subdevision => {
                this.subdivisionCodeList = subdevision
                
            }
            , Error => {

            }
            
        );
    }



    private getmarketdetail() {
        this._marketservice.getmarketdetails().subscribe(
            market => this.marketmodellist = market
        );
    }
    public validation(m: marketmodel, listm: marketmodel[], isupdate: boolean, countryName: any) {
        var validate = true;
        this.errorlist = [];
        if (typeof m.countryCode === 'undefined' || this.countryid == '' || typeof m.countryCode == null || this.countryid == '0') {
            var errorlist = new Errorlist("", "Please select the Country Name or Country code.");
            this.errorlist.push(errorlist);
            validate = false
        }

        if (m.taxTerritory == 'undefined' || m.taxTerritory== '' || m.taxTerritory == null) {
            var errorlist = new Errorlist('', "Please provide the Tax Territory.");
            this.errorlist.push(errorlist);
            validate = false
        }
        //if (m.submarketCode == 'undefined' || m.submarketCode == '' || m.submarketCode == null) {
        //    var errorlist = new Errorlist('', "Please provide the GCC Tax Partner Group.");
        //    this.errorlist.push(errorlist);
        //    validate = false
        //}
        if (m.currencyId == 'undefined' || m.currencyId == '' || m.currencyId == null || m.currencyId == '0') {
            var errorlist = new Errorlist("", "Please select the Currency.");
            this.errorlist.push(errorlist);
            validate = false
        }     
        if (typeof m.isActive == 'undefined' || typeof m.isActive == null || this.active == '0') {
            var errorlist = new Errorlist("", "Please select Active.");
            this.errorlist.push(errorlist);
            validate = false
        }
        //if (true && listm.length > 1 && this.countryid !== 'undefined' && this.countryid != '') {
        //    listm = listm.filter(listm => listm.countryCodeId === countryName && listm.marketId !== '')

        //    if (isupdate) {
        //        if (listm.length > 1) {
        //            var errorlist = new Errorlist('', "Selected Country already exists.");
        //            this.errorlist.push(errorlist);
        //            validate = false
        //        }

        //    }
        //    else {
        //        if (listm.length > 0) {
        //            var errorlist = new Errorlist('', "Selected Country already exists.");
        //            this.errorlist.push(errorlist);
        //            validate = false
        //        }

        //    }


        //}
        if (!validate) {
            this._shareddataservice.Error(this.errorlist)
        }
        return validate;
    }
    public SaveCountryData(model: marketmodel) {
        if (model.subdivisionCode == "0") {
            model.subdivisionCode = ''
        }
        if (this.validation(model, this.marketmodellist, false, this.countryid)) {
            this._shareddataservice.loadingstart("true")
            model.taxTerritory = model.taxTerritory.trim()
            this._marketservice.SaveCountryData(model, this.countryid)
                .subscribe(
                marketres => {
                    this.errorlist = marketres;
                    for (var i = 0; i < this.errorlist.length; i++) {
                        if (this.errorlist[i].errormsg.toString().trim() != '') {
                            var erlist = new Errorlist("", this.errorlist[i].successmsg.toString())
                            this.errorlist.push(erlist);
                            this._shareddataservice.Error(this.errorlist);
                            this._shareddataservice.loadingend(true)

                        }
                        else if (this.errorlist[i].successmsg.toString().trim() != '') {
                            this.isadd = true;
                            this.getmarketdetail();
                            this.loadmarketdetails()
                            this._shareddataservice.Sucess("Country details are saved successfully.")
                            this._shareddataservice.loadingend(true)
                            // this._shareddataservice.Addnemarkettax(this.marketId)

                        }
                        break;
                    }

                },
                Error => {
                    //this._shareddataservice.Error(Error);
                    this.isadd = true;
                    this.getmarketdetail();
                    this._shareddataservice.loadingstart("true")
                    this._shareddataservice.loadingend(false)
                }
                );
        }
    }
    public UpdateCountryData(model: marketmodel) {
        if (model.subdivisionCode == "0") {
            model.subdivisionCode=''
        }
        if (this.validation(model, this.marketmodellist, true, this.countryid)) {
            this._shareddataservice.loadingstart("true")
            this._marketservice.UpdateCountryData(model, this.countryid)
                .subscribe(
                marketres => {
                    this.errorlist = []
                    this.errorlist = marketres;
                    for (var i = 0; i < this.errorlist.length; i++) {
                        if (this.errorlist[i].errormsg.toString().trim() != '') {
                            var erlist = new Errorlist("", this.errorlist[i].successmsg.toString())
                            this.errorlist.push(erlist);
                            this._shareddataservice.Error(this.errorlist);
                            this._shareddataservice.loadingend(true)

                        }
                        else if (this.errorlist[i].successmsg.toString().trim() != '') {
                            this.isadd = true;
                            this.getmarketdetail();
                            this.loadmarketdetails()
                            this._shareddataservice.Sucess("Country details are updated successfully.")
                            this._shareddataservice.loadingend(true)
                            // this._shareddataservice.Addnemarkettax(this.marketId)

                        }
                        break;
                    }

                },
                Error => {
                    //this._shareddataservice.Error(Error);
                    this.isadd = true;
                    this.getmarketdetail();
                    this._shareddataservice.loadingstart("true")
                    this._shareddataservice.loadingend(false)
                }
                );
        }

    }
    public onChangemarket(selectedobject: any, model: marketmodel) {

        try {
            this.countryid = selectedobject
            this.getSubdivision(model.countryCodeId);
            model.subdivisionCode="0"
         //   this.subdivisionCodeList = this.subdivisionCodeList.filter(sub => sub.variableId == selectedobject);

        } catch (e) {

        }

    }


    public onChangesubmarketcode(selectedobject: any, model: marketmodel) {

        try {
           
        } catch (e) {

        }

    }
    public featurset(selectedobject: any, model: marketmodel) {

        try {
            model.featureLevelTax = selectedobject
        } catch (e) {

        }

    }
    public onChangecountrycode(selectedobject: any, model: marketmodel) {

        try {
            this.countryid = selectedobject
            this.getSubdivision(model.countryCodeId);
            model.subdivisionCode = "0"
        } catch (e) {

        }

    }

    public isactive(selectedobject: any) {
        try {
            this.active = selectedobject;
        } catch (e) {

        }

    }
    public deletemarket(item: marketmodel) {
        var IsConf = confirm('You are about to delete ' + item.countryName + '. Are you sure?');
        if (IsConf) {
            this._shareddataservice.loadingstart("true")
            this.marketmodellist = this.marketmodellist.filter(obj => obj !== item);
            this._marketservice.deletemarket(item.marketId)
                .subscribe(resp => {
                    this.marketmodellist = resp
                    this.getmarketdetail();
                    this.loadmarketdetails()
                    this._shareddataservice.Sucess(item.countryName + ' is deleted successfully.');
                    this._shareddataservice.loadingend(true)

                }, error => {
                    this._shareddataservice.loadingend(false)
                    this.getmarketdetail();
                    this._shareddataservice.Error(error)
                }
                );
        }
    }

    private addNew() {
        $('.pane-vScroll').animate({
            scrollTop: '-=2000'
        }, 100);
        if (this.isadd) {
            this.countryid = ''
            this.isadd = false;
            var objmarketmodel = new marketmodel();
            if (typeof this.marketmodellist == 'undefined') {
                this.marketmodellist = [];
                this.marketmodellist.unshift(objmarketmodel);
                objmarketmodel.marketId = "";
                objmarketmodel.submarketCode = "";
                objmarketmodel.countryCode = "";
                objmarketmodel.currencyCode = "";
                objmarketmodel.taxTerritory = "";
                objmarketmodel.showEdit = true;
                objmarketmodel.showupdate = false;
                objmarketmodel.cancel = true;
                objmarketmodel.isadd = true;
                objmarketmodel.showsave = true;
                objmarketmodel.featureLevelTax = false;
                objmarketmodel.variableName = "0"
            }
            else {
                this.marketmodellist.unshift(objmarketmodel);
                objmarketmodel.marketId = "";
                objmarketmodel.submarketCode = "";
                objmarketmodel.countryCode = "";
                objmarketmodel.currencyCode = "";
                objmarketmodel.showEdit = true;
                objmarketmodel.showupdate = false;
                objmarketmodel.cancel = true;
                objmarketmodel.isadd = true;
                objmarketmodel.showsave = true;
                objmarketmodel.featureLevelTax = false;
                objmarketmodel.variableName = "0"


            }
        }

    };
    editmarket(m: marketmodel) {
        if (this.isadd) {
            this.getSubdivision(m.countryCodeId);
            m.subdivisionCode = m.subdivisionCode
            this.countryid = "1"
            m.showupdate = true;
            m.cancel = true;
            this.isadd = false;
            m.showEdit = m.showEdit ? false : true;
        }

    }
    cancel(m: marketmodel) {
        this.isadd = true;
        if (m.isadd) {
            this.marketmodellist.shift();
        }
        else {
            m.showEdit = false;
            m.cancel = false;
            m.showupdate = false;

        }
        this.getmarketdetail();
    }
    public loadmarketdetails() {
        try {
            this._shareddataservice.marketlistadded("load");
        } catch (e) {

        }

    }
    public Trackbymarketid(index: number): number {
        return index
    }

}
