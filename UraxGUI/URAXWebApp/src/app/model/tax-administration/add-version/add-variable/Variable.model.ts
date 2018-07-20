export class VariableModel {
    public variableId: string='';
    public variableType: string;
    public taxId: string;
    public variableName: string;
    public variableTypeId: string='';
    public unitTypeId: string='';
    public unit: string;
    public testValue: string;
    public variableValue: string='';
    public UnitTypeName: string;
    public VariableTypeName: string;
    public parameterId: string;
    public isLookup: boolean;
    public isActive: string;
    public showEdit?: boolean
    public hide?: boolean
    public showsave?: boolean
    public showupdate: boolean
    public cancel: boolean
    public isadd: boolean
    constructor()
    { }
}



export class VariableType {
    parameterId: string;
    value: string
    constructor() {

    }
}


export class VariableUnit {
    parameterId: string;
    value: string
    constructor() {

    }
}
export class Parameter {
    variableId: string;
    variableName: string
    constructor() {

    }
}



