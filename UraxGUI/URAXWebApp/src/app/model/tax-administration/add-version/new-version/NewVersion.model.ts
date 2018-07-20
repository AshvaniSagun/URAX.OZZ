export class NewVersion {
    taxMasterId: string 
    taxVersionId: string
    taxId: string=''
    marketId: string
    taxName: string='' 
    vatRelation: string=''
    priority: string=''
    priceBase: string='' 
    versionValidFrom: string=''
    versionValidUpto: string=''
    isActive: boolean
    createdBy: string
    createdOn: string
    updatedBy: string
    updatedOn: string
    taxVersionStatusId: string
    featureLevelTax: boolean
    
}
export class ddlpricebaselist
{
    parameterId: number;
    value: string;
}
export class ddlvatrelationlist
{
    parameterId: number;
    value: string;
}
export class SwapingorderDD {
    taxMasterId: number;
    taxName: string;
    calculationOrder: string;
}

