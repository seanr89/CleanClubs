import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpHeaders } from '@angular/common/http';
import { timeout } from 'rxjs/operators';
import { Data } from '@angular/router';
import { SettingsProvider } from './settingsprovider';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root',
})
export class ApiService {
    protected settings = environment.ApiConfig;
    //protected apiServer = SettingsProvider.appConfig.apiServer.url;
    //protected apiServer = SettingsProvider.appConfig.apiServer.url;
    constructor(private http: HttpClient) {}

    async post<T>(
        endPoint: string,
        body: Object = {}
    ): Promise<HttpResponse<T>> {
        //console.log(`post url ${this.apiServer}${url} with panel: ${body}`);
        //this.appInsights.logTrace(`API Post : ${url}`);
        return this.http
            .post<T>(`${this.settings.url}${endPoint}`, JSON.stringify(body), {
                headers: new HttpHeaders().set(
                    'Content-Type',
                    'application/json'
                ),
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
                    responseType: responseType as 'json',
                    headers: new HttpHeaders(),
                    observe: 'response',
                })
                .pipe()
                .toPromise();
        } else {
            return this.http
                .get<T>(`${this.settings.url}${url}`, {
                    headers: new HttpHeaders(),
                    observe: 'response',
                })
                .pipe()
                .toPromise();
        }
    }

    //Used to pass data to the API to be inserted into the database. Replace used on json to from _ when handling private variables.
  async put<T>(url: string, body: Object = {}): Promise<any> {
    return this.http
      .put(`${this.settings.url}${url}`, JSON.stringify(body), {
        headers: new HttpHeaders().set(
            'Content-Type',
            'application/json'
        ),
        observe: 'response',
    })
    .pipe()
    .toPromise();
  }
}
