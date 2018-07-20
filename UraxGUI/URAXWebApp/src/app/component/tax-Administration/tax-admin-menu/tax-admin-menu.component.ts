import { Component, OnInit, Input, EventEmitter, Directive } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import { Subscription } from 'rxjs';
import { AddVariableComponent } from '../add-version/add-variable/add-variable.component'
import { shareddataservice } from '../../../service/shared/shared.service'
import { taxadminmenuservice } from '../../../service/TaxAdministration/add-version/tax-admin-menu/tax.admin.menu.servic'
import { tax_menu_marketdd, tax_menu_taxtype_dd, tax_menu_tax_dd, tax_menu_version_dd, Taxmenutaxteritory } from '../../../model/tax-administration/add-version/tax-admin-menu/tax.admin.menu'
declare var $: any;
@Component({
    selector: 'urax-tax-admin-menu',
    templateUrl: './tax-admin-menu.component.html',
    styleUrls: ['./tax-admin-menu.component.css'],
    inputs: ['value'],
    providers: [taxadminmenuservice, AddVariableComponent,],
})
export class TaxAdminMenuComponent implements OnInit {
    private _inputValue: string;
    public value: string;
    public _tax_menu_marketdd: tax_menu_marketdd[];
    public _taxterritorrydd: Taxmenutaxteritory[]
    public _tax_menu_tax_dd: tax_menu_tax_dd[];
    public _tax_menu_version_dd: tax_menu_version_dd[];
    public _tax_menu_taxtype_dd: tax_menu_taxtype_dd[];
    private subscription: Subscription;
    public marketid: string
    public taxteritoryid: string
    public Taxid: string
    public Taxversionid: string
    public Taxtypeid: string
    public isupdate: boolean
    public cleardata() {
        try {
            this._tax_menu_marketdd = []
            this._taxterritorrydd = []
            this._tax_menu_tax_dd = [];
            this._tax_menu_version_dd = [];
            this._tax_menu_taxtype_dd = [];
        } catch (e) {

        }
    }
    constructor(public _taxadminservice: taxadminmenuservice, public _shareddataservice: shareddataservice, public _AddVariableComponent: AddVariableComponent) {
        this.subscription = this._shareddataservice.Marketlist.subscribe((newValue: any) => {
            this._tax_menu_marketdd = []
            this._tax_menu_tax_dd = [];
            this._tax_menu_version_dd = [];
            this._tax_menu_taxtype_dd = [];
            this.loadmarketdd();
        })
        this.subscription = this._shareddataservice.cleardataevent.subscribe((newValue: any) => {
            this.marketid = "0"
            this.taxteritoryid = "0"
            this.Taxid = "0"
            this.Taxversionid = "0"
            this.Taxtypeid = "0"
            this.loadmarketdd()
            this.cleardata();
        })

        this.subscription = this._shareddataservice.Newtaxaddedevent.subscribe((newValue: any) => {
            var taxid = newValue;
            this._tax_menu_tax_dd = [];
            this._tax_menu_version_dd = [];
            this._tax_menu_taxtype_dd = [];
            this.loadEditMarket(taxid);
        })
        this.subscription = this._shareddataservice.Updatetaxmasterevent.subscribe((newValue: any) => {
            this.loadmarketdd()
            this.isupdate = false
            this.marketid = newValue[0]
            this.taxteritoryid = newValue[1]
            this.Taxid = newValue[2]
            this.Taxversionid = newValue[3]
            this.Taxtypeid = newValue[4]
            this.isupdate = true;
            this.loadtaxterritorry(this.marketid)
            this.loadEditMarket(this.taxteritoryid)
            this.loadversion(this.Taxid)
            this.loadtaxtype(this.Taxversionid)
            this.versiondetails(this.Taxtypeid)
            this.isupdate = false

        })
    }
    ngOnInit() {

        this.loadmarketdd();
        this.marketid = '0'
        this.Taxid = '0'
        this.Taxversionid = '0'
        this.Taxtypeid = '0'
        this.isupdate = false;
    }

    public loadmarketdd() {
        try {
            this._shareddataservice.loadingstart("true");

            this._taxadminservice.Getcountrylistdd().subscribe(
                market => {
                    this._tax_menu_marketdd = market
                    this._tax_menu_marketdd.unshift(new tax_menu_marketdd("0", 'Please select the Country'));
                    this._shareddataservice.loadingend(false);

                }
            );
            this._shareddataservice.loadingend(false);

        } catch (e) {

        }

    }
    public loadtaxterritorry(marketid: any) {
        try {
            if (!this.isupdate) {
                this.taxteritoryid = '0'
            }
            this._shareddataservice.loadingstart("true");
            this._tax_menu_tax_dd = [];
            this._tax_menu_version_dd = [];
            this._tax_menu_taxtype_dd = [];
            this._shareddataservice.Taxmarketchange(marketid);
            this._shareddataservice.resetlookup("true");
            this._inputValue = marketid;
            this._taxadminservice.GetTAxterritory(marketid).subscribe(resp => {
                this._taxterritorrydd = resp
                this._taxterritorrydd.unshift(new Taxmenutaxteritory("0", 'Please select the Tax Territory'));
                $('.urax-display').css('display', 'none');
                $(".urax-values").css('display', 'block');
                this._shareddataservice.loadingend(false);

            }, error => {
                this.taxteritoryid = "0"
                this._tax_menu_tax_dd = [];
                // this._shareddataservice.Taxidchange(this._inputValue);
                $('.urax-display').css('display', 'none');
                $(".urax-values").css('display', 'block');
                this._shareddataservice.loadingend(false);

            }
            );

        } catch (e) {

        }
    }
    public loadEditMarket(marketid: any) {
        try {
            if (!this.isupdate) {
                this.Taxid = '0'
            }
            this._shareddataservice.loadingstart("true");
            this._tax_menu_tax_dd = [];
            this._tax_menu_version_dd = [];
            this._tax_menu_taxtype_dd = [];
            this._shareddataservice.Taxterritorychange(marketid);
            this._shareddataservice.Setversionnextid(marketid);
            this._shareddataservice.resetlookup("true");
            this._inputValue = marketid;
            this._taxadminservice.Gettaxlist(marketid).subscribe(resp => {
                this._tax_menu_tax_dd = resp
                this._tax_menu_tax_dd.unshift(new tax_menu_tax_dd("0", 'Please select the Tax Name'));
                $('.urax-display').css('display', 'none');
                $(".urax-values").css('display', 'block');
                this._shareddataservice.loadingend(false);

            }, error => {
                this.Taxid = "0"
                this._tax_menu_version_dd = [];
                //this._shareddataservice.Taxidchange(this._inputValue);
                $('.urax-display').css('display', 'none');
                $(".urax-values").css('display', 'block');
                this._shareddataservice.loadingend(false);

            }
            );

        } catch (e) {

        }
    }
    public loadversion(taxid: any) {
        try {
            if (!this.isupdate) {
                this.Taxversionid = '0'
            }
            this._shareddataservice.loadingstart("true");

            this._tax_menu_version_dd = [];
            this._tax_menu_taxtype_dd = [];
            this._shareddataservice.languageidchange(taxid);
            this._taxadminservice.Getversionlistdd(taxid).subscribe(
                market => {
                    this._tax_menu_version_dd = market
                    this._tax_menu_version_dd.unshift(new tax_menu_version_dd("0", 'Please select the Tax Version'));
                }, Error => {
                    this.Taxversionid = "0"
                    this._tax_menu_taxtype_dd = [];

                }
            );
            this._shareddataservice.loadingend(false);

        } catch (e) {

        }

    }
    public loadtaxtype(verid: any) {
        try {
            if (!this.isupdate) {
                this.Taxtypeid = '0'
            }
            this._shareddataservice.loadingstart("true");
            this._tax_menu_taxtype_dd = [];
            this._shareddataservice.Taxvesrsionchange(verid);
            this._taxadminservice.Gettaxtypelist(verid).subscribe(
                market => {
                    this._tax_menu_taxtype_dd = market
                    this._tax_menu_taxtype_dd.unshift(new tax_menu_taxtype_dd("0", 'Please select the Price Base'));
                },
                Error => {
                    this.Taxtypeid = "0"

                }
            );
            this._shareddataservice.loadingend(false);

        } catch (e) {

        }

    }

    public versiondetails(Taxid: string) {
        try {

            var flowname;
            if (this._tax_menu_taxtype_dd.length > 0) {
                var val = this._tax_menu_taxtype_dd.filter(obj => obj.taxId == Taxid)
                for (let obj of val) {
                    if (obj.flowName=='MSRP') {
                        flowname= "4"
                    }
                    if (obj.flowName == 'PRETAX') {
                        flowname = "5"
                    }
                }
            }
            this._shareddataservice.loadingstart("true");
            this._shareddataservice.Taxflowchange(Taxid);
            this._shareddataservice.Taxflowid(flowname);

            $('.urax-display').css('display', 'none');
            $(".urax-values").css('display', 'block');
            this._shareddataservice.loadingend(false);
        }

        catch (e) {

        }

    }

    public newversion() {
        try {
            this._shareddataservice.loadingstart("true");

            this._tax_menu_tax_dd = [];
            this._tax_menu_version_dd = [];
            this._tax_menu_taxtype_dd = [];
            this._shareddataservice.Taxidchange(this._inputValue);
            $('.urax-display').css('display', 'none');
            $(".urax-values").css('display', 'block');
            this._shareddataservice.loadingend(false);

        } catch (e) {

        }

    }
}