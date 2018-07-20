import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import {StartPageAdminComponent } from './start-page-admin.component'

@NgModule({
    imports: [CommonModule, FormsModule],
    declarations: [StartPageAdminComponent],
    providers: [],
    exports: [StartPageAdminComponent]
})
export class startpageadminModule { }
