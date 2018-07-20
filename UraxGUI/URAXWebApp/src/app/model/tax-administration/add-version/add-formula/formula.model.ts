export class formulamodel {
    public formulaId: string
    public formulaDefinition: string=''
    public formulaName: string
    public variableId: string
    public minValue: string
    public maxValue: string
    public priority: string=''
    public roundId:string
    public showEdit: boolean
    public showsave: boolean
    public showupdate: boolean
    public cancel: boolean
    public isadd: boolean
    public createdOn: string
    public createdBy: string
    public updatedOn: string
    public updatedBy: string
}

export class formulaNamedropdown {
    variableId: string;
    variableName: string
    constructor() {

    }
}

export class Variable {
    variableId: string;
    definition: string;
    name: string;
    value: string;
    variableTypeId: string;
    testValue:string
    constructor() {

    }
}

