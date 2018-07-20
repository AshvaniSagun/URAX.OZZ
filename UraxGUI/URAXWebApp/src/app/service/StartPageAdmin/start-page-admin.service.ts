import { Injectable, Component } from '@angular/core';
import { Http, Request, RequestMethod, Response, RequestOptions, Headers } from '@angular/http';
import 'rxjs/Rx';
import { Observable } from 'rxjs/Observable';
import { StartPageAdmin, ContentType, StartPageAdminpreview } from '../../model/StartPageAdmin/start-page-admin';
import { apiurlmodel } from '../../model/api-url.model';
import { shareddataservice, Errorlist } from '../shared/shared.service'
import { Subscription } from 'rxjs';

@Component({
    providers: [Http]
})
@Injectable()
export class StartPageAdminService {
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
    public _updateUrl: string = 'MaterialNews/UpdateBaseMaterialNews';
    public _delete: string = 'MaterialNews/Delete';
    public _contenttypedropdown: string = 'Parameter/Get';
    public _StartPageAdmindetails: string = 'MaterialNews/GetCurrentMaterialNews';
    public _StartPageAdmindetailschangedd: string = 'MaterialNews/GetMaterialNewsByContentTypeID';
    public _startpagesave: string = 'MaterialNews/PostBaseMaterialNews'
    public _previewOrderby: string = 'MaterialNews/PostPreviewMaterialNews'
    public _GetHomeMaterialNews: string = 'MaterialNews/GetHomeMaterialNews'


    public GetContentTypeD(id: any): Observable<ContentType[]> {
        return this._http.get(this.serverurl + this._contenttypedropdown + '?id=' + id)
            .map(res => <ContentType[]>res.json())
            .catch(this.handleError);
    }


    public getStartPageAdmindetails(): Observable<StartPageAdmin[]> {
        //debugger
        return this._http.get(this.serverurl + this._StartPageAdmindetails)
            .map(res => <StartPageAdmin[]>res.json())
            .catch(this.handleError);
    }

    //HomeNews
    public gethomenews(): Observable<StartPageAdmin[]> {
        //debugger
        return this._http.get(this.serverurl + this._GetHomeMaterialNews)
            .map(res => <StartPageAdmin[]>res.json())
            .catch(this.handleError);
    }

    public getloadcontenttype(contentid:any): Observable<StartPageAdmin[]> {
        //debugger
        return this._http.get(this.serverurl + this._StartPageAdmindetailschangedd + '?ContentTypeID=' + contentid)
            .map(res => <StartPageAdmin[]>res.json())
            .catch(this.handleError);
    }

    public uploadImage(formdata: any) {
       
        return this._http.post(this.serverurl + this._startpagesave, formdata)
            .catch(this.handleError);
    }

    //preview

    public previewGet(contentid: any): Observable<StartPageAdmin[]> {
        //debugger
        return this._http.get(this.serverurl + this._StartPageAdmindetailschangedd + '?ContentTypeID=' + contentid)
            .map(res => <StartPageAdmin[]>res.json())
            .catch(this.handleError);
    }
   

  
    //Post
    SaveStartPageDetails(mar: StartPageAdmin, imageData: any, imageName:any) {
        let body = JSON.stringify(
            {
                "mnId": 0,
                "contentTypeId": mar.contentTypeId,
                "ContentHeading": mar.contentHeading,
                "contextText": mar.contextText,
                "publishStartDate": mar.publishStartDate,
                "publishEndDate": mar.publishEndDate,
                "imageUrl": mar.imageUrl,
                "imageName": "",
                "imageData": mar.ImageData,
                "isActive": mar.isActive,
                "createdBy": this.loginuser,
                "createdOn": this._shareddataservice.getdate(),
                "updatedBy": this.loginuser,
                "updatedOn": this._shareddataservice.getdate(),

            }
        );
        let headers = new Headers({
            'Content-Type':
            'application/json; charset=utf-8'
        });
        let options = new RequestOptions({ headers: headers });
        return this._http.post(this.serverurl + this._startpagesave, body, options)
            .map(res => <Errorlist[]>res.json())
            .catch(this.handleError);
    }

//PreviewStartpage

    public preview(pr: StartPageAdmin, imageData: any, imageName: any): Observable<StartPageAdminpreview[]> {
        let body = JSON.stringify(
            {
                "mnId": 0,
                "contentTypeId": pr.contentTypeId,
                "contentTypeName": pr.contentTypeName,
                "ContentHeading": pr.contentHeading,
                "contextText": pr.contextText,
                "publishStartDate": pr.publishStartDate,
                "publishEndDate": pr.publishEndDate,
                "imageUrl": pr.imageUrl,
                "imageName": '',
                "isActive": pr.isActive,
                "createdBy": this.loginuser,
                "createdOn": this._shareddataservice.getdate(),
                "updatedBy": this.loginuser,
                "updatedOn": this._shareddataservice.getdate(),
                "ImageData": pr.ImageData
            }
        );

        let headers = new Headers({
            'Content-Type':
            'application/json; charset=utf-8'
        });
        let options = new RequestOptions({ headers: headers });
        return this._http.post(this.serverurl + this._previewOrderby, body, options)
            .map(res => {
                <StartPageAdminpreview[]>res.json()
            })
            .catch(this.handleError);
    }
    //PUT
    UpdateStartPageDetails(mar: StartPageAdmin, imageData: any) {

        let body = JSON.stringify(
            {
                "mnId": mar.mnId,
                "contentTypeId": mar.contentTypeId,
                "contentHeading": mar.contentHeading,
                "contextText": mar.contextText,
                "publishStartDate": mar.publishStartDate,
                "publishEndDate": mar.publishEndDate,
                "imageUrl": mar.imageUrl,
                "imgeName": mar.imageName,
                "imageData": mar.ImageData,
                "isActive": mar.isActive,
                "createdBy": this.loginuser,
                "createdOn": this._shareddataservice.getdate(),
                "updatedBy": this.loginuser,
                "updatedOn": this._shareddataservice.getdate(),
            }
        );
        let headers = new Headers({
            'Content-Type':
            'application/json; charset=utf-8'
        });
        let options = new RequestOptions({ headers: headers });
       
        return this._http.put(this.serverurl + this._updateUrl, body, options)
            .map(res => <Errorlist[]>res.json())
            .catch(this.handleError);
    }

    //DELETE
    DeleteStartPageDetails(id: string): Observable<StartPageAdmin[]> {
        //debugger
        var deleteByIdUrl = this.serverurl + this._delete +'?MaterialNewsId=' + id
        return this._http.delete(deleteByIdUrl)
            .map(res => <StartPageAdmin[]>res.json())
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        return Observable.throw(error.json().error || 'Oops!! Server error');
    }


}
