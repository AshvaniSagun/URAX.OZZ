import { Component } from '@angular/core';
import { shareddataservice } from './service/shared/shared.service';
import { SecretService } from "./service/secret.service";
import { AdalService } from "ng2-adal/dist/services/adal.service";

@Component({
    selector: 'my-app',
    template: '<urax-main></urax-main>',
})
export class AppComponent {

    name = 'welcome to URAX ';
    public User:any
    ngOnInit() {
        
        this.adalService.handleWindowCallback();
        this.adalService.getUser();
        if (this.adalService.userInfo.isAuthenticated) {

            this.User = this.adalService.userInfo.userName;
            var user = this.User
            this.User = user.split("@")[0];
            this._shareddataservice.loginuserset(this.User)
        }
        else if (!this.adalService.userInfo.isAuthenticated && this.adalService.userInfo.loginError != undefined )
        {
            alert("The signed in user is not assigned to a role for the URAX application. Please contact your system administrator.");
            window.location.href = 'https://login.microsoftonline.com/volvocars.onmicrosoft.com/oauth2/logout';

        }
        if (this.adalService.userInfo.profile == undefined && this.adalService.userInfo.loginError ==null ) {
            this.logIn();
        }
       

    }
    constructor(public _shareddataservice: shareddataservice,
        private adalService: AdalService,
        private secretService: SecretService,
    )
    {
        this.adalService.init(this.secretService.adalConfig);
    }
   
    public logIn() {
        this.adalService.login();
    }
}