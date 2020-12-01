import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpHeaders } from '@angular/common/http';
import { take, timeout } from 'rxjs/operators';
import { Data } from '@angular/router';
import { SettingsProvider } from './settingsprovider';
import { environment } from 'src/environments/environment';
import { AuthService } from './auth.service';
import { User } from 'firebase';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root',
})

//https://medium.com/@lucian.cbn/using-firebase-authentication-token-to-make-api-calls-for-the-respective-user-with-angular-7-a1b577d9eb3d
export class ApiService {
    protected settings = environment.ApiConfig;
    private accessToken : any;
    constructor(private http: HttpClient, private authService: AuthService) {
    }

    async post<T>(
        endPoint: string,
        body: Object = {}
    ): Promise<HttpResponse<T>> {
        //this.appInsights.logTrace(`API Post : ${url}`);
        return this.http
            .post<T>(`${this.settings.url}${endPoint}`, JSON.stringify(body), {
                headers: await this.authService.getAPIHeaders(),
                observe: 'response',
              })
            .pipe()
            .toPromise();
    }

    //Used to get data from the API.
    async get<T>(
        url: string,
        responseType: any = null
    ): Promise<HttpResponse<T>> {
        
        if (responseType !== null) {
            return this.http
                .get<T>(`${this.settings.url}${url}`, { 
                    responseType: responseType as'json',
                    headers: await this.authService.getAPIHeaders(),
                    observe: 'response'})
                .pipe()
                .toPromise();
        } else {
            return this.http
                .get<T>(`${this.settings.url}${url}`,  { 
                    headers: await this.authService.getAPIHeaders(),
                    observe: 'response'})
                .pipe()
                .toPromise();
        }
    }

    //Used to pass data to the API to be inserted into the database. Replace used on json to from _ when handling private variables.
  async put<T>(url: string, body: Object = {}): Promise<any> {
    return this.http
      .put(`${this.settings.url}${url}`, JSON.stringify(body), {
        headers: await this.authService.getAPIHeaders(),
        observe: 'response',
      })
    .pipe()
    .toPromise();
  }
}
