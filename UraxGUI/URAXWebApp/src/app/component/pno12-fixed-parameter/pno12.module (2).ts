import { NgModule } from '@angular/core';

//@NgModule({
//    imports: [],
//    exports: [],
//    declarations: [],
//    providers: [],
//})

import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { InputTextModule, DataTableModule, ButtonModule, DialogModule, SliderModule, TooltipModule,DropdownModule, MultiSelectModule } from 'primeng/primeng';

import { PNO12FixedParameterComponent } from './pno12-fixed-parameter.component'

@NgModule({
    imports: [CommonModule, FormsModule, InputTextModule, DataTableModule, ButtonModule, TooltipModule,DialogModule, SliderModule, DropdownModule, MultiSelectModule],
    declarations: [PNO12FixedParameterComponent],
    providers: [],
    exports: [PNO12FixedParameterComponent]
}) 
export class pno12Module { }
