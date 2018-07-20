import { Injectable, Component } from '@angular/core';
import { Http, Request, RequestMethod, Response, RequestOptions, Headers } from '@angular/http';
import 'rxjs/Rx';
import { Observable } from 'rxjs/Observable';
import { tax_menu_marketdd, tax_menu_taxtype_dd, tax_menu_tax_dd, tax_menu_version_dd,Taxmenutaxteritory } from '../../../../model/tax-administration/add-version/tax-admin-menu/tax.admin.menu'
import { apiurlmodel } from '../../../../model/api-url.model'
import { shareddataservice } from '../../../shared/shared.service'
import { Subscription } from 'rxjs';

@Component({
    providers: [Http]
})

@Injectable()
export class taxadminmenuservice {
    public headers: Headers;
    public subscription: Subscription;
    public loginuser: string
    constructor(private _http: Http, public _shareddataservice: shareddataservice) {
        this.subscription = this._shareddataservice.LoginuserEvent.subscribe((Loginuser: any) => {
            this.loginuser = Loginuser;
        })
    }
    public _apiurlmodel = new apiurlmodel();
    public serverurl: string = this._apiurlmodel.apiurl;
    public _getmarketlist: string = 'market/GetCountry';
    public _getcountrytaxterritory: string = 'market/GetTaxTerritory?';
    public _getaxlist: string = 'TaxMaster/GetTaxMasterName';
    public _getversionlist: string = 'TaxMaster/GetTaxVersionName';
    public _gettaxtypelist: string = 'TaxMaster/GetTaxFlowName';
  

    public Getcountrylistdd(): Observable<tax_menu_marketdd[]> {
        return this._http.get(this.serverurl + this._getmarketlist)
            .map(res => <tax_menu_marketdd[]>res.json())
            .catch(this.handleError);

    }
    public GetTAxterritory(taxteryid: any): Observable<Taxmenutaxteritory[]> {
        return this._http.get(this.serverurl + this._getcountrytaxterritory + 'CountryCodeId=' + taxteryid)
            .map(res => <Taxmenutaxteritory[]>res.json())
            .catch(this.handleError);

    }
   
    public Gettaxlist(mid: any): Observable<tax_menu_tax_dd[]> {
        console.log(this.serverurl + this._getaxlist + '?MarketId=' + mid)
        return this._http.get(this.serverurl + this._getaxlist + '?MarketId=' + mid)
            .map(res => <tax_menu_tax_dd[]>res.json())
            .catch(this.handleError);
    }
    public Getversionlistdd(taxid: any): Observable<tax_menu_version_dd[]> 
    {
        console.log(this.serverurl + this._getversionlist + '?TaxMasterId=' + taxid)

        return this._http.get(this.serverurl + this._getversionlist + '?TaxMasterId=' + taxid)
            .map(res => <tax_menu_version_dd[]>res.json())
            .catch(this.handleError);
    }
    public Gettaxtypelist(verid:any): Observable<tax_menu_taxtype_dd[]> {
        return this._http.get(this.serverurl + this._gettaxtypelist + '?TaxVersionId=' + verid)
            .map(res => <tax_menu_taxtype_dd[]>res.json())
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        return Observable.throw(error.json().error || 'Oops!! Server error');
    }
}