import { Injectable, Component } from '@angular/core';
import { Http, Request, RequestMethod, Response, RequestOptions, Headers } from '@angular/http';
import 'rxjs/Rx';
import { Observable } from 'rxjs/Observable';
import { ddlpricebaselist, ddlvatrelationlist, NewVersion, SwapingorderDD } from '../../../../model/tax-administration/add-version/new-version/NewVersion.model'
import { tax_menu_marketdd, tax_menu_taxtype_dd, tax_menu_tax_dd, tax_menu_version_dd } from '../../../../model/tax-administration/add-version/tax-admin-menu/tax.admin.menu'
import { shareddataservice,Errorlist } from '../../../../service/shared/shared.service'
import { apiurlmodel } from '../../../../model/api-url.model';
import { Subscription } from 'rxjs';

@Component({
    providers: [Http]
})

@Injectable()
export class Addnewversionservice {
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
   // public loginuser: string = this._apiurlmodel.loginuser;
    //public _UpdateVariable: string = 'Variables/UpdateVariable';
    //public _DeleteVariable: string = 'Variables/Delete';
    public _Gettaxmasterdetails: string = 'TaxMaster/GetTaxDetails';
    public _GetPriceDrop: string = 'Parameter/Get';
    public _GetVatDrop: string = 'Parameter/Get';
    public _SaveVersion: string = 'TaxMaster/AddTaxMasterDetails'
    public _updateversion: string = 'TaxMaster/UpdateTaxMasterDetails'
    public _copytax: string = 'CopyTax/AddCopyTaxWithTaxVersion'
    public _addnewversion: string = 'TaxVersion/AddVersionDetails'
    public _validationversion: string = 'TaxVersion/CheckVersionDetails'
    public _savepricebase: string = 'Tax/AddPriceBase'
    public _gettaxstatusdd: string = 'Parameter/Get?Id=10'
    public _getnewcalculationorder: string = 'TaxMaster/GetNewCalculationOrder'
    public _getswaporderdd: string = 'TaxMaster/GetCalculationOrder?TaxMasterId='
    public _swapingdata: string = 'TaxMaster/SwapCalculationOrder?taxMasterId='
    //Get Variable Details
    public Gettaxstatusdd(): Observable<ddlvatrelationlist[]> {

        return this._http.get(this.serverurl + this._gettaxstatusdd)
            .map(res => <ddlvatrelationlist[]>res.json())
            .catch(this.handleError);
    }
    public Getswaporderdd(taxid:any): Observable<SwapingorderDD[]> {

        return this._http.get(this.serverurl + this._getswaporderdd + taxid)
            .map(res => <SwapingorderDD[]>res.json())
            .catch(this.handleError);
    }
    public Gettaxflow(Id: any): Observable<NewVersion[]> {
        
        return this._http.get(this.serverurl + this._Gettaxmasterdetails + '?TaxId=' + Id)
            .map(res => <NewVersion[]>res.json())
            .catch(this.handleError);
    }
    public Getcalculationget(Id: any): Observable<any[]> {
        return this._http.get(this.serverurl + this._getnewcalculationorder + '?taxTerritoryId=' + Id)
            .map(res => <any[]>res.json())
            .catch(this.handleError);
    }
    //Get Price base dropdown
    public GetPriceDrop(): Observable<ddlpricebaselist[]> {
        return this._http.get(this.serverurl + this._GetPriceDrop + '?Id=1')
            .map(res => <ddlpricebaselist[]>res.json())
            .catch(this.handleError);
    }
    //Get Vat Relation Dropdown
    public GetVatDrop(): Observable<ddlvatrelationlist[]> {
        return this._http.get(this.serverurl + this._GetVatDrop + '?Id=2')
            .map(res => <ddlvatrelationlist[]>res.json())
            .catch(this.handleError);
    }
    public SaveVersionDetails(objver: NewVersion, taxid: any, taxMasterId: any, taxVersionId: any, marketId: any) {
        this._shareddataservice.loadingstart("true");
        let body = JSON.stringify([
            {
                "taxMasterId": 0,
                "taxVersionId": 0,
                "taxId": 0,
                "marketId": marketId,
                "taxName": objver.taxName,
                "vatRelation": objver.vatRelation,
                "priority": objver.priority,
                "PriceBase": objver.priceBase,
                "versionValidFrom": objver.versionValidFrom,
                "versionValidUpto": objver.versionValidUpto,
                "isActive": true,
                "createdBy": this.loginuser,
                "createdOn": this._shareddataservice.getdate(),
                "updatedBy": this.loginuser,
                "updatedOn": this._shareddataservice.getdate(),
                "taxVersionStatusId": objver.taxVersionStatusId,
                "featureLevelTax": objver.featureLevelTax

            }
        ]);

        let headers = new Headers({
            'Content-Type':
            'application/json; charset=utf-8'
        });
        let options = new RequestOptions({ headers: headers });
        return this._http.post(this.serverurl + this._SaveVersion, body, options)
            .map(res => <Errorlist[]>res.json())
            .catch(this.handleError);
    }
    public Updateversiondetails(objver: NewVersion, taxid: any, taxMasterId: any, taxVersionId: any, marketId: any)  {
        this._shareddataservice.loadingstart("true");
        let body = JSON.stringify([
            {
                "taxMasterId": objver.taxMasterId,
                "taxVersionId": objver.taxVersionId,
                "taxId": objver.taxId,
                "marketId": marketId,
                "taxName": objver.taxName,
                "vatRelation": objver.vatRelation,
                "priority": objver.priority,
                "PriceBase": objver.priceBase,
                "versionValidFrom": objver.versionValidFrom,
                "versionValidUpto": objver.versionValidUpto,
                "isActive": true,
                "createdBy": this.loginuser,
                "createdOn": this._shareddataservice.getdate(),
                "updatedBy": this.loginuser,
                "updatedOn": this._shareddataservice.getdate(),
                "taxVersionStatusId": objver.taxVersionStatusId,
                "featureLevelTax": objver.featureLevelTax
            }
        ]);

        let headers = new Headers({
            'Content-Type':
            'application/json; charset=utf-8'
        });
        let options = new RequestOptions({ headers: headers });
        return this._http.put(this.serverurl + this._updateversion, body, options)
            .map(res => <Errorlist[]>res.json())
            .catch(this.handleError);
    }
    public savecopytax(model: NewVersion, mid: any, taxmasterid: any,taxversionid:any) {
        this._shareddataservice.loadingstart("true");
        let body = JSON.stringify([
            {
                "taxMasterId": taxmasterid,
                "taxName": model.taxName,
                "taxVersionId": taxversionid,
                "startDate": model.versionValidFrom,
                "endDate": model.versionValidUpto,
                "taxVersionStatusId": model.taxVersionStatusId,
                "createdBy": this.loginuser

            }
        ]);
        let headers = new Headers({
            'Content-Type':
            'application/json; charset=utf-8'
        });
        let options = new RequestOptions({ headers: headers });
        return this._http.post(this.serverurl + this._copytax, body, options)
            .map(res => <Errorlist[]>res.json())
            .catch(this.handleError);
    }
    public SaveVersion(objver: NewVersion, taxid: any, taxVersionId: any,vvf:any,vvt:any) {
        this._shareddataservice.loadingstart("true");
        let body = JSON.stringify([
            {
                "taxMasterId": taxid,
                "taxVersionId": taxVersionId,
                "taxId": taxid,
                "priceBase": objver.priceBase,
                "versionValidFrom": vvf,
                "versionValidUpto": vvt,
                "isActive": true,
                "createdBy": this.loginuser,
                "createdOn": this._shareddataservice.getdate(),
                "updatedBy": this.loginuser,
                "updatedOn": this._shareddataservice.getdate(),
                "taxVersionStatusId": objver.taxVersionStatusId,
                "featureLevelTax": objver.featureLevelTax
            }
        ]);
        let headers = new Headers({
            'Content-Type':
            'application/json; charset=utf-8'
        });
        let options = new RequestOptions({ headers: headers });
        return this._http.post(this.serverurl + this._addnewversion, body, options)
            .map(res => <Errorlist[]>res.json())
            .catch(this.handleError);
    }
    public validationdata(objver: NewVersion, taxid: any, taxVersionId: any, vvf: any, vvt: any) {
        this._shareddataservice.loadingstart("true");
        let body = JSON.stringify([
            {
                "taxMasterId": taxid,
                "taxVersionId": taxVersionId,
                "taxId": taxid,
                "priceBase": objver.priceBase,
                "versionValidFrom": vvf,
                "versionValidUpto": vvt,
                "isActive": true,
                "createdBy": this.loginuser,
                "createdOn": this._shareddataservice.getdate(),
                "updatedBy": this.loginuser,
                "updatedOn": this._shareddataservice.getdate(),
                "taxVersionStatusId": objver.taxVersionStatusId,
                "featureLevelTax": objver.featureLevelTax
            }
        ]);
        let headers = new Headers({
            'Content-Type':
            'application/json; charset=utf-8'
        });
        let options = new RequestOptions({ headers: headers });
        return this._http.post(this.serverurl + this._validationversion, body, options)
            .map(res => <Errorlist[]>res.json())
            .catch(this.handleError);
    }
    public savepricebase(taxmasterid: any, taxversionid: any, pricebase: any) {
        this._shareddataservice.loadingstart("true");
        let body = JSON.stringify([
            {
                "taxId": taxmasterid,
                "taxVersionId": taxversionid,
                "taxFlowId": pricebase,
                "isActive": true,
                "createdBy": this.loginuser,
                "createdOn": this._shareddataservice.getdate(),
                "updatedBy": this.loginuser,
                "updatedOn": this._shareddataservice.getdate(),
            }
        ]);
        let headers = new Headers({
            'Content-Type':
            'application/json; charset=utf-8'
        });
        let options = new RequestOptions({ headers: headers });
        return this._http.post(this.serverurl + this._savepricebase, body, options)
            .map(res => <Errorlist[]>res.json())
            .catch(this.handleError);
    }
    public Swapdata(oldtaxmasterid: any, newtaxmasterid: any) {
        this._shareddataservice.loadingstart("true");
        let body = JSON.stringify([
            {
               
            }
        ]);

        let headers = new Headers({
            'Content-Type':
            'application/json; charset=utf-8'
        });
        this._swapingdata = this._swapingdata + oldtaxmasterid + '&swaptaxMasterId=' + newtaxmasterid + '&loginUser=' + this.loginuser
        let options = new RequestOptions({ headers: headers });
        return this._http.put(this.serverurl + this._swapingdata, body, options)
            .map(res => <Errorlist[]>res.json())
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        return Observable.throw(error.json().error || 'Oops!! Server error');
      
    }
}