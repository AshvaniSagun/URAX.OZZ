
export class marketmodel {
   public marketId: string
   public countryName: string
   public submarketCode: string
   public variableId: string
   public variableName: string
   public currencyId: string
   public countryCode: string=''
   public currencyCode: string
   public isActive: boolean
   public createdBy: string
   public createdOn: string
   public updatedBy: string
   public updatedOn: string
   public subdivisionCode: string
   public taxTerritory: string
   public featureLevelTax: boolean
   public showEdit: boolean
   public showsave: boolean
   public showupdate: boolean
   public cancel: boolean
   public isadd: boolean
   public countryCodeId: countryCodeId
   constructor()
   { }
}
class countryCodeId {
    public countryCodeId:string=''
    public countryCode: string=''
    public countryName: string=''
}
export class marketcodedropdown {
    countryCodeId: string;
    countryCode: string
    countryName: string
    constructor(cid: string, code: string, cname: string) {
        this.countryCodeId = cid
        this.countryCode = code
        this.countryName = cname

    }
}
export class marketcurencydropdown {
    currencyId: string;
    currencyCode: string
    constructor() {

    }
}
export class subdivisionCode {
    public variableId: string = ''
    public variableName: string = ''

}
