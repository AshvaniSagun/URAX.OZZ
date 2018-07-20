export class apiurlmodel {
  public apiurl: string;
  public  testapiurl: string
  public  qaapiurl: string
  public prodapiurl: string
  public loginuser:string
  constructor() {
        this.apiurl = 'http://localhost:54230/api/' //api url for local
     // this.apiurl = 'http://urax-main-dev.azurewebsites.net/api/' //Dev api url for devlopment
      //this.apiurl = 'http://urax-main-test.azurewebsites.net/api/'//Test api url for  testing
      //this.apiurl = 'http://urax-main-qa2.azurewebsites.net/api/'//Qa url for Qa
      //this.apiurl = 'http://wltp-uraxapi-prod.azurewebsites.net/api/'//Prod url for Production
         this.loginuser='Admin'

    }
}
