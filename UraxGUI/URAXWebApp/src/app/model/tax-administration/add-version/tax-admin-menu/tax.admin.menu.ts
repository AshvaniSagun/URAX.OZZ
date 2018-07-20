export class tax_menu_marketdd {
    public id: string;
    public name: string;
    constructor(id: string, value: string) {
        this.id = id;
        this.name = value;
    }
}
export class Taxmenutaxteritory {
    public id: string;
    public name: string;
    constructor(id: string, value: string) {
        this.id = id;
        this.name = value;
    }
}
export class tax_menu_tax_dd {
    public taxId: string;
    public taxName: string;
    constructor(id: string, value: string) {
        this.taxId = id;
        this.taxName = value;
    }
}
export class tax_menu_version_dd {
    public taxVersionId: string;
    public versionName: string;
    constructor(id: string, value: string) {
        this.taxVersionId = id;
        this.versionName = value;
    }
}
export class tax_menu_taxtype_dd {
    public taxId: string;
    public flowName: string;
    constructor(id: string, value: string) {
        this.taxId = id;
        this.flowName = value;
    }
}
