import { Injectable, Component } from '@angular/core';
import {
    Http, Request, RequestMethod, Response,
    RequestOptions, Headers
} from '@angular/http';
import 'rxjs/Rx';
import { Observable } from 'rxjs/Observable';
import { marketmodel } from '../../../model/tax-administration/market-model/market-model';

@Component({
    providers: [Http]
})

@Injectable()
export class MarketService {
    public headers: Headers;
    constructor(private _http: Http) {
    }
    public serverurl: string = 'http://test-urax-volvocars.azurewebsites.net';
    public _updateUrl: string = '/api/Market/UpdateMarket/';
    public _delete: string = '/api/Market/MarketDelete';
    public _marketcode: string = '/Api/Market/GetCurrency';
    public _marketcurrency: string = '/Api/Market/GetCurrency/';
    public _marketdetails: string = '/api/Market/MarketDetails/';
    public _marketsave: string = '/api/Market/Post/'


    //Get
    getmarketcode(): Observable<marketmodel[]> {
        //to get marketcode
        return this._http.get(this.serverurl + this._marketcode)
            .map(res => <marketmodel[]>res.json())
            .catch(this.handleError);
    }
    getmarketcurrency(): Observable<marketmodel[]> {
        //to get market currency
        return this._http.get(this.serverurl + this._marketcurrency)
            .map(res => <marketmodel[]>res.json())
            .catch(this.handleError);
    }
    getmarketdetails(): Observable<marketmodel[]> {
        //debugger
        return this._http.get(this.serverurl + this._marketdetails)
            .map(res => <marketmodel[]>res.json())
            .catch(this.handleError);
    }

    //Post
    SaveCountryData(model: marketmodel) {

        let body = JSON.stringify([
            {
                "mid": "0",
                "countryName": model.countryName,
                "countryCode": model.countryCode,
                "specificationMarket": model.specificationMarket,
                "programMarket": model.programMarket,
                "CurrencyId": model.CurrencyId,
                "isActive": true,
                "createdOn": ""
            }
        ]);
        console.log(body);
        let headers = new Headers({
            'Content-Type':
            'application/json; charset=utf-8'
        });
        let options = new RequestOptions({ headers: headers });
        return this._http.post(this.serverurl + this._marketsave, body, options)
            .map(res => <marketmodel[]>res.json())
            .catch(this.handleError);
    }

    UpdateCountryData(model: marketmodel) {

        let body = JSON.stringify([
            {
                "mid": model.mid,
                "countryName": model.countryName,
                "countryCode": model.countryCode,
                "specificationMarket": model.specificationMarket,
                "programMarket": model.programMarket,
                "CurrencyId": model.CurrencyId,
                "isActive": true,
                "createdOn": ""
            }
        ]);
        console.log(body);
        let headers = new Headers({
            'Content-Type':
            'application/json; charset=utf-8'
        });
        let options = new RequestOptions({ headers: headers });
        return this._http.post(this.serverurl + this._updateUrl, body, options)
            .map(res => <marketmodel[]>res.json())
            .catch(this.handleError);
    }


    deletemarket(id: string): Observable<marketmodel[]> {
        //debugger
        var deleteByIdUrl = this.serverurl + this._delete + '?marketId=' + id
        console.log(deleteByIdUrl);
        return this._http.get(deleteByIdUrl)
            .map(res => <marketmodel[]>res.json())
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        return Observable.throw(error.json().error || 'Opps!! Server error');
    }
}