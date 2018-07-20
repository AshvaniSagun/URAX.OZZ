import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MainComponent } from './layout/main/main.component'
import { headerComponent } from './layout/header/header.component'
import { MenuComponent } from './layout/menu/menu.component'
import { taxadminstrationModule } from '../tax-Administration/tax-Administration.module'
import { startpageadminModule } from '../start-page-admin/start-page-admin.module'
import { pno12Module } from '../pno12-fixed-parameter/pno12.module'

 @NgModule({
     imports: [taxadminstrationModule, startpageadminModule, CommonModule, FormsModule, pno12Module ],
     declarations: [MainComponent, headerComponent, MenuComponent ],
    providers: [],
    exports: [MainComponent]
})
export class commonModule { }

        