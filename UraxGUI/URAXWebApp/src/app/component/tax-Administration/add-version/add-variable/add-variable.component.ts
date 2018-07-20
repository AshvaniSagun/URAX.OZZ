import { Component, OnInit, Provider } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Subscription } from 'rxjs';
import 'rxjs/add/observable/of';
import { shareddataservice, Errorlist } from '../../../../service/shared/shared.service'
import { AddVariableService } from '../../../../service/TaxAdministration/add-version/add-variable/addvariable.service.'
import { VariableModel, VariableType, VariableUnit, Parameter } from '../../../../model/tax-administration/add-version/add-variable/Variable.model'
declare var JQuery: any;
declare var $: any;
@Component({
    selector: 'urax-add-variable',
    templateUrl: './add-variable.component.html',
    styleUrls: ['./add-variable.component.css'],
})
export class AddVariableComponent implements OnInit {

    public taxid:any;
    private subscription: Subscription;
    public errorlist: Errorlist[]
    public isadd: boolean;
    public variableTypeId: string
    public lookupid: string
    public unit: string
    public setvalue: boolean
    public VariableDetails: VariableModel[];
    public Variable: VariableModel;
    public variableType: VariableType[];
    public parmeterlist: Parameter[];
    public VariableUnit: VariableUnit[];
    public taxname: string
    public Errorlist: string[]
    public showinputdd: boolean
    public taxstatus: boolean
    constructor(public VariableService: AddVariableService, public _shareddataservice: shareddataservice) {
        this.subscription = this._shareddataservice.TaxflowEvent.subscribe((newValue: any) => {
            this.taxid = newValue;
            this.VariableDetails = [];
            this.GetVariables(this.taxid)
            this.isadd = true;
            this.GetInputType(this.taxid)

        })
        this.subscription = this._shareddataservice.TaxstatusEvents.subscribe((newValue: any) => {
            this.taxstatus = newValue;
        })
        //this.subscription = this._shareddataservice.TaxstatusEvents.subscribe((newValue: any) => {
        //    this.GetInputType(newValue)
        //})
        this.subscription = this._shareddataservice.TaxmarketCleardataEvent.subscribe((newValue: any) => {
            this.cleardata();
        })
        this.subscription = this._shareddataservice.TaxmarketidEvent.subscribe((newValue: any) => {
            this.cleardata();

        })
        this.subscription = this._shareddataservice.Cleardata.subscribe((newValue: any) => {
            this.taxid = newValue;
            this.VariableDetails = []
        })
        this.subscription = this._shareddataservice.languageEvent.subscribe((newValue: any) => {
            this.cleardata();

        })
        this.subscription = this._shareddataservice.TaxversionEvent.subscribe((newValue: any) => {
            this.cleardata();

        })

    }
  

    ngOnInit() {
        this.isadd = true;
        this.VariableDetails = []
        this.GetVariableType();
        this.GetVariableUnit();
       this.GetInputType(this.taxid)
        this.taxid = '';
        this.isadd = true;
        this.setvalue = false;
        this.taxstatus = false;
        this.showinputdd = false;
        $('.pane-variable-hScroll').scroll(function () {
            $('.pane-variable-vScroll').width($('.pane-variable-hScroll').width() + $('.pane-variable-hScroll').scrollLeft());
        });

    }
    public cleardata() {
        try {
            this.isadd = true;
            this.VariableDetails = []
            this.GetVariableType();
            this.GetVariableUnit();
            this.taxid = '';
            this.isadd = true;
        } catch (e) {

        }
    }
    //Get All 
    public GetVariables(varid: any) {
        if (varid == "0") {
            this.VariableDetails = [];
        }
        else {
            this.VariableService.GetVariableDetails(varid).subscribe(
                Variable => { this.VariableDetails = Variable },
                Error =>
                {
                    this.VariableDetails = [];
                }
            );
        }

    }
    private GetVariableType() {
        this.VariableService.GetVariableType().subscribe(
            vtype => this.variableType = vtype
        );
    }
    private GetInputType(taxid:any) {
        this.VariableService.GetInputType(taxid).subscribe(
            ptype => {
                this.parmeterlist = ptype
            }
        );
    }

    private GetVariableUnit() {
        this.VariableService.GetVariableUnit().subscribe(
            vunit => this.VariableUnit = vunit
        );
    }


    public validation(m: VariableModel, listm: VariableModel[], taxid: any, variableName: any, isupdate: boolean) {
        var validate = true;
        this.errorlist = [];
        if (typeof taxid === 'undefined' ||  this.taxid == '' || typeof taxid === null) {
            var errorlist = new Errorlist('',"Please select the Tax details before adding a new variable.");
            this.errorlist.push(errorlist);
            validate = false
        }    
        if (m.variableTypeId == 'undefined' || m.variableTypeId == '' || m.variableTypeId == null || m.variableTypeId =='0') {
            var errorlist = new Errorlist('',"Please select the Type of Variable.");
            this.errorlist.push(errorlist);
            validate = false
        }
        if (typeof m.variableName === 'undefined' || m.variableName.trim() == '' || typeof m.variableName === null) {
            var errorlist = new Errorlist('', "Please provide the Name of Variable.");
            this.errorlist.push(errorlist);
            validate = false
        }
        if (typeof m.isLookup == 'undefined' || m.isLookup == null || this.lookupid == '0') {
            var errorlist = new Errorlist('',"Please select the Look-up.");
            this.errorlist.push(errorlist);
            validate = false
        }

        if ((m.variableValue == 'undefined' || m.variableValue == '' || m.variableValue == null) && (m.variableTypeId == '7')) {
            var errorlist = new Errorlist('',"Please enter the Value for Variable.");
            this.errorlist.push(errorlist);
            validate = false
        }

        if (m.unitTypeId == '' || typeof m.unitTypeId == 'undefined' || typeof m.unitTypeId == null || m.unitTypeId == '0') {
            var errorlist = new Errorlist('',"Please select the Unit for Variable.");
            this.errorlist.push(errorlist);
            validate = false
        }
        //if (true && listm.length > 1 && typeof variableName !== 'undefined' && variableName != '') {
        //    listm = listm.filter(listm => listm.variableName === variableName && listm.variableId !== '')
        //    if (isupdate) {
        //        if (listm.length > 1) {
        //            var errorlist = new Errorlist('',"Variable : "+ variableName + " already exists.");
        //            this.errorlist.push(errorlist);
        //            validate = false
        //        }

        //    }
        //    else {
        //        if (listm.length > 0) {
        //            var errorlist = new Errorlist('', "Variable name " + variableName + " already exists.");
        //            this.errorlist.push(errorlist);
        //            validate = false
        //        }

        //    }


        //}
        if (!validate) {
            this._shareddataservice.Error(this.errorlist)

        }
        return validate;
    }
    public setlookupid(val: any) {
        if (val == '0') {
            this.lookupid = '0'
        }
        else
        {
            this.lookupid = '1'
        }

    }

    public SaveVariables(model: VariableModel, listm: VariableModel[]) {
        if (this.validation(model, listm, this.taxid, model.variableName, false)) {
            this._shareddataservice.loadingstart("true");
            this.VariableService.SaveVariableDetails(model, this.taxid)
                .subscribe(
                version => {
                    this.errorlist = []
                    this.errorlist = version;
                    this._shareddataservice.loadingstart("true")
                    for (var i = 0; i < this.errorlist.length; i++) {
                        if (this.errorlist[i].errormsg.toString().trim() != '') {
                            var erlist = new Errorlist("", this.errorlist[i].successmsg.toString())
                            this.errorlist.push(erlist);
                            this._shareddataservice.Error(this.errorlist);
                            this._shareddataservice.loadingend(true)

                        }
                        else if (this.errorlist[i].successmsg.toString().trim() != '') {
                            this.GetVariables(this.taxid)
                            this.isadd = true;
                            this._shareddataservice.variablechange(this.taxid);
                            this._shareddataservice.Sucess("Variable details are saved successfully.")
                            this._shareddataservice.loadingend(true)
                        }
                        break;
                    }
                },
                Error => {
                    this.isadd = true;
                    this._shareddataservice.loadingend(false)
                }
                );
            
        }


    }
    public UpdateVariable(model: VariableModel, listm: VariableModel[]) {
        if (this.validation(model, listm, this.taxid, model.variableName, true)) {
            this._shareddataservice.loadingstart("true")
            this.VariableService.UpdateVariableDetails(model, this.taxid)
                .subscribe(response => {
                    this.errorlist = []
                    this.errorlist = response;
                    this._shareddataservice.loadingstart("true")
                    for (var i = 0; i < this.errorlist.length; i++) {
                        if (this.errorlist[i].errormsg.toString().trim() != '') {
                            var erlist = new Errorlist("", this.errorlist[i].successmsg.toString())
                            this.errorlist.push(erlist);
                            this._shareddataservice.Error(this.errorlist);
                            this._shareddataservice.loadingend(true)

                        }
                        else if (this.errorlist[i].successmsg.toString().trim() != '') {
                            this.GetVariables(this.taxid)
                            this.isadd = true;
                            this._shareddataservice.variablechange(this.taxid);
                            this._shareddataservice.Sucess("Variable details are updated successfully.")
                            this._shareddataservice.loadingend(true)
                        }
                        break;
                    }
                },
                Error => {
                    this.isadd = true;
                    this._shareddataservice.loadingend(false)
                    this.GetVariables(this.taxid)
                }
                );
        }

    }

    // Delete
    public DeleteVariable(item: VariableModel) {
        //debugger
        var IsConf = confirm('You are about to delete ' + item.variableName + '. Are you sure?');
        if (IsConf) {
            this._shareddataservice.loadingstart("true")
            this.VariableService.DeleteVariable(item.variableId)
                .subscribe(
                variable => {
                    this.errorlist = []
                    this.errorlist = variable;
                    this._shareddataservice.loadingstart("true")
                    for (var i = 0; i < this.errorlist.length; i++) {
                        if (this.errorlist[i].errormsg.toString().trim() != '') {
                            var erlist = new Errorlist("", this.errorlist[i].successmsg.toString())
                            this.errorlist.push(erlist);
                            this._shareddataservice.Error(this.errorlist);
                            this._shareddataservice.loadingend(true)

                        }
                        else if (this.errorlist[i].successmsg.toString().trim() != '') {
                            this.GetVariables(this.taxid)
                            this._shareddataservice.variablechange(this.taxid);
                            this._shareddataservice.Sucess("Variable: " + item.variableName + " is deleted successfully.")
                            this._shareddataservice.loadingend(true)
                        }
                        break;
                    }
                },
                Error => {
                    this.isadd = true;
                    this._shareddataservice.loadingend(false)
                }
               
                );
        }
    }

    private addNew() {
        $('.pane-variable-vScroll').animate({
            scrollTop: '-=2000'
        }, 100);

        if (this.isadd) {
            this.isadd = false;
            var ObjVariableModel = new VariableModel();
            if (typeof this.VariableDetails == 'undefined') {
                this.VariableDetails = [];
                this.VariableDetails.unshift(ObjVariableModel);
                ObjVariableModel.showEdit = true;
                ObjVariableModel.showupdate = false;
                ObjVariableModel.cancel = true;
                ObjVariableModel.isadd = true;
                ObjVariableModel.showsave = true;
            }
            else {
                this.VariableDetails.unshift(ObjVariableModel);
                ObjVariableModel.showEdit = true;
                ObjVariableModel.showupdate = false;
                ObjVariableModel.cancel = true;
                ObjVariableModel.isadd = true;
                ObjVariableModel.showsave = true;

            }
        }

    };
    editVariable(m: VariableModel) {
        if (this.isadd) {
            this.showinputdd = false
            if (m.variableTypeId == "6")
            {
                this.showinputdd = true
                
            }
            if (m.variableTypeId == "7") {
                m.hide = true;
                this.isadd = false;

            }
            else {
                m.hide = false;
            }
            m.showupdate = true;
            m.cancel = true;
            m.showEdit = m.showEdit ? false : true;

        }     
    }
    cancel(m: VariableModel) {
            this.GetVariables(this.taxid)
            this.isadd = true;
            if (m.isadd) {
                this.VariableDetails.shift();
                m.hide = false;
            }
            else {
                m.showEdit = false;
                m.cancel = false;
                m.showupdate = false;
                m.hide = false;
                this.isadd = true;
            }
        
        

    }
    _keyPress(event: any) {
        const pattern = /[0-9]/;
        let inputChar = String.fromCharCode(event.charCode);

        if (!pattern.test(inputChar)) {
            // invalid character, prevent input
            this._shareddataservice.Error("Cannot add more than two decimal places.")
            event.preventDefault();
        }
    }

    public validate(val: any, obj: VariableModel) {
        try {
            this.setvalue = true
            this.showinputdd = false
            obj.hide = false
            obj.variableName = ''
            if (val == "7") {
                obj.hide = true;
                obj.isLookup = false;
                this.setvalue = false;
                this.showinputdd = false
            }

            if (val == "6") {
                obj.isLookup = false;
                this.setvalue = false
                this.showinputdd = true

            }

            if (val == "8") {
                obj.isLookup = false;
            }
            if (val == "10") {
                obj.isLookup = true;

            }
            if (val == "9") {
                obj.isLookup = false;

            }


        } catch (e) {

        }

    }
    public isNumberKey(evt: any) {
        var charCode = (evt.which) ? evt.which : evt.keyCode;
        if (charCode != 46 && charCode > 31
            && (charCode < 48 || charCode > 57))
            return false;
        return true;

    }


}
