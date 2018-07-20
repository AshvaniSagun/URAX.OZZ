import { Injectable, Component } from '@angular/core';
import { Http, Request, RequestMethod, Response, RequestOptions, Headers } from '@angular/http';
import 'rxjs/Rx';
import { Observable } from 'rxjs/Observable';
import { lookupmodel, lookupdetails, lookupvariable, LookupGroupModel, lookupdparameterdd, GridVariable, GridData, GridHeader, groupdatalist, lookuprangetypedd } from '../../../../model/tax-administration/add-version/add-lookup/lookup.model';
import { shareddataservice, Errorlist } from '../../../shared/shared.service'
import { apiurlmodel } from '../../../../model/api-url.model';
import { Subscription } from 'rxjs';

@Component({
    providers: [Http]
})

@Injectable()
export class addLookupService {
    public headers: Headers;
    public subscription: Subscription;
    public loginuser: string
    constructor(private _http: Http, public _shareddataservice: shareddataservice) {
        this.subscription = this._shareddataservice.LoginuserEvent.subscribe((Loginuser: any) => {
            this.loginuser = Loginuser;
        })
    }
    public _apiurlmodel = new apiurlmodel();
   // public loginuser: string = this._apiurlmodel.loginuser;
    public serverurl: string = this._apiurlmodel.apiurl;
    public _getlookupvariablename: string = 'Variables/GetDependencyParameter';
    public _GetLookuprangetype: string = 'Parameter/Get?Id=4';
    public _lookupvariabledetails: string = 'LookUpGroup/GetLookUpGroup'
    public _lookupgroupsave: string = 'LookUpGroup/AddLookUpGroup'
    public _lookupgroupsavedata: string = 'LookupDetail/InsertGridRowData'
    public _lookupgroupdetails: string = 'LookUpGroupDetail/GetDatabyLookupGroupId'
    public _lookupgroupdelete: string = 'LookupDetail/DeleteGridRowData?lookUpGroup='
    public _lookupgroupupdatedata: string = 'LookupDetail/UpdateGridRowData'
    public _lookupvariabledatasave: string = 'LookUpGroupDetail/InsertGridVariables'
    public lookupvariabledataupdate: string = 'LookUpGroupDetail/UpdateGridVariables'
    public _lookupvarabledatadelete: string = 'LookUpGroupDetail/DeleteGridVariables?lookupgroupdetailId='
    public _lookupgroupnamedelete: string = 'LookUpGroup/Delete?lookupgroupid='
    public _updtaelookupgroupname: string = 'lookupgroup/updatelookupgroup?lookupgroupId='


    public GetLookupGroup(TaxFlowId: any): Observable<LookupGroupModel[]> {
        //to get lookup variable details
        return this._http.get(this.serverurl + this._lookupvariabledetails + '?TaxFlowId=' + TaxFlowId)
            .map(res => <LookupGroupModel[]>res.json())
            .catch(this.handleError);
    }
    public GetLookuovariablename(TaxFlowId: any): Observable<lookupdparameterdd[]> {
        return this._http.get(this.serverurl + this._getlookupvariablename + '?TaxFlowId=' + TaxFlowId)
            .map(res => <lookupdparameterdd[]>res.json())
            .catch(this.handleError);
    }
    public GetLookuprangetype(): Observable<lookuprangetypedd[]> {
        return this._http.get(this.serverurl + this._GetLookuprangetype)
            .map(res => <lookuprangetypedd[]>res.json())
            .catch(this.handleError);
    }

    Savelookup(taxMasterId: any, variabletypeid: any, rangetypeid: any, lokupgroupname: any) {

        let body = JSON.stringify([
            {
                "lookUpGroupId": 0,
                "taxId": taxMasterId,
                "lookupgroupName": lokupgroupname,
                "isActive": true,
                "createdBy": this.loginuser,
                "createdOn": this._shareddataservice.getdate(),
                "updatedBy": this.loginuser,
                "updatedOn": this._shareddataservice.getdate(),
                "VariableIds": variabletypeid,
                "RangeTypeId": rangetypeid
            },

        ]);
        let headers = new Headers({
            'Content-Type':
            'application/json; charset=utf-8'
        });
        let options = new RequestOptions({ headers: headers });
        return this._http.post(this.serverurl + this._lookupgroupsave, body, options)
            .map(res => <Errorlist[]>res.json())
            .catch(this.handleError);
    }
    Savelookupgroupdata(dataList: groupdatalist[]) {

        let body = JSON.stringify([
            {
                dataList

            },

        ]);
        let headers = new Headers({
            'Content-Type':
            'application/json; charset=utf-8'
        });
        let options = new RequestOptions({ headers: headers });
        return this._http.post(this.serverurl + this._lookupgroupsavedata, body, options)
            .map(res => <Errorlist[]>res.json())
            .catch(this.handleError);
    }
    Updatelookupgroupdata(dataList: groupdatalist[]) {

        let body = JSON.stringify([
            {
                dataList

            },

        ]);
        let headers = new Headers({
            'Content-Type':
            'application/json; charset=utf-8'
        });

        let options = new RequestOptions({ headers: headers });
        return this._http.put(this.serverurl + this._lookupgroupupdatedata, body, options)
            .map(res => <Errorlist[]>res.json())
            .catch(this.handleError);
    }
    Deletelookupgroupdata(dataList: groupdatalist, lookupgroupid: string): Observable<groupdatalist[]> {
        //debugger
        var deleteByIdUrl = this.serverurl + this._lookupgroupdelete + dataList.GroupId + '&&lookUpGroupId=' + lookupgroupid
        return this._http.delete(deleteByIdUrl)
            .map(res => <string>res.json())
            .catch(this.handleError);
    }


    Savevariabledata(dataList: GridVariable, lookupgroupid: string) {
        let body = JSON.stringify([
            {
                "lookUpGroupDetailId": 1,
                "lookUpGroupId": lookupgroupid,
                "variableId": dataList.variableId,
                "variableName": "",
                "variableTypeName": "",
                "lookUpRangeTypeId": dataList.lookUpRangeId,
                "isActive": true,
                "createdBy": this.loginuser,
                "createdOn": this._shareddataservice.getdate(),
                "updatedBy": this.loginuser,
                "updatedOn": this._shareddataservice.getdate(),
            },

        ]);
        let headers = new Headers({
            'Content-Type':
            'application/json; charset=utf-8'
        });
        let options = new RequestOptions({ headers: headers });
        return this._http.post(this.serverurl + this._lookupvariabledatasave, body, options)
            .map(res => <Errorlist[]>res.json())
            .catch(this.handleError);
    }
    updatevariabledata(dataList: GridVariable, lookupgroupid: string) {

        let body = JSON.stringify([
            {
                "lookUpGroupDetailId": dataList.lookUpGroupDetailId,
                "lookUpGroupId": lookupgroupid,
                "variableId": dataList.variableId,
                "variableName": "",
                "variableTypeName": "",
                "lookUpRangeTypeId": dataList.lookUpRangeId,
                "isActive": true,
                "createdBy": this.loginuser,
                "createdOn": this._shareddataservice.getdate(),
                "updatedBy": this.loginuser,
                "updatedOn": this._shareddataservice.getdate(),

            },

        ]);
        let headers = new Headers({
            'Content-Type':
            'application/json; charset=utf-8'
        });

        let options = new RequestOptions({ headers: headers });
        return this._http.put(this.serverurl + this.lookupvariabledataupdate, body, options)
            .map(res => <any[]>res.json())
            .catch(this.handleError);
    }
    Deletevariabledata(dataList: GridVariable): Observable<lookupdetails[]> {
        //debugger
        var deleteByIdUrl = this.serverurl + this._lookupvarabledatadelete + dataList.lookUpGroupDetailId
        return this._http.delete(deleteByIdUrl)
            .map(res => <lookupdetails[]>res.json())
            .catch(this.handleError);
    }
    Deletelookuogroup(id: any): Observable<lookupdetails[]> {
        //debugger
        var deleteByIdUrl = this.serverurl + this._lookupgroupnamedelete + id
        return this._http.delete(deleteByIdUrl)
            .map(res => <any[]>res.json())
            .catch(this.handleError);
    }
    Updatelookupgroupname(id: any, lookupname: string, taxid: any) {

        let body = JSON.stringify([
            {

            },

        ]);
        let headers = new Headers({
            'Content-Type':
            'application/json; charset=utf-8'
        });
        let options = new RequestOptions({ headers: headers });
        var updtaelookupgroupname1 = this._updtaelookupgroupname + id + '&taxid=' + taxid + '&lookupgroupname=' + lookupname
        return this._http.put(this.serverurl + updtaelookupgroupname1, body, options)
            .map(res => <Errorlist[]>res.json())
            .catch(this.handleError);
    }


    public loadlookupdetals(lookupid: any): Observable<lookupdetails[]> {
        return this._http.get(this.serverurl + this._lookupgroupdetails + '?lookupgroupId=' + lookupid)
            .map(res => <lookupdetails[]>res.json())
            .catch(this.handleError);
    }
    private handleError(error: Response) {
        return Observable.throw(error.json().error || 'Oops!! Server error');
    }

}
