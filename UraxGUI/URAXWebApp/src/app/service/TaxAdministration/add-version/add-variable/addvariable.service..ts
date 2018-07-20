 import { Injectable, Component } from '@angular/core';
import { Http, Request, RequestMethod, Response,RequestOptions, Headers} from '@angular/http';
import 'rxjs/Rx';
import { Observable } from 'rxjs/Observable';
import { VariableModel, VariableType, VariableUnit, Parameter } from '../../../../model/tax-administration/add-version/add-variable/Variable.model';
import { apiurlmodel } from '../../../../model/api-url.model';
import { shareddataservice, Errorlist } from '../../../shared/shared.service'
import { Subscription } from 'rxjs';

@Component({
    providers: [Http]
})

@Injectable()
export class AddVariableService {
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
    public _UpdateVariable: string = 'Variables/UpdateVariable';
    public _DeleteVariable: string = 'Variables/Delete';
    public _Getvariable: string = 'Variables/GetVariableDetail';
    public _VariableTypeD: string = 'Parameter/Get';
    public _VariableUnitD: string = 'Parameter/Get';
    public _SaveVariable: string = 'Variables/AddVariable'
    public _inputtype: string = 'Parameter/GetInputParameter?TaxId='
    //Get Variable Details
    public GetVariableDetails(varid: any): Observable<VariableModel[]> {
        return this._http.get(this.serverurl + this._Getvariable +'?TaxId=' + varid)
            .map(res => <VariableModel[]>res.json())
            .catch(this.handleError);
    }

    //Get Variable Type
    public GetVariableType(): Observable<VariableType[]> {
        return this._http.get(this.serverurl + this._VariableTypeD + '?Id=3')
            .map(res => <VariableType[]>res.json())
            .catch(this.handleError);
    }
    public GetInputType(taxid:any): Observable<Parameter[]> {
        return this._http.get(this.serverurl + this._inputtype + taxid + '&TypeId=7')
            .map(res => <Parameter[]>res.json())
            .catch(this.handleError);
    }


    //Get Variable Unit
    public GetVariableUnit(): Observable<VariableUnit[]> {
        return this._http.get(this.serverurl + this._VariableTypeD + '?Id=5')
            .map(res => <VariableUnit[]>res.json())
            .catch(this.handleError);
    }

    //Post
    SaveVariableDetails(mar: VariableModel, varid: any) {      
            let body = JSON.stringify([
                {
                    "variableId": 0,
                    "taxId": varid,
                    "variableName": mar.variableName,
                    "variableValue": mar.variableValue,
                    "unitTypeId": mar.unitTypeId,
                    "variableTypeId": mar.variableTypeId,
                    "isLookup": mar.isLookup,
                    "isActive": true,
                    "createdBy": this.loginuser,
                    "createdOn": this._shareddataservice.getdate(),
                    "updatedBy": this.loginuser,
                    "updatedOn": this._shareddataservice.getdate(),
                    "UnitTypeName": mar.UnitTypeName,
                    "testValue": mar.testValue,
                    "VariableTypeName": mar.VariableTypeName,
                    "TaxFlowValue": "MSRPFlow"

                }
        ]);
            let headers = new Headers({
                'Content-Type':
                'application/json; charset=utf-8'
            });
            let options = new RequestOptions({ headers: headers});
            return this._http.post(this.serverurl + this._SaveVariable, body, options)
                .map(res => <Errorlist[]>res.json())
                .catch(this.handleError);
        }
    UpdateVariableDetails(mar: VariableModel, varid: any) {
        this._shareddataservice.loadingstart("true");
        let body = JSON.stringify([
            {
                "variableId": mar.variableId,
                "taxId": varid,
                "variableName": mar.variableName,
                "variableValue": mar.variableValue,
                "unitTypeId": mar.unitTypeId,
                "variableTypeId": mar.variableTypeId,
                "isLookup": mar.isLookup,
                "isActive": true,
                "createdBy": this.loginuser,
                "createdOn": this._shareddataservice.getdate(),
                "updatedBy": this.loginuser,
                "updatedOn": this._shareddataservice.getdate(),
                "UnitTypeName": mar.UnitTypeName,
                "testValue": mar.testValue,
                "VariableTypeName": mar.VariableTypeName,
                "TaxFlowValue": "MSRPFlow"
            }
        ]);
        let headers = new Headers({
            'Content-Type':
            'application/json; charset=utf-8'
        });
        let options = new RequestOptions({ headers: headers });
        return this._http.put(this.serverurl + this._UpdateVariable, body, options)
            .map(res => <Errorlist[]>res.json())
            .catch(this.handleError);
  
} 
    DeleteVariable(variableId: string){
        //debugger
        var deleteByIdUrl = this.serverurl + this._DeleteVariable + '?variableId=' + variableId
       return this._http.delete(deleteByIdUrl)
           .map(res => <Errorlist[]>res.json())
           .catch(this.handleError);
    }
    private handleError(error: Response) {
        return Observable.throw(error.json().error || 'Oops!! Server error');
    }
}