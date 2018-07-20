import { Injectable } from '@angular/core';

// Application specific configuration 
@Injectable()
export class SecretService {
    dev: string ='93d03314-171a-4f36-bd2a-061aa7cb4ed2'
    test: string ='ca5d85db-8000-45f8-8394-c4dba2a761e4'
    prod: string ='df5f7b37-cde3-4bb6-8c8e-aaf44f2847a9'
    qa2: string = '7bfb07b9-fffa-401f-99aa-56a114456326'
    preprod: string = '233a19c3-26ed-460e-88a4-6bd54c1af92a'

    public get adalConfig(): any {
        return {
            tenant: 'volvocars.onmicrosoft.com',
            clientId: this.dev,
            postLogoutRedirectUrl: window.location.origin + '/',
            redirectUri: window.location.origin + '/'
        };
    }
}