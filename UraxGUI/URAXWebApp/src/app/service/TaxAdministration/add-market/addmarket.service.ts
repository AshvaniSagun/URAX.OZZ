import { Injectable, Component } from '@angular/core';
import { Http, Request, RequestMethod, Response, RequestOptions, Headers } from '@angular/http';
import 'rxjs/Rx';
import { Observable } from 'rxjs/Observable';
import { marketcodedropdown, marketcurencydropdown, marketmodel, subdivisionCode } from '../../../model/tax-administration/add-market/market.model'
import { apiurlmodel } from '../../../model/api-url.model'
import { shareddataservice, Errorlist } from '../../shared/shared.service'
import { Subscription } from 'rxjs';

@Component({
    providers: [Http]
})

@Injectable()
export class addMarketService {
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
    public _updateUrl: string = 'Market/UpdateMarket';
    public _delete: string = 'Market/Delete';
    public _marketcode: string = 'CountryCode';
    public _marketcurrency: string = 'CurrencyDetails';
    public _marketdetails: string = 'market/GetMarket';
    public _marketsave: string = 'Market/AddMarket'
    public _GetSubdivisionCode: string = 'SubdivisionCode/GetByCountryCodeId?id=';

    //Get
       //to get subdivisioncode

    public getsubdivisioncode(cid: any): Observable<subdivisionCode[]> {
        console.log(this.serverurl + this._GetSubdivisionCode + cid)
        return this._http.get(this.serverurl + this._GetSubdivisionCode + cid)
            .map(res => <subdivisionCode[]>res.json())
            .catch(this.handleError);
    }

    public getmarketcode(): Observable<marketcodedropdown[]> {
        //to get marketcode
        return this._http.get(this.serverurl + this._marketcode)
            .map(res => <marketcodedropdown[]>res.json())
            .catch(this.handleError);
    }
    public getmarketcurrency(): Observable<marketcurencydropdown[]> {
        //to get market currency
        return this._http.get(this.serverurl + this._marketcurrency)
            .map(res => <marketcurencydropdown[]>res.json())
            .catch(this.handleError);
    }
    public getmarketdetails(): Observable<marketmodel[]> {
        //debugger
        return this._http.get(this.serverurl + this._marketdetails)
            .map(res => <marketmodel[]>res.json())
            .catch(this.handleError);
    }

    //Post
    SaveCountryData(mar: marketmodel,countryid:any) {    
        this._shareddataservice.loadingstart("true");
        let body = JSON.stringify([
            {
               
                "marketId": 0,
                "countryName": mar.countryCodeId.countryName,
                "countryCodeId": mar.countryCodeId,
                "submarketCode": mar.submarketCode,
                "currencyId": mar.currencyId,
                "isActive": mar.isActive,
                "createdBy": this.loginuser,
                "createdOn": this._shareddataservice.getdate(),
                "updatedBy": this.loginuser,
                "updatedOn": this._shareddataservice.getdate(),
                "CountryCode": "",
                "CurrencyCode": "",
                "taxTerritory": mar.taxTerritory,
                "featureLevelTax": mar.featureLevelTax,
                "subdivisionCode": mar.subdivisionCode,
            }
        ]);
        let headers = new Headers({
            'Content-Type':
            'application/json; charset=utf-8'
        });
        let options = new RequestOptions({ headers: headers });
        return this._http.post(this.serverurl + this._marketsave, body, options)
            .map(res => <Errorlist[]>res.json())
            .catch(this.handleError);


    }
    UpdateCountryData(mar: marketmodel, countryid: any) {
            this._shareddataservice.loadingstart("true");
            let body = JSON.stringify([
                {
                    "marketId": mar.marketId,
                    "countryName": mar.countryCodeId.countryName,
                    "countryCodeId": mar.countryCodeId,
                    "submarketCode": mar.submarketCode,
                    "currencyId": mar.currencyId,
                    "isActive": mar.isActive,
                    "createdBy": this.loginuser,
                    "createdOn": this._shareddataservice.getdate(),
                    "updatedBy": this.loginuser,
                    "updatedOn": this._shareddataservice.getdate(),
                    "CountryCode": "",
                    "CurrencyCode": "",
                    "taxTerritory": mar.taxTerritory,
                    "featureLevelTax": mar.featureLevelTax,
                    "subdivisionCode": mar.subdivisionCode,
                }
            ]);
            let headers = new Headers({
                'Content-Type':
                'application/json; charset=utf-8'
            });
            let options = new RequestOptions({ headers: headers });
            return this._http.put(this.serverurl + this._updateUrl, body, options)
                .map(res => <Errorlist[]>res.json())
                .catch(this.handleError);
    }
    deletemarket(id: string): Observable<marketmodel[]> {
        //debugger
        var deleteByIdUrl = this.serverurl + this._delete + '?marketId=' + id
        return this._http.delete(deleteByIdUrl)
            .map(res => <marketmodel[]>res.json())
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        return Observable.throw(error.json().error || 'Oops!! Server error');
    }
}