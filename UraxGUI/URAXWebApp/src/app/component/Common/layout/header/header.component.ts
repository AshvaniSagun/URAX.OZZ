import { Component, OnInit } from '@angular/core';
import { shareddataservice } from '../../../../service/shared/shared.service'
import { Observable } from 'rxjs/Observable';
import { Subscription } from 'rxjs';
import { AdalService } from 'ng2-adal/dist/core';
@Component({
  selector: 'urax-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class headerComponent implements OnInit {
    public USER: any
    private subscription: Subscription;

    constructor(public _shareddataservice: shareddataservice, private adalService: AdalService) {
        this.subscription = this._shareddataservice.LoginuserEvent.subscribe((newValue: any) => {
            this.USER = newValue
        })

    }

  ngOnInit() {
  }
  public logOut() {
      this.adalService.logOut();
  }
}
