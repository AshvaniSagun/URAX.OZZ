import { Injectable, Component } from '@angular/core';
import { Http, Request, RequestMethod, Response, RequestOptions, Headers } from '@angular/http';
import 'rxjs/Rx';
import { Observable } from 'rxjs/Observable';
import { languagemodel, LanguageDropdown } from '../../../../model/tax-administration/add-version/add-lang/language.model';
import { apiurlmodel } from '../../../../model/api-url.model';
import { shareddataservice, Errorlist } from '../../../shared/shared.service'
import { Subscription } from 'rxjs';

@Component({
    providers: [Http]
})

@Injectable()
export class addLanguageService {
    public headers: Headers;
    public subscription: Subscription;
    public loginuser: string
    constructor(private _http: Http, public _shareddataservice: shareddataservice) {
        this.subscription = this._shareddataservice.LoginuserEvent.subscribe((Loginuser: any) => {
            this.loginuser = Loginuser;
        })
    }
    public _apiurlmodel = new apiurlmodel();

    //public loginuser: string = this._apiurlmodel.loginuser;
    public serverurl: string = this._apiurlmodel.apiurl;
    public _updateUrl: string = 'LanguageDetails/UpdateLanguageDetails';
    public _delete: string = 'LanguageDetails/Delete';
    public _LanguageDropdown: string = 'Languages/Get';
    public _languagedetails: string = 'LanguageDetails/GetDetails?TaxId=';
    public _languagesave: string = 'LanguageDetails/AddLanguageDetails'



    public getlanguagedetail(TaxId: any): Observable<languagemodel[]> {
        //debugger
        return this._http.get(this.serverurl + this._languagedetails + TaxId)
            .map(res => <languagemodel[]>res.json())
            .catch(this.handleError);
    }
    public GetLangugeDropdown(): Observable<LanguageDropdown[]> {
        return this._http.get(this.serverurl + this._LanguageDropdown)
            .map(res => <LanguageDropdown[]>res.json())
            .catch(this.handleError);
    }
    //Post
    SaveLanguage(mar: languagemodel, taxid: any) {

        let body = JSON.stringify([
            {
                "languageDetailid": "0",
                "taxMasterId": taxid,
                "languageId": mar.languageId,
                "languageName": mar.languageName,
                "taxName": mar.taxName,
                "isActive": mar.isActive,
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
        return this._http.post(this.serverurl + this._languagesave, body, options)
            .map(res => <languagemodel[]>res.json())
            .catch(this.handleError);
    }
    //PUT
    UpdateLanguage(mar: languagemodel, taxid: any) {

        let body = JSON.stringify([
            {
                "languageDetailid": mar.languageDetailid,
                "taxMasterId": taxid,
                "languageId": mar.languageId,
                "languageName": mar.languageName,
                "taxName": mar.taxName,
                "isActive": mar.isActive,
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
        return this._http.put(this.serverurl + this._updateUrl, body, options)
            .map(res => <languagemodel[]>res.json())
            .catch(this.handleError);
    }

    //DELETE
    DeleteLanguage(languageDetailsId: string): Observable<languagemodel[]> {
        //debugger
        var deleteByIdUrl = this.serverurl + this._delete + '?languageDetailsId=' + languageDetailsId
        return this._http.delete(deleteByIdUrl)
            .map(res => <languagemodel[]>res.json())
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        return Observable.throw(error.json().error || 'Oops!! Server error');
    }
}
