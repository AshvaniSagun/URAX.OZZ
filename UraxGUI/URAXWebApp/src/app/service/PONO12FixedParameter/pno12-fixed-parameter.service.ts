import { Injectable, Component } from '@angular/core';
import { Http, Request, RequestMethod, Response, RequestOptions, Headers } from '@angular/http';
import 'rxjs/Rx';
import { Observable } from 'rxjs/Observable';
import { PNO12FixedParameter, PNO12FixedHeader } from '../../model/PONO12FixedParameter/pno12-fixed-parameter';
import { apiurlmodel } from '../../model/api-url.model';
import { shareddataservice, Errorlist } from '../shared/shared.service'
import { Subscription } from 'rxjs';

@Injectable()
export class PNO12FixedParameterService {
    public subscription: Subscription;
    public loginuser: string
    public headers: Headers;
    constructor(private _http: Http, public _shareddataservice: shareddataservice) {
        this.subscription = this._shareddataservice.LoginuserEvent.subscribe((Loginuser: any) => {
            this.loginuser = Loginuser;
        })
    }

    public _apiurlmodel = new apiurlmodel();
    public serverurl: string = this._apiurlmodel.apiurl;
    //public GetPNO12: string = 'Pno12/GetPno12Details';
    public GetPNO12: string = 'Pno12/GetPno12AllData';
    public GetPNO12_column: string = 'Pno12/GetPno12HeaderDetails';
    


    public GetPNO12Details(): Observable<any[]> {
        //debugger
        return this._http.get(this.serverurl + this.GetPNO12)
            .map(res => <any[]>res.json())
            .catch(this.handleError);
    }

    public GetPNO12Column(): Observable<PNO12FixedHeader[]> {
        //debugger
        return this._http.get(this.serverurl + this.GetPNO12_column)
            .map(res => <PNO12FixedHeader[]>res.json())
            .catch(this.handleError);
    }
    private handleError(error: Response) {
        return Observable.throw(error.json().error || 'Oops!! Server error');
    }

}
