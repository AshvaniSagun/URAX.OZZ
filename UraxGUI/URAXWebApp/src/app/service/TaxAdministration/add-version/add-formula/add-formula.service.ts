import { Injectable, Component } from '@angular/core';
import { Http, Request, RequestMethod, Response, RequestOptions, Headers } from '@angular/http';
import 'rxjs/Rx';
import { Observable } from 'rxjs/Observable';
import { formulamodel, formulaNamedropdown,Variable } from '../../../../model/tax-administration/add-version/add-formula/formula.model';
import { apiurlmodel } from '../../../../model/api-url.model';
import { shareddataservice,Errorlist } from '../../../shared/shared.service'
import { Subscription } from 'rxjs';

@Component({
    providers: [Http]
})

@Injectable()
export class addFormulaService {
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
    //public loginuser: string = this._apiurlmodel.loginuser;
    public _updateFormula: string = 'Formula/UpdateFormulaAndDependency';
    public _DeleteFormula: string = 'Formula/DeleteFormulaAndDependency';
    public _FormulaDropdown: string = 'Variables/GetVariableDrp';
    public _formuladetails: string = 'Formula/GetFormulaDetails';
    public _formulasave: string = 'Formula/addFormulaAndDependency';
    public _formulatestvariabllist: string = 'Formula/GetTestFormula?'; 
    public _formulatestresult: string = 'Formula/TestFormula'; 

    public getFormulaName(id: any): Observable<formulaNamedropdown[]> {
        return this._http.get(this.serverurl + this._FormulaDropdown + '?TaxFlowId=' + id)
            .map(res => <formulaNamedropdown[]>res.json())
            .catch(this.handleError);
    }
    public getformuladetails(id: any): Observable<formulamodel[]> {
        return this._http.get(this.serverurl + this._formuladetails + '?TaxFlowId=' + id)
            .map(res => <formulamodel[]>res.json())
           
    } 
    public Getformulavariablelist(id: any): Observable<Variable[]> {
        return this._http.get(this.serverurl + this._formulatestvariabllist + 'formulaId=' + id)
            .map(res => <Variable[]>res.json())
            .catch(this.handleError);
    } 


    SaveFormulaDetails(mar: formulamodel) {
        this._shareddataservice.loadingstart("true");

        let body = JSON.stringify([
            {
                "formulaId": 0,
                "variableId": mar.variableId,
                "formulaName": "formulaname",
                "formulaDefinition": mar.formulaDefinition,
                "minValue": mar.minValue,
                "maxValue": mar.maxValue,
                "priority": mar.priority,
                "roundId": 17,
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
        return this._http.post(this.serverurl + this._formulasave, body, options)
            .map(res => <Errorlist[]>res.json())
            .catch(this.handleError);
    }

    UpdateFormulaDetails(mar: formulamodel) {
        this._shareddataservice.loadingstart("true");
        let body = JSON.stringify([
            {

                "formulaId": mar.formulaId,
                "variableId": mar.variableId,
                "formulaName": "formulaname",
                "formulaDefinition": mar.formulaDefinition,
                "minValue": mar.minValue,
                "maxValue": mar.maxValue,
                "priority": mar.priority,
                "roundId": 17,
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
        return this._http.put(this.serverurl + this._updateFormula, body, options)
            .map(res => <Errorlist[]>res.json())
            .catch(this.handleError);
    }


    deleteFormula(id: string): Observable<formulamodel[]> {
        //debugger
        var deleteByIdUrl = this.serverurl + this._DeleteFormula + '?formulaId=' + id
        return this._http.delete(deleteByIdUrl)
            .map(res => <formulamodel[]>res.json())
            .catch(this.handleError);
    }
    Getformularesult(variable: any) {

        let body = JSON.stringify([
            {
                variable

            },

        ]);
        let headers = new Headers({
            'Content-Type':
            'application/json; charset=utf-8'
        });
        let options = new RequestOptions({ headers: headers });
        return this._http.post(this.serverurl + this._formulatestresult, body, options)
            .map(res => <Errorlist[]>res.json())
            .catch(this.handleError);
    }
    private handleError(error: Response) {
        return Observable.throw(error.json().error || 'Oops!! Server error');
    }
}