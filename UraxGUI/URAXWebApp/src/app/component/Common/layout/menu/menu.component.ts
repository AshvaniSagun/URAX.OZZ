import { Component, OnInit } from '@angular/core';
declare var JQuery: any;
declare var $: any;
import { shareddataservice, Errorlist } from '../../../../service/shared/shared.service'

@Component({
    selector: 'urax-menu',
    templateUrl: './menu.component.html',
    styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

    constructor(public _shareddataservice: shareddataservice) { }

  ngOnInit() {
  }
  public countrymangae() {
      $('.blockBg p').click(function (e:any) {

          $('.blockBg p').removeClass('selected');
          $(this).addClass('selected');
      }); 
      $('.container-leftcontent').css('display', 'none');
      $('.urax-display').css('display', 'block');
      $('section h1').css('display', 'block');
    //  $('section h1').css('font-size', '38px');
      $('.newscontent').css('display', 'none');
      $('.fixedParameters').css('display', 'none');
      $('.startPageAdmin').css('display', 'none');
      $('section .sub-heading').css('display', 'block');
      $('section .sectioncontainer').css('display', 'block');
      $('.showText').css('display', 'none');
      $('.content').css('display', 'block');
      $(".urax").addClass("leftstyle");
      $('.urax-display').css('display', 'block');
      $(".urax-values").css('display', 'none');
      $(".manage-tax-territory").css('display', 'block');
      $(".manage-tax").css('display', 'none');
      $('.PNO12').css('display', 'none');

      this._shareddataservice.navigationcleardatamarket("reset");
      
  }
  public taxadmin() {
      $('.blockBg p').click(function (e: any) {

          $('.blockBg p').removeClass('selected');
          $(this).addClass('selected');
      });
      $('section h1').css('display', 'block');
    //  $('section h1').css('font-size', '38px');
      $('.newscontent').css('display', 'none');
      $('.PNO12').css('display', 'none');
      $('.fixedParameters').css('display', 'none');
      $('.startPageAdmin').css('display', 'none');
      $('section .sub-heading').css('display', 'block');
      $('section .sectioncontainer').css('display', 'block');
      $('.showText').css('display', 'none');
      $('.content').css('display', 'block');
      $(".urax").addClass("leftstyle");
      $('.container-leftcontent').css('display', 'block');
      $(".urax-values").css('display', 'none');
      $('.urax-display').css('display', 'none');
      $(".manage-tax-territory").css('display', 'none');
      $(".manage-tax").css('display', 'block');
      this._shareddataservice.navigationcleardata("reset")

    }
  public startpageadmin() {
      $('.blockBg p').click(function (e: any) {

          $('.blockBg p').removeClass('selected');
          $(this).addClass('selected');
      });
        $('section h1').css('display', 'block');
    //    $('section h1').css('font-size', '38px');
        $('.newscontent').css('display', 'none');
        $('.fixedParameters').css('display', 'none');
        $('.startPageAdmin').css('display', 'block');
        $('section .sub-heading').css('display', 'block');
        $('section .sectioncontainer').css('display', 'block');
        $('.showText').css('display', 'none');
        $('.content').css('display', 'none');
        $(".urax").addClass("leftstyle");
        $('.PNO12').css('display', 'none');
        var now = new Date();
        var day = ("0" + now.getDate()).slice(-2);
        var month = ("0" + (now.getMonth() + 1)).slice(-2);
        var today = now.getFullYear() + "-" + (month) + "-" + (day);
        $('#datepicker2').val(today); 

    }


  public PNO12() {
      $('.blockBg p').click(function (e: any) {

          $('.blockBg p').removeClass('selected');
          $(this).addClass('selected');
      });
        $('section h1').css('display', 'block');
     //   $('section h1').css('font-size', '38px');
        $('.under').css('display', 'block');
        $('.newscontent').css('display', 'none');
        $('.fixedParameters').css('display', 'none');
        $('.startPageAdmin').css('display', 'none');
        $('.PNO12').css('display', 'block');
        $('section .sub-heading').css('display', 'none');
        $('section .sectioncontainer').css('display', 'block');
        $('.showText').css('display', 'block');
        $('.content').css('display', 'none');
        $(".urax").addClass("leftstyle");
       
    }



  public Manageusers() {
      $('.blockBg p').click(function (e: any) {

          $('.blockBg p').removeClass('selected');
          $(this).addClass('selected');
      });
        $('section h1').css('display', 'block');
     //   $('section h1').css('font-size', '38px');
        $('.under').css('display', 'block');
        $('.newscontent').css('display', 'none');
        $('.fixedParameters').css('display', 'none');
        $('.startPageAdmin').css('display', 'none');
        $('.PNO12').css('display', 'none');
        $('section .sub-heading').css('display', 'none');
        $('section .sectioncontainer').css('display', 'block');
        $('.showText').css('display', 'block');
        $('.content').css('display', 'none');
        $(".urax").addClass("leftstyle");
      
    }

  public BackToHome() {
      $('.blockBg p').click(function (e: any) {

          $('.blockBg p').removeClass('selected');
          $(this).addClass('selected');
      });
        $('section h1').css('display', 'block');
        //$('section h1').css('font-size', '38px');
        $('.newscontent').css('display', 'block');
        $('.fixedParameters').css('display', 'block');
        $('.startPageAdmin').css('display', 'none');
        $('section .sub-heading').css('display', 'block');
        $('section .sectioncontainer').css('display', 'none');
        $('.showText').css('display', 'block');
        $('.content').css('display', 'block');
        $(".urax").addClass("leftstyle");
        $('.PNO12').css('display', 'none');
    }
}
