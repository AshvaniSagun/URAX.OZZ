import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { StartPageAdminService } from '../../service/StartPageAdmin/start-page-admin.service';
import { StartPageAdmin, ContentType, StartPageAdminpreview } from '../../model/StartPageAdmin/start-page-admin';
import { Subscription } from 'rxjs';
import { shareddataservice, Errorlist } from '../../service/shared/shared.service';
declare var JQuery: any;
declare var $: any;
@Component({
    selector: 'app-start-page-admin',
    templateUrl: './start-page-admin.component.html',
    styleUrls: ['./start-page-admin.component.css'],
    providers: [StartPageAdminService]
})
export class StartPageAdminComponent implements OnInit {

    public base64textString: string
    public ContentHeading: string
    public ContentTypeId: string
    public ContextText: string
    public PublishStartDate: string
    public PublishEndDate: string
    public ImageUrl: string
    public imageName: string
    public imageData: string
    public isActive: string
    public createdBy: string
    public createdOn: string
    public updatedBy: string
    public updatedOn: string
    public action: string;
    public errorlist: Errorlist[]
    public isadd: boolean;
    public startdate: string;
    public enddate: string;
    private elem: ElementRef
    private subscription: Subscription;
    public publishStartDate: string;
    public publishEndDate: string;
    public selectedvalue: string; 
    public base64: string; 
    public selectedRow: Number;
    constructor(public _StartpageAdminservice: StartPageAdminService, public _shareddataservice: shareddataservice) {
        this.subscription = this._shareddataservice.cleardataevent.subscribe((newValue: any) => {
            this.cleardata();
        })
    }
    public StartPageAdminlist: StartPageAdmin[];
    public tempStartPageAdminlist : StartPageAdmin[];

    public PreviewStart: StartPageAdmin[]; 
    public PreviewStartpopup: StartPageAdminpreview[]; 

    public spam: StartPageAdmin;
    public clear: StartPageAdmin;
    public ContentDropdown: ContentType[];
    public Errorlist: string[]
    public setvalue: string
    public loadeditorallow: boolean
    public StartPageAdminlisttemp: StartPageAdmin[];

    ngOnInit() {
       
        this.isadd = true;
        this.StartPageAdminlist = [];
        new StartPageAdmin();
        this.action = "Save";
        this.spam = new StartPageAdmin();
        this.spam.contentTypeId = '0'
        this.clear = new StartPageAdmin();
        this.getStartPageAdmindetails();
        this.GetContentType(7);
        this.setvalue = ''
        this.selectdate(this.spam);
        this.selectdate1(this.spam);
        this.loadeditorallow = true
        this.selectedvalue = "0"
        this.imageData = '';
        $("#txtEditor").Editor();
        var now = new Date();
        var day = ("0" + now.getDate()).slice(-2);
        var month = ("0" + (now.getMonth() + 1)).slice(-2);
        var today = now.getFullYear() + "-" + (month) + "-" + (day);
        $('#datepicker2').val(today);
     
    }
    public cleardata() {
        try {
            this.isadd = true;
            this.StartPageAdminlist = [];
            new StartPageAdmin();
            this.action = "Save";
            this.spam = new StartPageAdmin();
            this.clear = new StartPageAdmin();
            this.getStartPageAdmindetails();
            this.GetContentType(7);
            this.setvalue = ''
            this.imageData = null
        } catch (e) {

        }
    }
    public preview() {
        this._shareddataservice.loadnewscontent("load");
        $('.overlay, #popupid').css('display', 'block');
        $('.newscontent').css('display', 'block');
    }
    public selectdate(model: StartPageAdmin) {
        try {
            $("#datepicker2").dcalendarpicker({
                format: 'yyyy-mm-dd',

            });

        } catch (e) {

        }

    }

    //public setClickedRow(index:any) {
    //    try {
    //        this.selectedRow = index;

    //    } catch (e) {

    //    }

    //}
    public selectdate1(model: StartPageAdmin) {
        try {
            $("#datepicker3").dcalendarpicker({
                format: 'yyyy-mm-dd',

            });
        } catch (e) {

        }

    }
    private GetContentType(id: any) {
        this._StartpageAdminservice.GetContentTypeD(id).subscribe(
            contenttypes => this.ContentDropdown = contenttypes
        );
    }

    private getStartPageAdmindetails() {
        this._shareddataservice.loadingstart("true");
        this._StartpageAdminservice.getStartPageAdmindetails().subscribe(
            admin => {
            this.StartPageAdminlist = admin
            this.tempStartPageAdminlist = admin}
          
        );
          
        
    }
    private loadcontenttype(contentid: any) {

        this.selectedvalue = contentid;
        this.StartPageAdminlist = this.tempStartPageAdminlist;
        this.StartPageAdminlist = this.StartPageAdminlist.filter(p => p.contentTypeId == contentid)
       
    }
    private Setvalue(contentid: any) {

        this.setvalue = contentid
    }
    private loadeditor() {
        if (this.loadeditorallow) {
            $("#txtEditor").Editor();
            this.loadeditorallow = false
        }
    }

    //converting image to base64 and getting the name 
    handleFileSelect(evt: any) {
        var validate = true;
        this.errorlist = [];
        var files = evt.target.files;
        var file = files[0];
       // this.imageName = file.name;
        var fileType = file["type"];
        var ValidImageTypes = ["image/jpeg"];
        this.imageData = null
        $(this).base64img({
            url: evt.target.files[0],
            result: '#result'
            
        });
      
        //else {
            if (files && file) {
                var reader = new FileReader();
                reader.onload = this._handleReaderLoaded.bind(this);
                reader.readAsBinaryString(file);
                this.imageName = file.name;

            }
        
        //if (!validate) {
        //    this._shareddataservice.Error(this.errorlist)

        //}

    }
    public _handleReaderLoaded(readerEvt: any) {
        var binaryString = readerEvt.target.result;
        this.base64textString = ''
        this.base64textString = 'data:image/jpeg;base64,'
        this.base64textString = this.base64textString + btoa(binaryString);
        this.imageData = btoa(binaryString);
    }

    public validation(m: StartPageAdmin, listm: StartPageAdmin[], contentTypeId: any, contentHeading: any, isupdate: boolean) {
        var validate = true;
        this.errorlist = [];

        var dateRegex = /^(?=\d)(?:(?:31(?!.(?:0?[2469]|11))|(?:30|29)(?!.0?2)|29(?=.0?2.(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(?:\x20|$))|(?:2[0-8]|1\d|0?[1-9]))([-.\/])(?:1[012]|0?[1-9])\1(?:1[6-9]|[2-9]\d)?\d\d(?:(?=\x20\d)\x20|$))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$/;
        this.startdate = new Date(m.publishStartDate, ).toString();

        this.enddate = new Date(m.publishEndDate).toString();


        if (this.startdate == "Invalid Date" && m.publishStartDate != '') {
            var errorlist = new Errorlist("", "Please enter valid Publish Start Date.");
            this.errorlist.push(errorlist);
            validate = false

        }

        if (typeof m.contentTypeId === 'undefined' || m.contentTypeId == '' || typeof m.contentTypeId === null || m.contentTypeId == '0') {
            var errorlist = new Errorlist("", "Please provide the Content Type.");
            this.errorlist.push(errorlist);
            validate = false
        }

        if (typeof this.publishStartDate === 'undefined' || m.publishStartDate == '' || typeof m.publishStartDate === null) {
            var errorlist = new Errorlist("", "Please provide the Publish Start Date.");
            this.errorlist.push(errorlist);
            validate = false
        }

        if (typeof m.isActive === 'undefined' || m.isActive == '' || typeof m.isActive === null || this.setvalue == '0') {
            var errorlist = new Errorlist("", "Please select Active.");
            this.errorlist.push(errorlist);
            validate = false
        }
       

        if (typeof m.contentHeading == 'undefined' || m.contentHeading.trim() == '' || typeof m.contentHeading == null) {
            var errorlist = new Errorlist("", "Please provide the Content Heading.");
            this.errorlist.push(errorlist);
            validate = false
        }


        if (typeof m.contextText === 'undefined' || m.contextText.trim() == '' || typeof m.contextText === null) {
            var errorlist = new Errorlist("", "Please provide the Content Text.");
            this.errorlist.push(errorlist);
            validate = false
        }

        if (!validate) {
            this._shareddataservice.Error(this.errorlist)

        }
        return validate;
    }

    //Preview
   public previewStart(model: StartPageAdmin) {

        var Textcontent = $('#txtEditor').Editor("getText")
        model.contextText = Textcontent
        model.ImageData = $("#result").text();
        model.publishStartDate = this.publishStartDate
        model.publishEndDate = this.PublishEndDate
       // model.ImageData = this.base64textString;
        model.mnId = "0";
       this._shareddataservice.previewpopup(model);

    }

    public SaveStartPageDetails(model: StartPageAdmin, listm: StartPageAdmin[]) {
        this.publishStartDate = ($("#datepicker2").val());
        this.PublishEndDate = ($("#datepicker3").val());
        model.publishStartDate = this.publishStartDate
        model.publishEndDate = this.PublishEndDate
        model.ImageData = $("#result").text();
        var Textcontent = $('#txtEditor').Editor("getText")
        model.contextText = Textcontent
        if (this.validation(model, listm, model.contentTypeId, model.contentTypeName, false)) {
            this._shareddataservice.loadingstart("true");
            if (this.action == "Save") {
                this._StartpageAdminservice.SaveStartPageDetails(model, this.imageData, this.imageName)
                    .subscribe(
                    res => {
                        this.errorlist = res;
                        for (var i = 0; i < this.errorlist.length; i++) {
                            if (this.errorlist[i].errormsg.toString().trim() != '') {
                                var erlist = new Errorlist("", this.errorlist[i].successmsg.toString())
                                this.errorlist.push(erlist);
                                this._shareddataservice.Error(this.errorlist);
                                this._shareddataservice.loadingend(true)

                            }
                            else if (this.errorlist[i].successmsg.toString().trim() != '') {
                                this.cancel(model);
                                // this.StartPageAdminlist = res
                                this.getStartPageAdmindetails();
                                $("#result").text("");
                                this._shareddataservice.Sucess("Start Page details are saved successfully.")
                                $("#txtEditor").Editor("setText", "");
                                this._shareddataservice.loadingend(true)
                                this._shareddataservice.loadnewscontent("load")

                            }
                            break;
                        }
                       
                    }
                    , error => {
                        this._shareddataservice.Error(error)
                        this._shareddataservice.loadingend(false)

                    });

            }
            else {
                this._StartpageAdminservice.UpdateStartPageDetails(model, this.imageData, )
                    .subscribe(response => {
                        this.errorlist = response;
                        for (var i = 0; i < this.errorlist.length; i++) {
                            if (this.errorlist[i].errormsg.toString().trim() != '') {
                                var erlist = new Errorlist("", this.errorlist[i].successmsg.toString())
                                this.errorlist.push(erlist);
                                this._shareddataservice.Error(this.errorlist);
                                this._shareddataservice.loadingend(true)
                            }
                            else if (this.errorlist[i].successmsg.toString().trim() != '') {
                                this.cancel(model);
                                this.getStartPageAdmindetails();
                                $("#txtEditor").Editor("setText", "");
                                this._shareddataservice.loadingend(true)
                                $("#result").text("");
                                this._shareddataservice.Sucess("Start Page details are updated successfully.")
                                this._shareddataservice.loadnewscontent("load")
                            }
                            break;
                        }
                    }
                    , error => {
                        this._shareddataservice.Error(error)
                        this._shareddataservice.loadingend(false)
                    });

                this.action = "Save";
                this.spam = this.clear
            }
        }
    }
    public editVariable(m: StartPageAdmin, index: any) {
        $("html, body").animate({ scrollTop: 0 }, "slow");
        this.selectedRow = index;
        this.spam = m;
        $("#txtEditor").Editor("setText", m.contextText);
        this.action = "Update";
        m.showupdate = true;
        // m.cancel = true;
        m.showEdit = false;
        //m.showEdit = m.showEdit ? false : true;
        if (m.publishEndDate == "0001-01-01T00:00:00")
        {

            m.publishEndDate = '';
        }
        

    }
    public cancel(m: StartPageAdmin) {
        this.publishStartDate = "";
        this.PublishEndDate = "";
        $("#fileButton").val("");
        $("#datepicker2").val("");
        $("#datepicker3").val("")
        $("#txtEditor").Editor("setText", "");
        m.showEdit = false;
        m.cancel = false;
        m.showupdate = false;
        this.action = "Save";
        this.spam = new StartPageAdmin();
        this.selectedRow = -1;
        $("#result").text("");
    }
    public Reset(m: StartPageAdmin[]) {
        this.spam = this.clear;


    }
    // Delete
    public DeleteStartPageDetails(item: StartPageAdmin) {
        var IsConf = confirm('You are about to delete ' + item.contentTypeName + '. Are you sure?');
        if (IsConf) {
            this._shareddataservice.loadingstart("true");
            this._StartpageAdminservice.DeleteStartPageDetails(item.mnId)
                .subscribe(resp => {
                    this.getStartPageAdmindetails();
                    this._shareddataservice.Sucess(item.contentTypeName + '  "' + item.contentHeading + '" is deleted successfully.');
                    this.cancel(item);
                    this._shareddataservice.loadingend(true)
                    this._shareddataservice.loadnewscontent("load")

                }, error => {
                    this.getStartPageAdmindetails();
                    this.cancel(item);
                    this._shareddataservice.loadingend(false)
                    this._shareddataservice.loadnewscontent("load")

                }
                );
        }
    }
    public BackToHome() {
        $('section h1').css('display', 'none');
        $('.newscontent').css('display', 'block');
        $('.fixedParameters').css('display', 'block');
        $('.startPageAdmin').css('display', 'none');
        $('section .sub-heading').css('display', 'none');
        $('section .sectioncontainer').css('display', 'none');
        $('.showText').css('display', 'block');
        $('.content').css('display', 'block');
        $(".urax").addClass("leftstyle");
        //var now = new Date();
        //var day = ("0" + now.getDate()).slice(-2);
        //var month = ("0" + (now.getMonth() + 1)).slice(-2);
        //var today = now.getFullYear() + "-" + (month) + "-" + (day);
        //$('#datepicker2').val(today);
    }

}

