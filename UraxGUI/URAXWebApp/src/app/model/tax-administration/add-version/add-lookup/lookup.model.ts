export class LookupGroupModel {

    public name: string
    public id: string
    public variableId: string
    public variableIdnew: string
    public variableName: string
    public parameterId: string
    public parameterIdnew: string
    public showsave: boolean
    public showupdate: boolean
    public showEdit: boolean
    public cancel: boolean
    public isadd: boolean
    public createdOn: string
    public createdBy: string
    public updatedOn: string
    public updatedBy: string
    constructor() { }
}




export class lookupvariable {
    
    public variableName: string
    public variableType: string
    public showsave: boolean
    public showupdate: boolean
    public showEdit: boolean
    public cancel: boolean
    public isadd: boolean
    constructor() { }

}
export class lookupdparameterdd {

    public variableId: string
    public variableName: string
    constructor() { }

}
export class lookuprangetypedd {

    public lookUpRangeId: string
    public lookUpRangeType: string
    constructor() { }

}
export class lookupdetails {
    public gridHeader: GridHeader[]
    public gridData: GridData[]
    public gridVariable: GridVariable[]
    
}
export class lookupmodel {
    public FuelType: string
    public Co2: string
    public EscaleodeCo2: string
    public TexasEur: string
    public showsave: boolean
    public showupdate: boolean
    public showEdit: boolean
    public cancel: boolean
    public isadd: boolean
    constructor() { }
}
export class GridHeader {

    public lugdId: string
    public variableId: string
    public variableName: string
    public showsave: boolean
    public showupdate: boolean
    public showEdit: boolean
    public cancel: boolean
    public isadd: boolean
    public createdOn: string
    public createdBy: string
    public updatedOn: string
    public updatedBy: string
}
export class GridData {

    public GroupId: string
    public lookUpId: string
    public variableId: string
    public variableName: string
    public showsave: boolean
    public showupdate: boolean
    public showEdit: boolean
    public cancel: boolean
    public isadd: boolean
    public createdOn: string
    public createdBy: string
    public updatedOn: string
    public updatedBy: string
}
export class GridVariable {

    public lookUpGroupDetailId: string=''
    public variableName: string
    public variableId: string=''
    public lookUpRangeType: string
    public lookUpRangeId: string
    public parameterId: string
    public showsave: boolean
    public showupdate: boolean
    public showEdit: boolean
    public cancel: boolean
    public isadd: boolean
    public createdOn: string
    public createdBy: string
    public updatedOn: string
    public updatedBy: string

}
export class groupdatalist {
    
    public GroupId: string
    public lookUpGroup: string
    public lookUpGroupId: string
    public lookUpId: string
    public variableId: string
    public value: string
    public LoginUser: string
    public createdOn: string
    public createdBy: string
    public updatedOn: string
    public updatedBy: string

}