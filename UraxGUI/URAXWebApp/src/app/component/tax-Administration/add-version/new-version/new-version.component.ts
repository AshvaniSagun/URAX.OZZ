import { Component, OnInit, Input } from '@angular/core';
import { NewVersion, ddlpricebaselist, ddlvatrelationlist } from '../../../../model/tax-administration/add-version/new-version/NewVersion.model';
import { Addnewversionservice } from '../../../../service/TaxAdministration/add-version/new-version/new-version.service'
import { Observable } from 'rxjs/Observable';
import { Subscription } from 'rxjs';
import { shareddataservice, Errorlist } from '../../../../service/shared/shared.service'
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
declare var JQuery: any;
declare var $: any;
//---------Declare Components---------
@Component({
    selector: 'urax-add-new-version',
    templateUrl: './new-version.component.html',
    providers: [Addnewversionservice]
})

//---------Export This Component Class---------
export class NewVersionComponent implements OnInit {

    public newversion: NewVersion[];
    public _NewVersionDetails: NewVersion;
    public _NewVersionDetailsnew: NewVersion[];
    public _NewVersionDetailstemp: NewVersion[];

    public ddlpricebase: ddlpricebaselist[];
    public ddlvatrelation: ddlvatrelationlist[];
    public ddlversionstatus: ddlvatrelationlist[];

    public taxid: any;
    public taxMasterId: any;
    public taxVersionId: any;
    public taxcountryid: any
    public marketId: any;
    private subscription: Subscription;
    public TaxAction: string;
    public startdate: string;
    public enddate: string;
    public errorlist: Errorlist[]
    public errorlistnew: Errorlist
    public iscopytax: boolean;
    public isnewversion: boolean;
    public ispricebase: boolean;
    public tax: boolean;
    public vatrate: boolean;
    public vvf: boolean;
    public vvt: boolean;
    public calorder: boolean;
    public pricebase: boolean;
    public TaxName: string;
    public Taxdetail: string;
    public versionstatus: boolean;
    public futertax: boolean;
    public versionvalidfrom: string;
    public versionvalidto: string;
    public taxstatus: boolean;
    public Taxname:string


    constructor(public _addnewversionservice: Addnewversionservice, public _shareddataservice: shareddataservice) {
        this.subscription = this._shareddataservice.TaxEvent.subscribe((newValue: any) => {
            this.marketId = newValue;
            this.setemptydata()
            this.getfieldactive()
            this.TaxAction = 'Save Tax'
            this.taxid = '0'
            this.taxVersionId = '0'
            this.taxMasterId = '0'
            this.TaxName = ''
            this.cleardata();
            this.taxstatus = false;


        })
        this.subscription = this._shareddataservice.TaxflowEvent.subscribe((newValue: any) => {
            this.taxMasterId = newValue;
            this.TaxAction = 'Update Tax'
            this.Gettaxflow(this.taxMasterId);
            this.taxstatus = false;
            

        })
        this.subscription = this._shareddataservice.TaxmarketidEvent.subscribe((newValue: any) => {
            this.marketId = newValue;
            this.setemptydata()
            this.getfieldactive()
            this.TaxAction = 'Save Tax'
            this.taxid = '0'
            this.taxVersionId = '0'
            this.taxMasterId = '0'
            this.TaxName = ''
            this.cleardata();
            this.taxstatus = false;


        })
        this.subscription = this._shareddataservice.TaxversionEvent.subscribe((newValue: any) => {
            this.taxVersionId = newValue;
            this.setemptydata()
            this.getfieldactive()
            this.TaxAction = 'Save Tax'
            this.taxMasterId = '0'
            this.TaxName = ''
            this.cleardata();
            this.taxstatus = false;


        })
        this.subscription = this._shareddataservice.TaxmarketCleardataEvent.subscribe((newValue: any) => {
            this.taxcountryid = newValue;
            this.setemptydata()
            this.getfieldactive()
            this.TaxAction = 'Save Tax'
            this.taxid = '0'
            this.taxVersionId = '0'
            this.taxMasterId = '0'
            this.TaxName = ''
            this.cleardata();
            this.taxstatus = false;


        })

        this.subscription = this._shareddataservice.languageEvent.subscribe((newValue: any) => {
            this.taxid = newValue;
            this.setemptydata()
            this.getfieldactive()
            this.TaxAction = 'Save Tax'
            this.taxVersionId = '0'
            this.taxMasterId = '0'
            this.TaxName = ''
            this.cleardata();
            this.taxstatus = false;


        })
    }
    public cleardata() {
        try {
            this.setemptydata()
        } catch (e) {

        }
    }

    ngOnInit() {
        try {
            this.TaxAction = 'Save Tax'
            this.setemptydata()
            this.GetPriceDrop();
            this.GetVatDrop();
            this.Taxdetail = "Tax Name"
            this.getfieldactive();
            this.selectdate(this._NewVersionDetails);
            this.selectdate1(this._NewVersionDetails);
            this.Gettaxversionstatus()
        } catch (e) {

        }
    }
    public setemptydata() {
        try {
            this._NewVersionDetails = new NewVersion();
            this._NewVersionDetails.taxName = ''
            this._NewVersionDetails.vatRelation = '0'
            this._NewVersionDetails.versionValidFrom = ''
            this._NewVersionDetails.versionValidUpto = ''
            this._NewVersionDetails.priority = ''
            this._NewVersionDetails.priceBase = '0'
            this._NewVersionDetails.createdBy = ''
            this._NewVersionDetails.createdOn = ''
            this._NewVersionDetails.updatedBy = ''
            this._NewVersionDetails.updatedBy = ''
            this._NewVersionDetails.featureLevelTax = false
            this._NewVersionDetails.taxVersionStatusId = '0';
            this.versionvalidfrom = ''
            this.versionvalidto = ''

        } catch (e) {

        }
    }
    public getfieldactive() {
        try {
            this.tax = false
            this.vatrate = false
            this.vvf = false
            this.vvt = false
            this.calorder = false
            this.pricebase = false
            this.versionstatus = false
            this.futertax = false

        } catch (e) {

        }

    }
    public addversionfieldactive() {
        try {
            this.tax = true
            this.vatrate = true
            this.vvf = false
            this.vvt = false
            this.calorder = true
            this.pricebase = false
            this.versionstatus = false
            this.futertax = false
        } catch (e) {

        }

    }
    public copytaxfieldactive() {
        try {
            this.tax = false
            this.vatrate = true
            this.vvf = false
            this.vvt = false
            this.calorder = true
            this.pricebase = true
            this.versionstatus = false
            this.futertax = true
            

        } catch (e) {

        }
    }
    public addpricebasefieldactive() {
        try {
            this.tax = true
            this.vatrate = true
            this.vvf = true
            this.vvt = true
            this.calorder = true
            this.pricebase = false
            this.versionstatus = false
            this.futertax = true

        } catch (e) {

        }
    }
    public selectdate(model: any) {
        try {

            $("#datepicker").dcalendarpicker({
                format: 'yyyy-mm-dd',

            });
        } catch (e) {

        }

    }
    public selectdate1(model: any) {
        try {
            $("#datepicker1").dcalendarpicker({
                format: 'yyyy-mm-dd',

            });
        } catch (e) {

        }

    }
    public reloadtax() {
        this.getfieldactive()
        this.iscopytax = false
        this.TaxAction = "Update Tax"
        this.Taxdetail = "Tax Name"
        this.Gettaxflow(this.taxMasterId);

    }
    private Gettaxflow(Id: any) {
        this._addnewversionservice.Gettaxflow(Id).subscribe(
            taxf => {
                this.taxstatus = false;
                this._NewVersionDetailsnew = taxf
                this._NewVersionDetails = this._NewVersionDetailsnew[0]
                this.TaxName = this._NewVersionDetails.taxName;
                this.versionvalidfrom = this._NewVersionDetails.versionValidFrom
                this.versionvalidto = this._NewVersionDetails.versionValidUpto
                if (this._NewVersionDetails.taxVersionStatusId == "31") {
                    this.diseabledata(true, this.versionvalidto,"31")
                    // this.taxstatus = false
                    this._shareddataservice.Settaxstaus(false);
                }
                else {
                    this.diseabledata(false, this.versionvalidto,"32")
                    this.taxstatus = false
                    this._shareddataservice.Settaxstaus(true);

                }
            },
            error => {

            }
        );
    }
    private diseabledata(action: boolean,vervto:any,statusid:any)
    {
        try {
            this.tax = action
            this.vatrate = action
            this.vvt = action
            if (vervto == "" && statusid=="31" ) {
                this.vvf = !action
                this.taxstatus = false

            }
            else {
                this.vvf = action
                this.taxstatus = true

            }
            this.calorder = action
            this.pricebase = action
            this.versionstatus = action
            this.futertax = action

        } catch (e) {

        }
    }
    private Gettaxversionstatus() {
        this._addnewversionservice.Gettaxstatusdd().subscribe(
            status => {
                this.ddlversionstatus = status
            },
            error => {

            }
        );
    }
    public copytax(model: NewVersion) {
        try {
            var validate = true;
            this.errorlist = [];
            if (this.taxcountryid == '0' || typeof this.taxcountryid === 'undefined') {
                var errorlist = new Errorlist("", "Please select the Country.");
                this.errorlist.push(errorlist);
                validate = false
            }
            if (this.marketId == '0' || typeof this.marketId === 'undefined') {
                var errorlist = new Errorlist("", "Please select the Tax Territory.");
                this.errorlist.push(errorlist);
                validate = false
            }
            if (this.taxid == '0' || typeof this.taxid === 'undefined') {
                var errorlist = new Errorlist("", "Please select the Tax.");
                this.errorlist.push(errorlist);
                validate = false
            }
            if (this.taxVersionId == '0' || typeof this.taxVersionId === 'undefined') {
                var errorlist = new Errorlist("", "Please select Tax Version");
                this.errorlist.push(errorlist);
                validate = false
            }
            if (!validate) {
                this._shareddataservice.Error(this.errorlist)

            }
            else {
                this.copytaxfieldactive()
                this.cleardata();
                this._NewVersionDetails.taxName = this.TaxName;
                this._NewVersionDetails.taxVersionStatusId = '30';
                this.Taxdetail = "Copy Tax Name"
                this.TaxAction = "Save Copy Tax"

            }

        }
        catch (e) {

        }

    }
    public Addnewversion(model: NewVersion) {
        try {
            var validate = true;
            this.errorlist = [];
            if (this.taxcountryid == '0' || typeof this.taxcountryid === 'undefined') {
                var errorlist = new Errorlist("", "Please select the Country.");
                this.errorlist.push(errorlist);
                validate = false
            }
            if (this.marketId == '0' || typeof this.marketId === 'undefined') {
                var errorlist = new Errorlist("", "Please select the Tax Territory.");
                this.errorlist.push(errorlist);
                validate = false
            }
            if (this.taxid == '0' || typeof this.taxid === 'undefined') {
                var errorlist = new Errorlist("", "Please select the Tax.");
                this.errorlist.push(errorlist);
                validate = false
            }
            if (!validate) {
                this._shareddataservice.Error(this.errorlist)

            }
            else {
                this.addversionfieldactive()
                model.vatRelation = '0'
                model.versionValidFrom = ''
                model.versionValidUpto = ''
                model.priority = ''
                model.priceBase = '0'
                model.createdBy = ''
                model.createdOn = ''
                model.updatedBy = ''
                model.updatedBy = ''
                model.featureLevelTax = false
                model.taxVersionStatusId = '0';
                this.versionvalidfrom = ''
                this.versionvalidto = ''
                this.Taxdetail = "Tax Name"
                this.TaxAction = "Save New Version"

            }

        }
        catch (e) {

        }


    }
    public Addpricebase(model: NewVersion) {
        try {
            var validate = true;
            this.errorlist = [];
            if (this.taxcountryid == '0' || typeof this.taxcountryid === 'undefined') {
                var errorlist = new Errorlist("", "Please select the Country.");
                this.errorlist.push(errorlist);
                validate = false
            }
            if (this.marketId == '0' || typeof this.marketId === 'undefined') {
                var errorlist = new Errorlist("", "Please select the Tax Territory.");
                this.errorlist.push(errorlist);
                validate = false
            }
            if (this.taxid == '0' || typeof this.taxid === 'undefined') {
                var errorlist = new Errorlist("", "Please select the Tax.");
                this.errorlist.push(errorlist);
                validate = false
            }
            if (this.taxVersionId == '0' || typeof this.taxVersionId === 'undefined') {
                var errorlist = new Errorlist("", "Please select the Tax Version.");
                this.errorlist.push(errorlist);
                validate = false
            }
            if (!validate) {
                this._shareddataservice.Error(this.errorlist)

            }
            else {
                this.addpricebasefieldactive()
                this.cleardata();
                this.Taxdetail = "Tax Name"
                this.TaxAction = "Save Price Base"
            }

        }
        catch (e) {

        }

    }
    public Addnewtax(model: NewVersion) {
        try {
            var validate = true;
            this.errorlist = [];
            if (this.taxcountryid == '0' || typeof this.taxcountryid === 'undefined') {
                var errorlist = new Errorlist("", "Please select the Country.");
                this.errorlist.push(errorlist);
                validate = false
            }
            if (this.marketId == '0' || typeof this.marketId === 'undefined') {
                var errorlist = new Errorlist("", "Please select the Tax Territory.");
                this.errorlist.push(errorlist);
                validate = false
            }
            if (!validate) {
                this._shareddataservice.Error(this.errorlist)

            }
            else {
                this.getfieldactive()
                this.cleardata();
                this.Taxdetail = "Tax Name"
                this.TaxAction = "Save Tax"
            }

        }
        catch (e) {

        }

    }

    public GetPriceDrop() {
        this._addnewversionservice.GetPriceDrop().subscribe(
            data => { this.ddlpricebase = data }, errr => {
            }
        );
    }

    public GetVatDrop() {
        this._addnewversionservice.GetVatDrop().subscribe(
            data => this.ddlvatrelation = data
        );


    }
    public validationnewversion(m: NewVersion, mid: any, taxid: any) {
        try {
            var validate = true;
            this.errorlist = [];
            if (this.taxcountryid == '0' || typeof this.taxcountryid === 'undefined') {
                var errorlist = new Errorlist("", "Please select the Country.");
                this.errorlist.push(errorlist);
                validate = false
            }
            if (this.marketId == '0' || typeof this.marketId === 'undefined') {
                var errorlist = new Errorlist("", "Please select the Tax Territory.");
                this.errorlist.push(errorlist);
                validate = false
            }

            if (taxid == '0' || typeof taxid === 'undefined') {
                var errorlist = new Errorlist("", "Please select the Tax Name.");
                this.errorlist.push(errorlist);
                validate = false
            }
            if (this.versionvalidfrom == '' || typeof this.versionvalidfrom === 'undefined') {
                var errorlist = new Errorlist("", "Please select the Version Valid From.");
                this.errorlist.push(errorlist);
                validate = false
            }
            if (m.priceBase == 'undefined' || m.priceBase == '' || m.priceBase == null || m.priceBase == '0') {
                var errorlist = new Errorlist("", "Please select the Price Base.");
                this.errorlist.push(errorlist);
                validate = false
            }
            if (m.taxVersionStatusId == 'undefined' || m.taxVersionStatusId == '' || m.taxVersionStatusId == null || m.taxVersionStatusId == '0') {
                var errorlist = new Errorlist("", "Please select  Tax Version Status");
                this.errorlist.push(errorlist);
                validate = false
            }

            //if (this.versionvalidto == '' || typeof this.versionvalidto === 'undefined') {
            //    var errorlist = new Errorlist("", "Please select the version valid to.");
            //    this.errorlist.push(errorlist);
            //    validate = false
            //}
            if (!validate) {
                this._shareddataservice.Error(this.errorlist)

            }
            return validate;

        } catch (e) {
        }

    }
    public validationpricebase(taxname: string, mid: any, taxmasterid: any) {
        try {
            var validate = true;

            return validate;

        } catch (e) {

        }

    }
    public validation(m: NewVersion, mid: any, ) {
        var validate = true;
        this.errorlist = [];
        if (this.taxcountryid == '0' || typeof this.taxcountryid === 'undefined') {
            var errorlist = new Errorlist("", "Please select the Country.");
            this.errorlist.push(errorlist);
            validate = false
        }
        if (this.marketId == '0' || typeof this.marketId === 'undefined') {
            var errorlist = new Errorlist("", "Please select the Tax Territory.");
            this.errorlist.push(errorlist);
            validate = false
        }
        if (typeof m.taxName.replace(/^\s+|\s+$/g, "") === 'undefined' || m.taxName.replace(/^\s+|\s+$/g, "") == '' || typeof m.taxName.replace(/^\s+|\s+$/g, "") === null) {
            var errorlist = new Errorlist("", "Please provide the Tax Name.");
            this.errorlist.push(errorlist);
            validate = false
        }
        if (m.priceBase == 'undefined' || m.priceBase == '' || m.priceBase == null || m.priceBase == '0') {
            var errorlist = new Errorlist("", "Please select the Price Base.");
            this.errorlist.push(errorlist);
            validate = false
        }
        if (m.priority == '0') {
            var errorlist = new Errorlist("", "Calculation Order should not be 0.");
            this.errorlist.push(errorlist);
            validate = false
        }
        if (m.vatRelation == 'undefined' || m.vatRelation == '' || m.vatRelation == null || m.vatRelation == '0') {
            var errorlist = new Errorlist("", "Please select the VAT Relation.");
            this.errorlist.push(errorlist);
            validate = false
        }
        if (typeof m.priority == 'undefined' || m.priority == '' || typeof m.priority == null) {
            var errorlist = new Errorlist("", "Please provide the Calculation Order.");
            this.errorlist.push(errorlist);
            validate = false
        }
        if (m.versionValidFrom == '' && this.versionvalidfrom == '' || typeof this.versionvalidfrom == 'undefined') {
            var errorlist = new Errorlist("", "Please provide the 'Version Valid From' date.");
            this.errorlist.push(errorlist);
            validate = false
        }
        if (m.taxVersionStatusId == 'undefined' || m.taxVersionStatusId == '' || m.taxVersionStatusId == null || m.taxVersionStatusId == '0') {
            var errorlist = new Errorlist("", "Please select  Tax Version Status");
            this.errorlist.push(errorlist);
            validate = false
        }
        if (this.taxstatus == true) {
            var errorlist = new Errorlist("", "Tax status is in publish state it cannot be updated");
            this.errorlist.push(errorlist);
            validate = false
        }

        if (!validate) {
            this._shareddataservice.Error(this.errorlist)

        }
        return validate;
    }
    public validationcopytax(taxname: string, mid: any, taxid: any) {
        var validate = true;
        this.errorlist = [];
        if (this.TaxName == taxname) {
            var errorlist = new Errorlist("", "Copy tax name cannot be same with the existing tax name.");
            this.errorlist.push(errorlist);
            validate = false
        }
        if (taxname == "") {
            var errorlist = new Errorlist("", "Copy tax name cannot be empty.");
            this.errorlist.push(errorlist);
            validate = false
        }
        if (this.taxcountryid == '0' || typeof this.taxcountryid === 'undefined') {
            var errorlist = new Errorlist("", "Please select the Country.");
            this.errorlist.push(errorlist);
            validate = false
        }
        if (this.marketId == '0' || typeof this.marketId === 'undefined') {
            var errorlist = new Errorlist("", "Please select the Tax Territory.");
            this.errorlist.push(errorlist);
            validate = false
        }
        if (taxid == '0' || typeof taxid === 'undefined') {
            var errorlist = new Errorlist("", "Please select Tax");
            this.errorlist.push(errorlist);
            validate = false
        }
        if (this.taxVersionId == '0' || typeof this.taxVersionId === 'undefined') {
            var errorlist = new Errorlist("", "Please select Tax Version");
            this.errorlist.push(errorlist);
            validate = false
        }
        if (this.versionvalidfrom == '' && this.versionvalidfrom == '' || typeof this.versionvalidfrom == 'undefined') {
            var errorlist = new Errorlist("", "Please provide the 'Version Valid From' date.");
            this.errorlist.push(errorlist);
            validate = false
        }
        if (!validate) {
            this._shareddataservice.Error(this.errorlist)
        }
        return validate;

    }
    public SaveVersionDetails(model: NewVersion) {
        this.versionvalidfrom = ($("#datepicker").val());
        this.versionvalidto = ($("#datepicker1").val());
        model.versionValidFrom = this.versionvalidfrom
        model.versionValidUpto = this.versionvalidto
        model.taxName = (model.taxName.trim())
        if (this.TaxAction == "Update Tax") {
            if (this.validation(model, this.marketId)) {
                this._shareddataservice.loadingstart("true");
                this._addnewversionservice.Updateversiondetails(model, this.taxid, this.taxMasterId, this.taxVersionId, this.marketId, )
                    .subscribe(
                    version => {
                        this.errorlist = version;
                        this._shareddataservice.loadingend(true)
                        for (var i = 0; i < this.errorlist.length; i++) {
                            if (this.errorlist[i].errormsg.toString().trim() != '') {
                                var erlist = new Errorlist("", this.errorlist[i].successmsg.toString())
                                this.errorlist.push(erlist);
                                this._shareddataservice.Error(this.errorlist);
                                this._shareddataservice.loadingend(true)

                            }
                            else if (this.errorlist[i].successmsg.toString().trim() != '') {
                                this._shareddataservice.Sucess("New Version Tax details are updated successfully.")
                                this._shareddataservice.updatetaxmaster(this.taxcountryid, this.marketId, this.taxid, this.taxVersionId, this.taxMasterId)
                                this._shareddataservice.loadingend(true)
                                // this._shareddataservice.Addnemarkettax(this.marketId)

                            }
                            break;
                        }

                    },
                    Error => {
                        //this._shareddataservice.Error(Error);
                        this._shareddataservice.loadingend(false)
                    }
                    );
            }

        }
        else if (this.TaxAction == "Save Tax") {
            if (this.validation(model, this.marketId)) {

                this._shareddataservice.loadingstart("true");
                this._addnewversionservice.SaveVersionDetails(model, this.taxid, this.taxMasterId, this.taxVersionId, this.marketId)
                    .subscribe(
                    version => {
                        this.errorlist = []
                        this.errorlist = version;
                        for (var i = 0; i < this.errorlist.length; i++) {

                            if (this.errorlist[i].errormsg.toString().trim() != '') {
                                var erlist = new Errorlist("", this.errorlist[i].successmsg.toString())
                                this.errorlist.push(erlist);
                                this._shareddataservice.Error(this.errorlist);
                                this._shareddataservice.loadingend(true)

                            }
                            else if (this.errorlist[i].successmsg.toString().trim() != '') {
                                this._shareddataservice.Sucess("New Version Tax details are saved successfully.")
                                this._shareddataservice.updatetaxmaster(this.taxcountryid, this.marketId, 0, 0, 0)
                                this._shareddataservice.loadingend(true)
                                //this._shareddataservice.Addnemarkettax(this.marketId)
                                this._shareddataservice.loadingend(true)

                            }
                            break;
                        }
                    },
                    Error => {
                        this._shareddataservice.loadingend(false)
                    }
                    );
            }

        }
        else if (this.TaxAction == "Save Copy Tax") {
            if (this.validationcopytax(model.taxName, this.marketId, this.taxid)) {
                this._shareddataservice.loadingstart("true");
                this._addnewversionservice.savecopytax(model, this.marketId, this.taxid, this.taxVersionId)
                    .subscribe(
                    version => {
                        this.errorlist = []
                        this.errorlist = version;
                        for (var i = 0; i < this.errorlist.length; i++) {

                            if (this.errorlist[i].errormsg.toString().trim() != '') {
                                var erlist = new Errorlist("", this.errorlist[i].successmsg.toString())
                                this.errorlist.push(erlist);
                                this._shareddataservice.Error(this.errorlist);
                                this._shareddataservice.loadingend(true)

                            }
                            else if (this.errorlist[i].successmsg.toString().trim() != '') {
                                this._shareddataservice.Sucess(this.errorlist[i].successmsg.toString().trim())
                                this._shareddataservice.updatetaxmaster(this.taxcountryid, this.marketId, 0, 0, 0)

                                //this._shareddataservice.Addnemarkettax(this.marketId)
                                this.iscopytax = false
                                this._shareddataservice.loadingend(true)

                            }
                            break;
                        }
                    },
                    Error => {
                        this._shareddataservice.loadingend(false)
                    }
                    );
            }

        }
        else if (this.TaxAction == "Save New Version") {
            if (this.validationnewversion(model, this.marketId, this.taxid)) {
                this._shareddataservice.loadingstart("true");
                this._addnewversionservice.validationdata(model, this.taxid, this.taxVersionId, this.versionvalidfrom, this.versionvalidto)
                    .subscribe(
                    version => {
                        this.errorlist = []
                        this.errorlist = version;
                        this._shareddataservice.loadingend("false")
                        for (var i = 0; i < this.errorlist.length; i++) {

                            if (this.errorlist[i].errormsg.toString().trim() != '') {
                                var erlist = new Errorlist("", this.errorlist[i].successmsg.toString())
                                this.errorlist.push(erlist);
                                this._shareddataservice.Error(this.errorlist)
                                this._shareddataservice.loadingend(true)

                            }
                            else if (this.errorlist[i].successmsg.toString().trim() != '') {
                                var IsConf = confirm(this.errorlist[i].successmsg.toString().trim());
                                if (IsConf) {
                                    this.savenewversion(model, this.taxid, this.taxVersionId, this.versionvalidfrom, this.versionvalidto)
                                }
                                else {
                                    this._shareddataservice.loadingend(false)
                                }
                                
                            }
                            else if (this.errorlist[i].successmsg.toString().trim() == '' && this.errorlist[i].errormsg.toString().trim() == '' ) {
                               
                                    this.savenewversion(model, this.taxid, this.taxVersionId, this.versionvalidfrom, this.versionvalidto)

                            }
                            break;
                        }
                    },
                    Error => {
                        this._shareddataservice.loadingend(false)
                    }
                    );
            }

        }
        else if (this.TaxAction == "Save Price Base") {
            if (this.validationpricebase(model.taxName, this.marketId, this.taxid)) {
                this._shareddataservice.loadingstart("true");
                this._addnewversionservice.savepricebase(this.taxid, this.taxVersionId, model.priceBase)
                    .subscribe(
                    version => {
                        this.errorlist = []
                        this.errorlist = version;
                        for (var i = 0; i < this.errorlist.length; i++) {

                            if (this.errorlist[i].errormsg.toString().trim() != '') {
                                var erlist = new Errorlist("", this.errorlist[i].successmsg.toString())
                                this.errorlist.push(erlist);
                                this._shareddataservice.Error(this.errorlist);
                                this._shareddataservice.loadingend(true)

                            }
                            else if (this.errorlist[i].successmsg.toString().trim() != '') {
                                this._shareddataservice.Sucess("New Price Base is added successfully.")
                                this._shareddataservice.updatetaxmaster(this.taxcountryid, this.marketId, this.taxid, this.taxVersionId, 0)
                                // this._shareddataservice.Addnemarkettax(this.marketId)
                                this.iscopytax = false
                                this._shareddataservice.loadingend(true)

                            }
                            break;
                        }
                    },
                    Error => {
                        this._shareddataservice.loadingend(false)
                    }
                    );
            }

        }

    }

    public savenewversion(model: NewVersion, taxid: any, taxVersionId: any, vvf: any, vvt: any)
    {
        try {
            this._addnewversionservice.SaveVersion(model, this.taxid, this.taxVersionId, this.versionvalidfrom, this.versionvalidto)
                .subscribe(
                version => {
                    this.errorlist = []
                    this.errorlist = version;
                    this._shareddataservice.loadingend("false")
                    for (var i = 0; i < this.errorlist.length; i++) {

                        if (this.errorlist[i].errormsg.toString().trim() != '') {
                            var erlist = new Errorlist("", this.errorlist[i].successmsg.toString())
                            this.errorlist.push(erlist);
                            this._shareddataservice.Error(this.errorlist)
                            this._shareddataservice.loadingend(true)

                        }
                        else if (this.errorlist[i].successmsg.toString().trim() != '') {
                            this._shareddataservice.Sucess(this.errorlist[i].successmsg.toString().trim())
                            //this._shareddataservice.Addnemarkettax(this.marketId)
                            this._shareddataservice.updatetaxmaster(this.taxcountryid, this.marketId, this.taxid, 0, 0)
                            this.iscopytax = false
                            this._shareddataservice.loadingend(true)
                        }
                        break;
                    }
                },
                Error => {
                    this._shareddataservice.loadingend(false)
                }
                );

        } catch (e) {

        }

    }

    public Cancel(model: NewVersion) {
        try {
            model.priceBase = '';
            model.priority = '';
            model.taxName = '';
            model.vatRelation = '';
            model.versionValidFrom = '';
            model.versionValidUpto = '';


        } catch (e) {

        }

    }







}






