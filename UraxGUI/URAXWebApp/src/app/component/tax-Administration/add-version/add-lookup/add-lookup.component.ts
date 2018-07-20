import { Component, OnInit } from '@angular/core';
import { addLookupService } from '../../../../service/TaxAdministration/add-version/add-lookup/add-lookup.service';
import { lookupmodel, lookupdetails, lookupvariable, LookupGroupModel, lookupdparameterdd, GridVariable, GridData, GridHeader, groupdatalist, lookuprangetypedd } from '../../../../model/tax-administration/add-version/add-lookup/lookup.model';
import { Observable } from 'rxjs/Observable';
import { Subscription } from 'rxjs';
import { shareddataservice, Errorlist } from '../../../../service/shared/shared.service'
@Component({
    selector: 'urax-add-lookup',
    templateUrl: './add-lookup.component.html',
    styleUrls: ['./add-lookup.component.css'],
    providers: [addLookupService]
})
export class AddlookupComponent implements OnInit {
    public isadd: boolean;
    public errorlist: Errorlist[]
    public taxMasterId: any;
    public subscription: Subscription;
    public lokupgroupname: any
    public _lookupdetails: lookupdetails[];
    public _lookupdetailsheader: GridHeader[];
    public _lookupdetailsdetails: GridData[];
    public _lookupdetailsvariable: GridVariable[];
    public _groupdatalist: groupdatalist[];
    public variablid: string;
    public editlookupgroupname: boolean;
    public lookupgroupnameid: string;
    public taxstatus: boolean

    constructor(public _lookupservice: addLookupService, public _shareddataservice: shareddataservice) {
        this.subscription = this._shareddataservice.TaxflowEvent.subscribe((newValue: any) => {
           
            this.taxMasterId = newValue;
            this.cleardata();
            this.lookupgroupnameid='0'
            this.GetLookuoGroup(this.taxMasterId)
            this.GetLookuovariablename(this.taxMasterId)
            this.GetLookuprangetype();
        })
        this.subscription = this._shareddataservice.TaxstatusEvents.subscribe((newValue: any) => {
            this.taxstatus = newValue;
        })
        this.subscription = this._shareddataservice.VariablechangeEvent.subscribe((newValue: any) => {
            this.LookuoGroup = [];
            this._lookupdparameterdd=[]
            this.GetLookuovariablename(this.taxMasterId)
            this.GetLookuoGroup(this.taxMasterId)

        })
        this.subscription = this._shareddataservice.TaxmarketCleardataEvent.subscribe((newValue: any) => {
            this.cleardata();
        })
        this.subscription = this._shareddataservice.TaxmarketidEvent.subscribe((newValue: any) => {
            this.cleardata();

        })
        this.subscription = this._shareddataservice.languageEvent.subscribe((newValue: any) => {
            this.cleardata();

        })
        this.subscription = this._shareddataservice.TaxversionEvent.subscribe((newValue: any) => {
            this.cleardata();

        })
        //this.subscription = this._shareddataservice.ResetlookupEvent.subscribe((newValue: any) => {
        //    this.cleardata();
        //})
    }

    public lookupvariablelist: lookupvariable[];
    public lookupmodellist: lookupmodel[];
    public LookuoGroup: LookupGroupModel[];
    public TempLookuoGroup: LookupGroupModel[];
    public lookupgroupadd: LookupGroupModel[];
    public _lookupdparameterdd: lookupdparameterdd[];
    public _lookuprangetypedd: lookuprangetypedd[];
    public lookupgid: string;
    public lokupgroupnameupdate: string

    ngOnInit()
    {
           this.isadd = true;
           this.lookupgid = '0'
           this.lookupgroupnameid = '0'
            this._lookupdetailsvariable = []
            this.lookupgroupadd = []
            this._lookupdetailsdetails = []
            this._lookupdetailsheader = []
            this.taxstatus = false;

    }
    public cleardata() {
        try {
            this.lookupvariablelist = [];
            this.lookupmodellist=[];
            this.LookuoGroup=[];
            this.lookupgroupadd = [];
            this._lookupdetailsdetails=[]
            this._lookupdetailsheader = []
            this._lookupdetailsvariable = []
            this.lookupgroupnameid='0'
        } catch (e) {

        }
    }
    public GetLookuoGroup(taxmasterid: any) {
        this._lookupservice.GetLookupGroup(taxmasterid).subscribe(
            resp => {
                
            this.LookuoGroup = resp
                this.TempLookuoGroup = resp

            }
        );
    }
    public GetLookuovariablename(taxmasterid: any) {
        this._lookupservice.GetLookuovariablename(taxmasterid).subscribe(
            resp => {
                this._lookupdparameterdd = resp
            }
        );
    }
    public GetLookuprangetype() {
        this._lookupservice.GetLookuprangetype().subscribe(
            resp => {
                this._lookuprangetypedd = resp
            },
            error => {

            }
        );
    }
    //lookupgroup methods
    public Addnewlookupgroup() {
        if (this.isadd) {
            this.isadd = true;
        var objmarketmodel = new GridData();
        if (typeof this._lookupdetailsdetails == 'undefined') {
            this._lookupdetailsdetails = [];
            this._lookupdetailsdetails.unshift(objmarketmodel);
            objmarketmodel.showEdit = true;
            objmarketmodel.showupdate = false;
            objmarketmodel.cancel = true;
            objmarketmodel.isadd = true;
            objmarketmodel.showsave = true;
        }
        else {
            this._lookupdetailsdetails.unshift(objmarketmodel);
            objmarketmodel.showEdit = true;
            objmarketmodel.showupdate = false;
            objmarketmodel.cancel = true;
            objmarketmodel.isadd = true;
            objmarketmodel.showsave = true;

        }
    }
    };
   
    public Editlookupgroup(m: GridData) {
        if (this.isadd) {

            m.showupdate = true;
            m.cancel = true;
            m.showEdit = m.showEdit ? false : true;
            this.isadd = false;
        }

    }
    public validation(data: GridVariable,griddata: GridVariable[], isupdate: boolean,groupid:any) {
        var validate = true;
        this.errorlist = [];
        this._lookupdetailsvariable
        if ( groupid == '0' ) {
            var errorlist = new Errorlist("", "Please select the Look-up Group Name.");
            this.errorlist.push(errorlist);
            validate = false
        }
        if (data.variableId == 'undefined' || data.variableId == '' || data.variableId == null || data.variableId =='0') {
            var errorlist = new Errorlist("", "Please select the Variable Name.");
            this.errorlist.push(errorlist);
            validate = false
        }
        if (data.lookUpRangeId == 'undefined' || data.lookUpRangeId == '' || data.lookUpRangeId == null || data.lookUpRangeId == '0') {
            var errorlist = new Errorlist("", "Please select the Variable Type.");
            this.errorlist.push(errorlist);
            validate = false
        }

        if (true && griddata.length > 1 && data.variableId !== '' && data.lookUpGroupDetailId=='') {
            griddata = this._lookupdetailsvariable.filter(listm => listm.variableId === data.variableId && listm.lookUpGroupDetailId !== '')
            if (isupdate) {
                if (griddata.length > 1) {
                    var errorlist = new Errorlist('', "Variable already exists.");
                    this.errorlist.push(errorlist);
                    validate = false
                }

            }
            else {
                if (griddata.length > 0) {
                    var errorlist = new Errorlist('', "Variable already exists.");
                    this.errorlist.push(errorlist);
                    validate = false
                }

            }


        }
        if (!validate) {
            this._shareddataservice.Error(this.errorlist)
        }
        return validate;
    }
    public validationlookupdata(data: LookupGroupModel[], griddata: GridVariable[], isupdate: boolean, groupid: any,list:any) {
        var validate = true;
        this.errorlist = [];
        this._lookupdetailsvariable
        if (list == '') {
            var errorlist = new Errorlist("", "Look-up Group List is empty.");
            this.errorlist.push(errorlist);
            validate = false
        }
        if (this.lokupgroupname == 'undefined' || this.lokupgroupname.trim() == '' || this.lokupgroupname == null ) {
            var errorlist = new Errorlist("", "Please provide the Look-up Group Name.");
            this.errorlist.push(errorlist);
            validate = false
        }
        if (data.length<0) {
            var errorlist = new Errorlist("", "Please provide the Variable List.");
            this.errorlist.push(errorlist);
            validate = false
        }

       
        if (!validate) {
            this._shareddataservice.Error(this.errorlist)
        }
        return validate;
    }
    public savelookupgroupdata(m: GridData) {
        try {
            
            this._shareddataservice.loadingstart("true");

            this._groupdatalist = []
            for (let data of this._lookupdetailsheader) {
                var obj = new groupdatalist();
                obj.lookUpGroup = "0"
                obj.lookUpGroupId = this.lookupgid
                obj.variableId = data.variableId;
                obj.value = m[data.variableName]
                obj.LoginUser = "USER"
                this._groupdatalist.push(obj)
            }
            this._lookupservice.Savelookupgroupdata(this._groupdatalist)
                .subscribe(
                resp => {
                    this.errorlist = []
                    this.errorlist = resp;
                    for (var i = 0; i < this.errorlist.length; i++) {
                        if (this.errorlist[i].errormsg.toString().trim() != '') {
                            var erlist = new Errorlist("", this.errorlist[i].successmsg.toString())
                            this.errorlist.push(erlist);
                            this._shareddataservice.Error(this.errorlist);
                            this._shareddataservice.loadingend(true)
                        }
                        else if (this.errorlist[i].successmsg.toString().trim() != '') {
                            this.isadd = true;
                            this.lookupgroupadd = [];
                            m.showEdit = false;
                            m.showsave = false;
                            m.cancel = false
                            this.loadlookupdetals(this.lookupgid);
                            this._shareddataservice.Sucess("Look-up Group details are saved successfully.")
                            this._shareddataservice.loadingend(true)

                        }
                        break;
                    }

                },
                Error => {
                    //this._shareddataservice.Error(Error);
                    this.isadd = true;
                    this._shareddataservice.loadingend(false)

                }
                );

        }

        catch (e) {

        }
    }
    public Updatelookupgroupdata(m: GridData) {
        try {
            this._shareddataservice.loadingstart("true");
            this._groupdatalist = []
            for (let data of this._lookupdetailsheader) {
                var obj = new groupdatalist();
                obj.lookUpId = m.GroupId
                obj.lookUpGroup = m.GroupId
                obj.lookUpGroupId = this.lookupgid
                obj.variableId = data.variableId;
                obj.value = m[data.variableName]
                obj.LoginUser = "User"
                this._groupdatalist.push(obj)
            }
            this._lookupservice.Updatelookupgroupdata(this._groupdatalist)
                .subscribe(
                resp => {
                    this.errorlist = []
                    this.errorlist = resp;
                    for (var i = 0; i < this.errorlist.length; i++) {
                        if (this.errorlist[i].errormsg.toString().trim() != '') {
                            var erlist = new Errorlist("", this.errorlist[i].successmsg.toString())
                            this.errorlist.push(erlist);
                            this._shareddataservice.Error(this.errorlist);
                            this._shareddataservice.loadingend(true)
                        }
                        else if (this.errorlist[i].successmsg.toString().trim() != '') {
                            this.isadd = true;
                            this.lookupgroupadd = [];
                            m.showEdit = false;
                            m.showsave = false;
                            m.cancel = false
                            this.loadlookupdetals(this.lookupgid);
                            this._shareddataservice.Sucess("Look-up Group details are updated successfully.")
                            this._shareddataservice.loadingend(true)

                        }
                        break;
                    }

                },
                Error => {
                    //this._shareddataservice.Error(Error);
                    this.isadd = true;
                    this._shareddataservice.loadingend(false)

                }
                );

        }

        catch (e) {

        }
    }
    public Deletelookupgroupdata(dataList: groupdatalist) {
        var IsConf = confirm('You are about to delete record. Are you sure?');
        if (IsConf) {
            this._shareddataservice.loadingstart("true");
            this._lookupservice.Deletelookupgroupdata(dataList, this.lookupgid)
                .subscribe(resp => {
                    this.loadlookupdetals(this.lookupgid);
                    this._shareddataservice.Sucess("Look-up Group details are deleted successfully.")
                    this._shareddataservice.loadingend(true)

                }, error => {
                    this._shareddataservice.loadingend(false)
                }
                );
        }
    }
    public addNewVariabledata() {
        if (this.isadd) {
            this.isadd = false;
            var objmarketmodel = new GridVariable();
            if (typeof this._lookupdetailsvariable == 'undefined') {
                this._lookupdetailsvariable = [];
                this._lookupdetailsvariable.unshift(objmarketmodel);
                objmarketmodel.showEdit = true;
                objmarketmodel.showupdate = false;
                objmarketmodel.cancel = true;
                objmarketmodel.isadd = true;
                objmarketmodel.showsave = true;
            }
            else {
                this._lookupdetailsvariable.unshift(objmarketmodel);
                objmarketmodel.showEdit = true;
                objmarketmodel.showupdate = false;
                objmarketmodel.cancel = true;
                objmarketmodel.isadd = true;
                objmarketmodel.showsave = true;

            }
        }
    };
    public Editvariabledata(m: lookupmodel) {

        m.showupdate = true;
        m.cancel = true;
        m.showEdit = m.showEdit ? false : true;
        this.isadd = false;

    }
    public cancelvarabledata(m: lookupvariable) {
        if (m.isadd) {
            this.isadd = true;
             
            this._lookupdetailsvariable.shift();
        }
        else {
            m.showEdit = false;
            m.cancel = false;
            m.showupdate = false;
            this.isadd = true;
        }

    }
    public addnewlookupgroup() {
        if (this.isadd) {
            this.isadd = false;
            var objmarketmodel = new LookupGroupModel();
            if (typeof this.lookupgroupadd == 'undefined') {
                this.lookupgroupadd = [];
                this.lookupgroupadd.unshift(objmarketmodel);
                objmarketmodel.showEdit = true;
                objmarketmodel.showupdate = false;
                objmarketmodel.cancel = true;
                objmarketmodel.isadd = true;
                objmarketmodel.showsave = true;
                objmarketmodel.createdBy = ''
                objmarketmodel.createdOn = ''
                objmarketmodel.updatedBy = ''
                objmarketmodel.updatedOn = ''
            }
            else {
                this.lookupgroupadd.unshift(objmarketmodel);
                objmarketmodel.showEdit = true;
                objmarketmodel.showupdate = false;
                objmarketmodel.cancel = true;
                objmarketmodel.isadd = true;
                objmarketmodel.showsave = true;
                objmarketmodel.createdBy = ''
                objmarketmodel.createdOn = ''
                objmarketmodel.updatedBy = ''
                objmarketmodel.updatedOn = ''



            }
        }
    };
    public Savevariabledata(data: GridVariable) {
        try {
            if (this.validation(data, this._lookupdetailsvariable, false, this.lookupgid)) {

                this._shareddataservice.loadingstart("true");
                this._lookupservice.Savevariabledata(data, this.lookupgid)
                    .subscribe(
                    resp => {
                        this.errorlist = []
                        this.errorlist = resp;
                        for (var i = 0; i < this.errorlist.length; i++) {
                            if (this.errorlist[i].errormsg.toString().trim() != '') {
                                var erlist = new Errorlist("", this.errorlist[i].successmsg.toString())
                                this.errorlist.push(erlist);
                                this._shareddataservice.Error(this.errorlist);
                                this._shareddataservice.loadingend(true)
                            }
                            else if (this.errorlist[i].successmsg.toString().trim() != '') {
                                this.isadd = true;
                                //for (var i = 0; i < this._lookupdetails.length; i++) {
                                //    this._lookupdetailsheader = this._lookupdetails[i].gridHeader
                                //    this._lookupdetailsdetails = this._lookupdetails[i].gridData
                                //    this._lookupdetailsvariable = this._lookupdetails[i].gridVariable
                                //}
                                this.loadlookupdetals(this.lookupgid);
                                this._shareddataservice.Sucess("Look-up Group Variable is added successfully.")
                                this._shareddataservice.loadingend(true)
                            }
                            break;
                        }

                    },
                    Error => {
                        this.isadd = true;
                        this.loadlookupdetals(this.lookupgid);
                        this._shareddataservice.loadingend(false)
                    }
                    );

            }
        }
        catch (e) {

        }
    }
    public Updatevariabledata(model: GridVariable) {
        try {
            if (this.validation(model, this._lookupdetailsvariable, true, this.lookupgid)) {
                this._shareddataservice.loadingstart("true");
                this._lookupservice.updatevariabledata(model, this.lookupgid)
                    .subscribe(
                    resp => {
                        this.errorlist = []
                        this.errorlist = resp;
                        for (var i = 0; i < this.errorlist.length; i++) {
                            if (this.errorlist[i].errormsg.toString().trim() != '') {
                                var erlist = new Errorlist("", this.errorlist[i].successmsg.toString())
                                this.errorlist.push(erlist);
                                this._shareddataservice.Error(this.errorlist);
                                this._shareddataservice.loadingend(true)
                            }
                            else if (this.errorlist[i].successmsg.toString().trim() != '') {
                                this.isadd = true;
                                this.isadd = true;
                                this.lookupgroupadd = [];
                                this.loadlookupdetals(this.lookupgid);
                                this._shareddataservice.Sucess("Look-up Group Variable is updated successfully.")
                                // alert(resp);
                                this._shareddataservice.loadingend(true)
                            }
                            break;
                        }

                    },
                    Error => {
                        this.isadd = true;
                        this.loadlookupdetals(this.lookupgid);
                        this._shareddataservice.loadingend(false)
                    }
                    );


            }
        }
        catch (e) {

        }
    }
    public Deletevariabledata(model: GridVariable) {
        var IsConf = confirm('You are about to delete a record. Are you sure?');
        if (IsConf) {
            this._shareddataservice.loadingstart("true");
            this._lookupservice.Deletevariabledata(model)
                .subscribe(resp => {
                    this._lookupdetails = resp
                    for (var i = 0; i < this._lookupdetails.length; i++) {
                        this._lookupdetailsheader = this._lookupdetails[i].gridHeader
                        this._lookupdetailsdetails = this._lookupdetails[i].gridData
                        this._lookupdetailsvariable = this._lookupdetails[i].gridVariable
                    }
                    this._shareddataservice.Sucess("Look-up Group Variable is deleted successfully.")
                    this._shareddataservice.loadingend(true)
                }, error => {
                    this.loadlookupdetals(this.lookupgid);
                    this._shareddataservice.loadingend(false)
                }
                );
        }
    }
    public onChangerange(selectedobject: any, model: LookupGroupModel) {

        try {
            model.name = selectedobject.value;
            model.parameterId = selectedobject.parameterId;

        } catch (e) {

        }

    }
    public validatetemgroup(model: LookupGroupModel, isupdate: boolean) {
        var validate = true;
        this.errorlist = [];
        this._lookupdetailsvariable
       
        if (this.lookupgroupadd.length > 1) {
            var list = this.lookupgroupadd
            list = list.filter(list => list.variableId === this.variablid)

            if (list.length >= 2) {
                var errorlist = new Errorlist('', "Selected Look-up Group Variable already exists.");
                this.errorlist.push(errorlist);
                validate = false

            }

        }

        if (model.variableIdnew == '0' || typeof model.variableIdnew == 'undefined') {
                var errorlist = new Errorlist("", "Please select the Look-up Group Variable Name.");
                this.errorlist.push(errorlist);
                this._shareddataservice.Error(this.errorlist)
                validate = false
         }
            if (model.parameterIdnew == '0' || typeof model.parameterIdnew == 'undefined') {
                var errorlist = new Errorlist("", "Please select the Range Type.");
                this.errorlist.push(errorlist);
                this._shareddataservice.Error(this.errorlist)
                validate = false

            }

        if (!validate) {
            this._shareddataservice.Error(this.errorlist)
        }
        return validate;
    }
    public Savelookuptable(model: LookupGroupModel, listm: LookupGroupModel[]) {
        if (this.validatetemgroup(model, false)){
        try {
            this.isadd = true;
                model.showEdit = false;
                model.showsave = false
                model.cancel = false;
                this._shareddataservice.Sucess("Look-up Group Variable is saved successfully.")


            }
           
        catch (e) {

            }
        }
    }
    public Cancellookupgroupdata(m: GridData) {
        if (m.isadd) {
            this.isadd = true;
            this._lookupdetailsdetails.shift();
        }
        else {
            this.isadd = true;
            m.showEdit = false
            m.cancel = false;
            m.showupdate = false;
        }
        this.loadlookupdetals(this.lookupgid);
    }
    public Updatelookup(model: LookupGroupModel) {
        if (this.validatetemgroup(model, true)) {
            try {
                    this.isadd = true;
                    model.showEdit = false;
                    model.showsave = false
                    model.showupdate = false
                    model.cancel = false;
                    
                    this._shareddataservice.Sucess("Look-up Group Variable is updated successfully.")

            } catch (e) {

            }
        }
    }
    public onChangevariable(selectedobject: any, model: LookupGroupModel) {

        try {
            this.errorlist = [];
            model.variableName = selectedobject.variableName;
            model.variableId = selectedobject.variableId;
            this.variablid = selectedobject.variableId

        } catch (e) {

        }

    }
    public editlookup(m: LookupGroupModel) {
        m.isadd = false
        m.showupdate = true;
        m.cancel = true;
        m.showEdit = m.showEdit ? false : true;

    }
    public cancellookup(m: LookupGroupModel) {
        if (m.isadd) {
            this.isadd = true;
            this.lookupgroupadd.shift();
        }
        else {
            this.isadd = true;
            m.showEdit = false;
            m.cancel = false;
            m.showupdate = false;
            this.lookupgroupadd.shift();

        }
    }
    public deletemarket(m: LookupGroupModel) {

        if (m.isadd) {
            this.lookupgroupadd.shift();
            this._shareddataservice.Sucess("Look-up Group Variable is deleted successfully.")

        }
        else {
            this.lookupgroupadd.shift();
            this._shareddataservice.Sucess("Look-up Group Variable is deleted successfully.")

        }

    }
    public savelookupdata(m: LookupGroupModel[]) {
        try {
            
            var rangetypeid = '';
            var variabletypeid = '';
            for (let obj of m) {
                variabletypeid += obj.variableId + ','
                rangetypeid += obj.parameterId + ',';
            }
            variabletypeid = variabletypeid.slice(0, -1);
            rangetypeid = rangetypeid.slice(0, -1);
            if (this.validationlookupdata(m, this._lookupdetailsvariable, true, this.lookupgid, variabletypeid)){
                this._shareddataservice.loadingstart("start")
                this._lookupservice.Savelookup(this.taxMasterId, variabletypeid, rangetypeid, this.lokupgroupname)
                .subscribe(
                    resp => {
                            this.errorlist = []
                            this.errorlist = resp;
                            for (var i = 0; i < this.errorlist.length; i++) {
                                if (this.errorlist[i].errormsg.toString().trim() != '') {
                                    var erlist = new Errorlist("", this.errorlist[i].successmsg.toString())
                                    this.errorlist.push(erlist);
                                    this._shareddataservice.Error(this.errorlist);
                                    this._shareddataservice.loadingend(true)
                                }
                                else if (this.errorlist[i].successmsg.toString().trim() != '') {
                                    this.isadd = true;
                                    this.lookupgroupnameid = '0'
                                    this.lokupgroupnameupdate = ''
                                    this.GetLookuoGroup(this.taxMasterId)
                                    this.lookupgroupadd = [];
                                    this.lokupgroupname = '';
                                    this._shareddataservice.Sucess("Look-up Group is created successfully.")
                                    this._shareddataservice.loadingend(true)
                                    this._lookupdetailsheader = []
                                    this._lookupdetailsdetails = []
                                    this._lookupdetailsvariable = []
                                }
                                break;
                            }

                        },
                            Error => {
                                this.isadd = true;
                                this.lookupgroupnameid = '0'
                                this._shareddataservice.loadingend(false)
                            }
                    );
               
            }
        }

        catch (e) {

        }
    }
    public cancellookupgroupdata() {
        try {
            this.isadd = true;
            this.lookupgroupadd = [];
        }
        catch (e) {

        }
    }
    public addnewlookup() {
        try {
            this.lokupgroupname = '';
            this.lookupgroupadd = [];
        }
        catch (e) {

        }
    }
    public cancellookupdata(m: LookupGroupModel) {
        this.isadd = true;
        this.lokupgroupname = '';
        this.lookupgroupadd = [];

    }
    public loadlookupdetals(lookupid: any) {
        try {
            this.lookupgid = lookupid;
            var lookupgroup = this.TempLookuoGroup.filter(l => l.id == this.lookupgid)
            this.lokupgroupnameupdate = lookupgroup[0].name;
            this._shareddataservice.loadingstart("true");
            this._lookupservice.loadlookupdetals(lookupid)
                .subscribe(
                resp => {
                    this._lookupdetails = resp
                    for (var i = 0; i < this._lookupdetails.length; i++) {
                        this._lookupdetailsheader = this._lookupdetails[i].gridHeader
                        this._lookupdetailsdetails = this._lookupdetails[i].gridData
                        this._lookupdetailsvariable = this._lookupdetails[i].gridVariable

                    }
                    this._shareddataservice.loadingend(false)
                },
                error => {
                    this._lookupdetailsheader = []
                    this._lookupdetailsdetails = []
                    this._lookupdetailsvariable = []
                    this._shareddataservice.loadingend(false)
                })

        } catch (e) {

        }

   
    }
    public Editlookupgroupname(id: any)
    {
        try {
            if (id == '0') {
                this.errorlist = [];
                var errorlist = new Errorlist("", "Please select the Look-up Group Name.");
                this.errorlist.push(errorlist);
                this._shareddataservice.Error(this.errorlist)
            }
            else {
                this.editlookupgroupname = true
            }
        } catch (e) {

        }
    }
    public Cancellookupgroup() {
        try {
            this.lookupgroupnameid = this.lookupgid
            this.editlookupgroupname = false

        } catch (e) {

        }
    }
    public Updatelookupgroupname(id: any, name: any) {
        try {
            if (id == '0') {
                this.errorlist = [];
                var errorlist = new Errorlist("", "Please select the Look-up Group Name.");
                this.errorlist.push(errorlist);
                this._shareddataservice.Error(this.errorlist)
            }
            else {
                this.editlookupgroupname = false
                this._shareddataservice.loadingstart(true)
                this._lookupservice.Updatelookupgroupname(id, name, this.taxMasterId)
                    .subscribe(
                    resp => {
                        this.errorlist = []
                        this.errorlist = resp;
                        console.log(this.errorlist)
                        for (var i = 0; i < this.errorlist.length; i++) {
                            if (this.errorlist[i].errormsg.toString().trim() != '') {
                                var erlist = new Errorlist("", this.errorlist[0].successmsg.toString())
                                this.errorlist.push(erlist);
                                this._shareddataservice.Error(this.errorlist);
                                this._shareddataservice.loadingend(true)

                            }
                            else if (this.errorlist[i].successmsg.toString().trim() != '') {
                                this.LookuoGroup = []
                                this.TempLookuoGroup = []
                                this.GetLookuoGroup(this.taxMasterId)
                                this.lookupgroupnameid = id;
                                this._shareddataservice.Sucess("Look-up Group is updated successfully.")
                                this._shareddataservice.loadingend(true)
                            }
                            break;
                        }

                    },
                    Error => {
                        this.loadlookupdetals(this.lookupgid);
                        this._shareddataservice.loadingend(false)
                    }
                    );

            }
        } catch (e) {

        }
    }
    public Deletelookupgroupname(id: any) {
        try {
            if (id == '0') {
                this.errorlist = [];
                var errorlist = new Errorlist("", "Please select the Look-up Group Name.");
                this.errorlist.push(errorlist);
                this._shareddataservice.Error(this.errorlist)
            }
            else
            {

            var IsConf = confirm('You are about to delete a record. Are you sure?');
            if (IsConf) {
                this._shareddataservice.loadingstart("true");
                this._lookupservice.Deletelookuogroup(id)
                    .subscribe(resp => {
                        this.lokupgroupnameupdate = ''
                         this._lookupdetailsheader = []
                         this._lookupdetailsdetails =[]
                         this._lookupdetailsvariable = []
                        this._shareddataservice.loadingend(true)
                    }, error => {
                        this.LookuoGroup = []
                        this.TempLookuoGroup = []
                        this.GetLookuoGroup(this.taxMasterId)
                        this._shareddataservice.Sucess("Look-up Group  is deleted successfully.")
                        this.loadlookupdetals(this.lookupgid);
                        this._shareddataservice.loadingend(false)
                    }
                    );
            }
            this.editlookupgroupname = false
          }

        } catch (e) {

        }
    }
}
