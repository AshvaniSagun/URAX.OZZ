import { Component, OnInit } from '@angular/core';
declare var $: any;
import { shareddataservice } from '../../../service/shared/shared.service'
import { Subscription } from 'rxjs';

@Component({
    selector: 'Tax-search',
    templateUrl: './tax-search.component.html',
    styleUrls: ['./tax-search.component.css']
})
export class TaxsearchComponent implements OnInit {
    hidden: boolean = false;
    private subscription: Subscription;

    constructor(public _shareddataservice: shareddataservice) {
        //this.subscription = this._shareddataservice.LoadingstartEvent.subscribe((newValue: any) => {
        //    this.show();

        //})
        //this.subscription = this._shareddataservice.LoadingendEvent.subscribe((newValue: any) => {
        //    this.hide();

        //})
    }

    ngOnInit() {

    }
    public addmarket() {
        $('.urax-display').css('display', 'block');
        $(".urax-values").css('display', 'none');
    }
    //public show() {
    //    this.hidden = true;
    //    $('.overlay, #popupid4').css('display', 'block');
    //}
    //public hide() {
    //    this.hidden = false;
    //    $('#popupid4').fadeOut("fast");
    //    $('.overlay, #popupid4').css('display', 'none');
    //}
    public Edit() {
        $('.overlay, #popupid2').css('display', 'block');
    }

    //public BackToHome() {
    //    $('section h1').css('display', 'none');

    //    $('.newscontent').css('display', 'block');
    //    $('.fixedParameters').css('display', 'block');
    //    $('.startPageAdmin').css('display', 'none');
    //    $('section .sub-heading').css('display', 'none');
    //    $('section .sectioncontainer').css('display', 'none');
    //    $('.showText').css('display', 'block');
    //    $('.content').css('display', 'block');
    //    $(".urax").addClass("leftstyle");
    //    var now = new Date();
    //    var day = ("0" + now.getDate()).slice(-2);
    //    var month = ("0" + (now.getMonth() + 1)).slice(-2);
    //    var today = (day) + "/" + (month) + "/" + now.getFullYear();
    //    $('#datepicker2').val(today);
    //}


}
