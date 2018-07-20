import { Component, OnInit } from '@angular/core';
import { addFormulaService } from '../../../../service/TaxAdministration/add-version/add-formula/add-formula.service';
import { formulamodel, formulaNamedropdown,Variable } from '../../../../model/tax-administration/add-version/add-formula/formula.model';
import { shareddataservice, Errorlist } from '../../../../service/shared/shared.service'
import { Subscription } from 'rxjs';
declare var JQuery: any;
declare var $: any;
@Component({
    selector: 'urax-add-formula',
  templateUrl: './add-formula.component.html',
  styleUrls: ['./add-formula.component.css'],
  providers: [addFormulaService]
})
export class AddFormulaComponent implements OnInit {

    public isadd: boolean;
    public taxid: any;
    public errorlist: Errorlist[]
    public _formulatestlist: Variable[]
    public taxstatus: boolean
    private subscription: Subscription;
    public cleardata() {
        try {
            this.formulamodellist = []

        } catch (e) {

        }
    }
    constructor(public _formulaservice: addFormulaService, public _shareddataservice: shareddataservice) {
        this.subscription = this._shareddataservice.VariablechangeEvent.subscribe((newValue: any) => {
            this.taxid = newValue;
            this.formulamodellist = []
            this.isadd = true
            this.getFormulaName(this.taxid);
            this.getformuladetails(this.taxid);
        })
        this.subscription = this._shareddataservice.TaxstatusEvents.subscribe((newValue: any) => {
            this.taxstatus = newValue;
        })
        this.subscription = this._shareddataservice.TaxmarketCleardataEvent.subscribe((newValue: any) => {
            this.cleardata();
        })
        this.subscription = this._shareddataservice.TaxflowEvent.subscribe((newValue: any) => {
            this.taxid = newValue;
            this.formulamodellist = []
            this.isadd = true
            this.getFormulaName(this.taxid);
            this.getformuladetails(this.taxid);
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

        this.subscription = this._shareddataservice.Cleardata.subscribe((newValue: any) => {
            this.taxid = newValue;
            this.formulamodellist = []
        })
    }
    public formulamodellist: formulamodel[];
    public formulaName: formulaNamedropdown[];
    public Errorlist: string[]
    ngOnInit() {
        this.isadd = true;
        this.getFormulaName(this.taxid);
        this.getformuladetails(this.taxid);
        $('.pane-formula-hScroll').scroll(function () {
            $('.pane-formula-vScroll').width($('.pane-formula-hScroll').width() + $('.pane-formula-hScroll').scrollLeft());
        });
    }
    private getFormulaName(id: any) {
        this.formulaName = []
        this._formulaservice.getFormulaName(id).subscribe(
            formulaNam => this.formulaName = formulaNam
        );
    }
    private getformuladetails(id: any) {
        this._formulaservice.getformuladetails(id).subscribe(
            resp => {
                this.formulamodellist = resp
            }
            , error => {
                this.formulamodellist = [];
            }
        );
    }
    public validation(m: formulamodel, listm: formulamodel[], formulaDefinition: any, formulaName: any, isupdate: boolean) {
        var validate = true;
        this.errorlist = [];

        if (typeof m.priority === 'undefined' || m.priority == '' || typeof m.priority === null) {
            var errorlist = new Errorlist('',"Please provide the Calculation Order.");
            this.errorlist.push(errorlist);
            validate = false
        }
        if (typeof m.priority === 'undefined' || m.priority == '' || typeof m.priority === null || m.priority ==='0') {
            var errorlist = new Errorlist('', "Calculation Order cannot be zero.");
            this.errorlist.push(errorlist);
            validate = false
        }


        if (typeof m.variableId == 'undefined' || m.variableId == '' || typeof m.variableId == null || m.variableId == '0') {
            var errorlist = new Errorlist('',"Please select the Name."); 
            this.errorlist.push(errorlist);
            validate = false
        }


        if (typeof formulaDefinition === 'undefined' || m.formulaDefinition === '' || typeof formulaDefinition === null) {
            var errorlist = new Errorlist('',"Please enter the Definition.");
            this.errorlist.push(errorlist);
            validate = false
        }

        //if (true && listm.length > 1 && typeof formulaName !== 'undefined' && formulaName != '') {
        //    listm = listm.filter(listm => listm.formulaName === formulaName && listm.formulaName !== '')
        //    if (isupdate) {
        //        if (listm.length > 1) {
        //            var errorlist = new Errorlist('',"Formula :"+ formulaName + " already exists.");
        //            this.errorlist.push(errorlist);
        //            validate = false
        //        }

        //    }
        //    else {
        //        if (listm.length > 0) {
        //            var errorlist = new Errorlist('',"Formula :"+ formulaName + " already exists.");
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

    public SaveFormulaDetails(model: formulamodel, listm: formulamodel[]) {

        if (this.validation(model, listm, model.variableId, model.formulaName, false)) {
            this._shareddataservice.loadingstart("true");
            this._formulaservice.SaveFormulaDetails(model).subscribe(
                version => {
                this.errorlist = version;
                for (var i = 0; i < this.errorlist.length; i++) {
                   
                    if (this.errorlist[i].errormsg.toString().trim() != '') {
                        var erlist = new Errorlist("", this.errorlist[i].successmsg.toString())
                        this.errorlist.push(erlist);
                        this._shareddataservice.Error(this.errorlist);
                        this._shareddataservice.loadingend(true)

                    }
                    else if (this.errorlist[i].successmsg.toString().trim() != '') {
                        this.getformuladetails(this.taxid);
                        this._shareddataservice.Sucess("Formula Details are saved successfully.")
                        this.getformuladetails(this.taxid);
                        this._shareddataservice.loadingend(true)
                        this.isadd = true

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
    public UpdateFormulaDetails(model: formulamodel, listm: formulamodel[]) {

        //if (this.validation(model, listm, model.variableId, model.formulaName, false)){
        if (this.validation(model, listm, model.variableId, model.formulaName, false)) {
        this._shareddataservice.loadingstart("true");
        this._formulaservice.UpdateFormulaDetails(model)
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
                        this._shareddataservice.Sucess("Formula details are updated successfully.")
                        this.getformuladetails(this.taxid);
                        this._shareddataservice.loadingend(true)
                        this.isadd = true


                    }
                    break;
                }
            },
            Error => {
                // this._shareddataservice.Error(Error);
                this._shareddataservice.loadingend(false)
            }
            );
        }
    }

    public DeleteFormula(item: formulamodel) {
        var IsConf = confirm('You are about to delete ' + item.formulaName + '. Are you sure?');
        if (IsConf) {
            this._shareddataservice.loadingstart("true")
            this._formulaservice.deleteFormula(item.formulaId)
                .subscribe(
                formula => {
                    this._shareddataservice.inputChanged(this.taxid);
                    this.getformuladetails(this.taxid);
                    this._shareddataservice.Sucess("Formula: "+ item.formulaName +" is deleted successfully.")
                    this.formulamodellist = formula
                    this._shareddataservice.loadingend(true)

                }
                , error => {
                    this._shareddataservice.loadingend(false)

                    this._shareddataservice.Error(error);
                }
                );
        }
    }
    private addNew() {
        $('.pane-formula-vScroll').animate({
            scrollTop: '-=2000'
        }, 100);
        if (this.isadd) {
            this.isadd = false;
            var objmarketmodel = new formulamodel();
            if (typeof this.formulamodellist == 'undefined') {
                this.formulamodellist = [];
                this.formulamodellist.unshift(objmarketmodel);
                objmarketmodel.showEdit = true;
                objmarketmodel.showupdate = false;
                objmarketmodel.cancel = true;
                objmarketmodel.isadd = true;
                objmarketmodel.showsave = true;
            }
            else {
                this.formulamodellist.unshift(objmarketmodel);
                objmarketmodel.showEdit = true;
                objmarketmodel.showupdate = false;
                objmarketmodel.cancel = true;
                objmarketmodel.isadd = true;
                objmarketmodel.showsave = true;
            }
        }
    };
    editVariable(m: formulamodel) {
        if (this.isadd) {
            this.isadd = false;

            m.showupdate = true;
            m.cancel = true;
            m.showEdit = m.showEdit ? false : true;
        }
    }
    cancel(m: formulamodel) {
        this.getformuladetails(this.taxid);
        if (m.isadd) {
            this.isadd = true;
            this.formulamodellist.shift();
        }
        else {
            this.isadd = true;
            m.showEdit = false;
            m.cancel = false;
            m.showupdate = false;

        }

    }
    public Testformula(m: formulamodel)
    {
        try {
            this.errorlist = [];
            this._formulaservice.Getformulavariablelist(m.formulaId).subscribe(
                resp => {
                    this._formulatestlist = resp
                    if (this._formulatestlist.length>0) {
                        this._shareddataservice.FormulaTest(this._formulatestlist, m.formulaId)
                    }
                    else {
                        var errorlist = new Errorlist('', "No valid variable exists to test the Formula Definition.");
                        this.errorlist.push(errorlist);
                        this._shareddataservice.Error(this.errorlist)

                    }

                }
                , error => {
                    this.formulamodellist = [];
                }
            );
        } catch (e) {

        }
    }

}
