import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { commonModule } from './component/Common/common.module';
import { pno12Module } from './component/pno12-fixed-parameter/pno12.module';
import { startpageadminModule } from './component/Start-Page-Admin/start-page-admin.module';
import { taxadminstrationModule } from './component/Tax-Administration/Tax-Administration.module';
import { useradminstrationModule } from './component/User-Administration/user-administration.module';
import { InputTextModule, DataTableModule, ButtonModule, DialogModule, SharedModule, TooltipModule, DropdownModule } from 'primeng/primeng';
//import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; 
//import { Ng2AutoCompleteModule } from 'ng2-auto-complete'
import { AdalService } from 'ng2-adal/dist/core';
import { SecretService } from './service/secret.service';


@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule, commonModule, pno12Module, startpageadminModule, TooltipModule, DropdownModule, DialogModule, taxadminstrationModule, SharedModule,useradminstrationModule,InputTextModule, DataTableModule, ButtonModule
    ],
    providers: [AdalService, SecretService
    ],
    declarations: [AppComponent
    ],
    bootstrap: [AppComponent,]
})
export class AppModule {
    

}
