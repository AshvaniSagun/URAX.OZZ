import { Injectable, Component, EventEmitter } from '@angular/core';
import { Http, Request, RequestMethod, Response, RequestOptions, Headers } from '@angular/http';
import { marketcodedropdown, marketcurencydropdown, marketmodel } from '../../model/tax-administration/add-market/market.model'
import 'rxjs/Rx';
import { tax_menu_tax_dd } from '../../model/tax-administration/add-version/tax-admin-menu/tax.admin.menu'
import { Observable } from 'rxjs/Observable';

@Component({
    providers: [Http]
})

@Injectable()
export class shareddataservice {
    public listtaxflow:string[] = []
    public calculationorder: string[] = []
    public Formulalist: any[] = []
    public TaxstatusEvents: EventEmitter<boolean> = new EventEmitter();
    public inputEvents: EventEmitter<string> = new EventEmitter();
    public LoginuserEvent: EventEmitter<string> = new EventEmitter();
    public cleardataevent: EventEmitter<string> = new EventEmitter();
    public languageEvent: EventEmitter<string> = new EventEmitter();
    public TaxEvent: EventEmitter<string> = new EventEmitter();
    public TaxversionEvent: EventEmitter<string> = new EventEmitter();
    public TaxflowEvent: EventEmitter<string> = new EventEmitter();
    public Marketlist: EventEmitter<string> = new EventEmitter();
    public Newtaxaddedevent: EventEmitter<string> = new EventEmitter();
    public Cleardata: EventEmitter<string> = new EventEmitter();
    public CleartaxflowdataEvent: EventEmitter<string> = new EventEmitter();
    public VariablechangeEvent: EventEmitter<string> = new EventEmitter();
    public LoadingstartEvent: EventEmitter<string> = new EventEmitter();
    public Successmsg: EventEmitter<string> = new EventEmitter();
    public Errormsg: EventEmitter<any> = new EventEmitter();
    public LoadingendEvent: EventEmitter<string> = new EventEmitter();
    public newscontentevent: EventEmitter<any> = new EventEmitter();
    public ResetlookupEvent: EventEmitter<any> = new EventEmitter();
    public previewpopupEvent: EventEmitter<any> = new EventEmitter();
    public Updatetaxmasterevent: EventEmitter<any> = new EventEmitter(); 
    public TaxmarketidEvent: EventEmitter<any> = new EventEmitter(); 
    public cleardataeventmarket: EventEmitter<any> = new EventEmitter(); 
    public Formulatestevent: EventEmitter<any> = new EventEmitter(); 
    public TaxmarketCleardataEvent: EventEmitter<any> = new EventEmitter(); 
    public TaxflowidEvevnt: EventEmitter<any> = new EventEmitter(); 
    public VersionnextidEvent: EventEmitter<any> = new EventEmitter(); 
    public TaxswapfloeEvent: EventEmitter<any> = new EventEmitter(); 
    public loadtaxdetailsevent: EventEmitter<any> = new EventEmitter();  
    public HeadersetEvent: EventEmitter<any> = new EventEmitter();  

    public Setversionnextid(val: any) {
        this.VersionnextidEvent.emit(val);
    }
    public loadtaxdetails(val: any) {
        this.loadtaxdetailsevent.emit(val);
    }
    public Settaxstaus(val: any) {
        this.TaxstatusEvents.emit(val);
    }
    public updatetaxmaster(taxmarketid:any,taxterritoryid: any, taxid: any, taxversionid: any, taxflow: any) {
        this.listtaxflow[0] = taxmarketid
        this.listtaxflow[1] = taxterritoryid
        this.listtaxflow[2] = taxid
        this.listtaxflow[3] = taxversionid
        this.listtaxflow[4] = taxflow
        this.Updatetaxmasterevent.emit(this.listtaxflow);
    }
    public navigationcleardatamarket(val: any) {
        
        this.cleardataeventmarket.emit(val);
    }
    public Getswapdetails(val: any,taxid:any)
    {
        this.calculationorder[0] = val
        this.calculationorder[1] = taxid
        this.TaxswapfloeEvent.emit(this.calculationorder);
    }
    public FormulaTest(list: any,formuladefination:any) {
        
        this.Formulalist[0] = list
        this.Formulalist[1] = formuladefination
        this.Formulatestevent.emit(this.Formulalist);
    }
    public navigationcleardata(val: any) {
        this.cleardataevent.emit(val);
    }
    public previewpopup(val: any) {
        this.previewpopupEvent.emit(val);
    }
    public loginuserset(val: any) {
        this.LoginuserEvent.emit(val);
    }
    public headerset(val: any) {
        this.HeadersetEvent.emit(val);
    }
    public inputChanged(val: any) {
        this.inputEvents.emit(val);
    }
    public loadingstart(val: any) {
        this.LoadingstartEvent.emit(val);
    }
    public loadingend(val: any) {
        this.LoadingendEvent.emit(val);
    }
    public Sucess(val: any) {
        this.Successmsg.emit(val);
    }
    public Error(val: any) {
        this.Errormsg.emit(val);
    }
    public variablechange(val: any) {
        this.VariablechangeEvent.emit(val);
    }
    public cleartaxflowdata(val: any) {
        this.CleartaxflowdataEvent.emit(val);
    }
    public languageidchange(val: string) {
        this.languageEvent.emit(val);
    }
    public Taxmarketchange(val: any) {
        this.TaxmarketCleardataEvent.emit(val);
    }
    public Taxterritorychange(val: any) {
        this.TaxmarketidEvent.emit(val);
    }
    public Taxidchange(val: string) {
        this.TaxEvent.emit(val);
    }
    public Taxvesrsionchange(val: string) {
        this.TaxversionEvent.emit(val);
    }
    public Taxflowchange(val: string) {
        this.TaxflowEvent.emit(val);
    }
    public Taxflowid(val: string) {
        this.TaxflowidEvevnt.emit(val);
    }
    public marketlistadded(val: string) {
        this.Marketlist.emit(val);
    }
    public Addnemarkettax(val: string) {
        this.Newtaxaddedevent.emit(val);
    }
    public cleardata(val: string) {
        this.Cleardata.emit(val);
    }
    public loadnewscontent(val: any) {
        this.newscontentevent.emit(val);
    }
    public resetlookup(val: any) {
        this.ResetlookupEvent.emit(val);
    }
    public getdate()
    {
        try {
            var currentdate = new Date();
            currentdate.toISOString().substring(0, 10);
            return currentdate;
        } catch (e) {

        }
 }
    private handleError(error: Response) {
        return Observable.throw(error.json().error || 'OOps!! Server error');
    }
}
export class Errorlist {
    errormsg: string;
    successmsg: string;
    constructor(sucess: string, error: string) {
        this.errormsg = error;
        this.successmsg = sucess;
    }
}