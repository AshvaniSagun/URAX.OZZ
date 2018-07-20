import { Component, OnInit, Input, EventEmitter, Directive } from '@angular/core';
import { taxadminmenuservice } from '../../../service/TaxAdministration/add-version/tax-admin-menu/tax.admin.menu.servic'
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
@Component({
  selector: 'urax-add-version',
  templateUrl: './add-version.component.html',
  styleUrls: ['./add-version.component.css'],
  providers: [taxadminmenuservice],
})
export class AddVersionComponent implements OnInit {

    constructor() { }
    
  ngOnInit() {
  }
   
}
