export class languagemodel {

    public taxMasterId: string
    public languageId: string
    public languageDetailid: string=''
    public taxName: string
    public languageName:string
    public isActive: boolean
    public default: string
    public showEdit: boolean
    public showsave: boolean
    public showupdate: boolean
    public cancel: boolean
    public isadd: boolean
    public createdOn: string
    public createdBy: string
    public updatedOn: string
    public updatedBy: string
   constructor (){}
}


export class LanguageDropdown {

    public languageId: string
    public language: string
    constructor() { }
}


