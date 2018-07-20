import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms'
import { addFormulaService } from '../../../../service/TaxAdministration/add-version/add-formula/add-formula.service';
import { Addnewversionservice } from '../../../../service/TaxAdministration/add-version/new-version/new-version.service';
import { StartPageAdminService } from '../../../../service/StartPageAdmin/start-page-admin.service';
import { StartPageAdmin, ContentType } from '../../../../model/StartPageAdmin/start-page-admin';
import { Observable } from 'rxjs/Observable';
import { Subscription } from 'rxjs';
import { Variable, } from '../../../../model/tax-administration/add-version/add-formula/formula.model';
import { SwapingorderDD } from '../../../../model/tax-administration/add-version/new-version/NewVersion.model';

import { shareddataservice, Errorlist } from '../../../../service/shared/shared.service'
declare var JQuery: any;
declare var $: any;
@Component({
    selector: 'urax-main',
    templateUrl: './main.component.html',
    styleUrls: ['./main.component.css'],
    providers: [StartPageAdminService, addFormulaService, Addnewversionservice]
})
export class MainComponent implements OnInit {
    private subscription: Subscription;
    message: string;
    public Resulttest: string
    public errormsg: Errorlist[];
    public errorlist: Errorlist[];
    public _testvariabllist: Variable[]
    public _testvariabllistdata: Variable[]
    public _swapdd: SwapingorderDD[]
    public Formuladefination: string
    public swapid: string;
    public newswapid: string;
    public newtaxmasterid: number
    public oldtaxmasterid: string
    public SwaptaxMasterId:string


    constructor(public _StartpageAdminservice: StartPageAdminService, public _shareddataservice: shareddataservice, public _addformulaservice: addFormulaService, public _addnewversionservice: Addnewversionservice) {
        this.subscription = this._shareddataservice.newscontentevent.subscribe((newValue: any) => {

            this.Gethomenews();

        })
        this.subscription = this._shareddataservice.previewpopupEvent.subscribe((newValue: any) => {
            try {
                this.getStartPagenewsPreview(newValue);
            } catch (e) {

            }
        })
        this.subscription = this._shareddataservice.Formulatestevent.subscribe((newValue: any) => {
            try {
                this._testvariabllist = newValue[0]
                this.Formuladefination = newValue[1]

                this.Showformulapopup(this._testvariabllist, this.Formuladefination);
            } catch (e) {

            }
        })
        this.subscription = this._shareddataservice.LoadingstartEvent.subscribe((newValue: any) => {
            this.loadingstart();

        })
        this.subscription = this._shareddataservice.LoadingendEvent.subscribe((newValue: any) => {
            this.loadingend(newValue);

        })
        this.subscription = this._shareddataservice.Successmsg.subscribe((newValue: any) => {
            this.successmessage(newValue);

        })
        this.subscription = this._shareddataservice.Errormsg.subscribe((newValue: any) => {
            this.Errormsg(newValue);

        })
        this.subscription = this._shareddataservice.TaxswapfloeEvent.subscribe((newValue: any) => {
           this.swapid = newValue[0]
           this.oldtaxmasterid = newValue[1]
           this.newswapid = ''
            this._addnewversionservice.Getswaporderdd(newValue[1]).subscribe(
                res => {
                    this._swapdd = res
                    this.SwaptaxMasterId = '0'
                   
                })

            this.Swapformula()
        })
    }
    public StartPagenewsAdminlist: StartPageAdmin[]
    public StartPageglobalAdminlist: StartPageAdmin[];
    public Newscontent: StartPageAdmin[];
    public PreviewDataNews: StartPageAdmin[];
    public PreviewDataGlobal: StartPageAdmin[];
    ngOnInit() {
        this.PreviewDataNews = []
        this.PreviewDataGlobal = []
        this.Gethomenews()
        this.errormsg = []
    }
    private Gethomenews() {
        this._StartpageAdminservice.gethomenews().subscribe(
            admin => {
                this.PreviewDataNews = []
                this.PreviewDataGlobal = []
                this.Newscontent = []
                this.StartPageglobalAdminlist=[]
                this.StartPagenewsAdminlist = admin
                this.Newscontent = this.StartPagenewsAdminlist.filter(list => list.contentTypeId == '21')
                this.StartPageglobalAdminlist = this.StartPagenewsAdminlist.filter(list => list.contentTypeId == '22')
                this.PreviewDataNews = this.Newscontent
                this.PreviewDataGlobal = this.StartPageglobalAdminlist
            }

        )
    }
    private getStartPagenewsPreview(data: StartPageAdmin) {
       
        try {
                this.PreviewDataNews = this.Newscontent
                this.PreviewDataGlobal = this.StartPageglobalAdminlist
                this.PreviewDataNews = this.PreviewDataNews.filter(l => l.mnId != "0");
                this.PreviewDataGlobal = this.PreviewDataGlobal.filter(l => l.mnId != "0");
            if (data.contentTypeId == "21")
            {
                this.PreviewDataNews.unshift(data); 
            }
            if (data.contentTypeId == "22") {
                this.PreviewDataGlobal.unshift(data);
            }
            
            $('.overlay, #popupid').css('display', 'block');
            $('.newscontent').css('display', 'block');

          
        } 
        catch (e) {

        }
  
    }

    private GetPreviewNews() {
        this._StartpageAdminservice.getloadcontenttype(21).subscribe(
            admin => {
                this.PreviewDataNews = admin
    })
    }
    private GetpreviewGlobal() {
        this._StartpageAdminservice.getloadcontenttype(22).subscribe(
            admin => this.PreviewDataGlobal = admin)
    }
    closepopup() {
        this.PreviewDataNews = []
        this.PreviewDataGlobal = []
        $('.overlay, #popupid2').fadeOut(2000);
        $('.newscontent').fadeOut(2000);
        $('.overlay, #popupid').css('display', 'none');
        $('.newscontent').css('display', 'none');
    }
    public successmessage(msg: any) {
        this.message = msg;
        $('.overlay, #popupid2').css('display', 'block');
        $('#popupid5').css('display', 'block');
        this.closepopup();
    }
    public Errormsg(msg: any) {
        this.errormsg = []
        this.errormsg = msg;
        $('.overlay, #popupid3').css('display', 'block');
    }
    public loadingstart() {
        $('.overlay, #popupid4').css('display', 'block');
    }
    public loadingend(issave: boolean) {
        $('#popupid4').fadeOut("fast");
        $('.overlay, #popupid4').css('display', 'none');
        if (issave) {
            $('.overlay, #popupid5').css('display', 'block');
        }
        else {
            $('.overlay, #popupid5').css('display', 'none');

        }
    }
    public loadingdataend(issave: boolean) {
        $('#popupid4').fadeOut("fast");
        $('.overlay, #popupid4').css('display', 'none');

    }
    public Showformulapopup(issave: any,formuladefination:any) {

        $('.overlay, #formulatest').css('display', 'block');

    }
    public Swapformula() {
        $('.overlay, #swappopup').css('display', 'block');

    }
    public loadingclose() {
        this.errormsg = []
        this.PreviewDataNews = []
        this.PreviewDataGlobal = []
        this.Resulttest=""
        $('.overlay, #popupid2').css('display', 'none');
        $('.overlay, #popupid3').css('display', 'none');
        $('.overlay, #popupid4').css('display', 'none');
        $('.overlay, #formulatest').css('display', 'none');
        $('#swappopup').css('display', 'none');

    }
   
    public Result(Data: Variable[]) {
        try {
            this._testvariabllistdata = []
            for (let data of Data) {
                var obj = new Variable();
                obj.name = data.name
                obj.variableId = data.variableId
                if (data.variableTypeId =="7") {
                    obj.value = data.value
                }
                else {
                    obj.value = data.testValue
                }
                obj.definition = this.Formuladefination
                this._testvariabllistdata.push(obj)
            }
            this._addformulaservice.Getformularesult(this._testvariabllistdata)
                .subscribe(
                version => {
                    this.errorlist = version;
                    for (var i = 0; i < this.errorlist.length; i++) {

                        if (this.errorlist[i].errormsg.toString().trim() != '') {
                           // var erlist = new Errorlist("", this.errorlist[i].successmsg.toString())
                           // this.errorlist.push(erlist);
                            this.Resulttest = "Error:" + this.errorlist[i].errormsg.toString()
                           // this._shareddataservice.Error(this.errorlist);
                        }
                        else if (this.errorlist[i].successmsg.toString().trim() != '') {
                           // this._shareddataservice.Sucess("Result=" + this.errorlist[i].successmsg.toString().trim())
                            this.Resulttest = "Result:" + this.errorlist[i].successmsg.toString()
                            this._shareddataservice.loadingend(true)

                        }
                        break;
                    }
                },
                error => {
                    this._shareddataservice.loadingend(false)

                })
        } catch (e) {

        }


    }
    public changeswaporder(id: any) {
        var newdropdown = this._swapdd.filter(d => d.taxMasterId == id)
        this.newswapid = newdropdown[0].calculationOrder;
        this.newtaxmasterid = newdropdown[0].taxMasterId
    } 
    public Swapdata() {

        this._addnewversionservice.Swapdata(this.oldtaxmasterid, this.newtaxmasterid).subscribe(
            res => {
                this.loadingclose();
                this.successmessage("Calculation order swapped successfully.")
                this._shareddataservice.loadtaxdetails("sucess");
            })
    }
}
