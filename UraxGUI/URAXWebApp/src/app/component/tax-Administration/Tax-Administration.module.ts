import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { TaxAdminMenuComponent } from './tax-admin-menu/tax-admin-menu.component'
import { AddMarketComponent } from './Add-market/add-market.component'
import { TaxsearchComponent } from './tax-search/tax-search.component'
import {AddVersionComponent } from './add-version/add-version.component'
import { NewVersionComponent } from './add-version/new-version/new-version.component'
import { AddLanguageComponent } from './add-version/add-language/add-language.component'
import { AddVariableComponent } from './add-version/add-variable/add-variable.component'
import { AddlookupComponent } from './add-version/add-lookup/add-lookup.component'
import { AddFormulaComponent } from './add-version/add-formula/add-formula.component'
import { shareddataservice } from '../../service/shared/shared.service'
import { AddVariableService } from '../../service/TaxAdministration/add-version/add-variable/addvariable.service.'
//import { Ng2AutoCompleteModule } from 'ng2-auto-complete'
@NgModule({
    imports: [CommonModule, FormsModule],
    declarations: [TaxAdminMenuComponent, AddMarketComponent,  TaxsearchComponent, AddVersionComponent,
        NewVersionComponent, AddLanguageComponent, AddVariableComponent, AddlookupComponent, AddFormulaComponent],
    providers: [shareddataservice, AddVariableService],
    exports: [TaxAdminMenuComponent, AddMarketComponent, TaxsearchComponent, AddVersionComponent, NewVersionComponent]
})
export class taxadminstrationModule {
}
