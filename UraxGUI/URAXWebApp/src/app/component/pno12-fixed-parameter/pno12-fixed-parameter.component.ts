import { Component, OnInit } from '@angular/core';
import { AccordionModule } from 'primeng/components/accordion/accordion';
import { Subscription } from 'rxjs';
import { addMarketService } from '../../service/TaxAdministration/add-market/addmarket.service'
import { marketcodedropdown, marketcurencydropdown, marketmodel, subdivisionCode } from '../../model/tax-administration/add-market/market.model'
import { PNO12FixedParameter, PNO12FixedHeader } from '../../model/PONO12FixedParameter/pno12-fixed-parameter';
import { PNO12FixedParameterService } from '../../service/PONO12FixedParameter/pno12-fixed-parameter.service'
import { shareddataservice, Errorlist } from '../../service/shared/shared.service'
import { SelectItem } from 'primeng/components/common/selectitem';
import { TooltipModule, DialogModule } from 'primeng/primeng';
declare var JQuery: any;
declare var $: any;
@Component({
    selector: 'app-pno12-fixed-parameter',
    templateUrl: './pno12-fixed-parameter.component.html',
    styleUrls: ['./pno12-fixed-parameter.component.css'],
    providers: [PNO12FixedParameterService]
})
export class PNO12FixedParameterComponent implements OnInit {

    displayDialog: boolean;

    car: marketmodel = new marketmodel();
    pno12: PNO12FixedParameter = new PNO12FixedParameter();

    selectedCar: marketmodel;

    newCar: boolean;

    cars: any[];

    Newcars: any[];

    display: boolean = false;
    //constructor() { }
    public marketmodellist: marketmodel[];

    public Pno12list: any[];
    public cols: PNO12FixedHeader[];
    public columnOptions: SelectItem[];
    public errorlist: Errorlist[];
    private subscription: Subscription;
    constructor(public _pno12service: PNO12FixedParameterService, public _shareddataservice: shareddataservice) {
        this.subscription = this._shareddataservice.cleardataeventmarket.subscribe((newValue: any) => {
        })
    }
    ngOnInit() {

        this.GetPNO12Column()
        this.GetPNO12();
    }

    selectRow($event: any) {

    }
    private GetPNO12Column() {
        this._pno12service.GetPNO12Column().subscribe(
            PNO12 => {
                this.cols = PNO12
                this.columnOptions = [];
                for (let i = 0; i < this.cols.length; i++) {
                    this.columnOptions.push({ label: this.cols[i].Header, value: this.cols[i] });
                }
            }

        );
    }


    private GetPNO12() {
        this._pno12service.GetPNO12Details().subscribe(
            PNO12 => this.Pno12list = PNO12

        );
    }


    showDialogToAdd() {
        this.newCar = true;
        this.pno12 = new PNO12FixedParameter();
        this.displayDialog = true;
    }

    save() {
        let cars = [...this.cars];
        if (this.newCar)
            cars.push(this.car);
        else
            cars[this.findSelectedCarIndex()] = this.car;

        this.cars = cars;
        this.car = null;
        this.displayDialog = false;
    }

    delete() {
        let index = this.findSelectedCarIndex();
        this.cars = this.cars.filter((val, i) => i != index);
        this.car = null;
        this.displayDialog = false;
    }

    onRowSelect(event: any) {
        this.newCar = false;
        this.pno12 = this.cloneCar(event.data);
        this.displayDialog = true;
    }


    cloneCar(c: PNO12FixedParameter): PNO12FixedParameter {
        let car = new PNO12FixedParameter();
        for (let prop in c) {
            car[prop] = c[prop];
        }
        return car;
    }

    findSelectedCarIndex(): number {
        return this.cars.indexOf(this.selectedCar);
    }

}
