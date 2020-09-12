import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpHeaders } from '@angular/common/http';
import { timeout } from 'rxjs/operators';
import { Data } from '@angular/router';
import { SettingsProvider } from './settingsprovider';

@Injectable({
    providedIn: 'root',
})
export class ApiService {
    protected apiServer = SettingsProvider.appConfig.apiServer.url;
    //protected apiServer = SettingsProvider.appConfig.apiServer.url;
    constructor(private http: HttpClient) {}

    async post<T>(url: string, body: Object = {}): Promise<HttpResponse<T>> {
        //console.log(`post url ${this.apiServer}${url} with panel: ${body}`);
        //this.appInsights.logTrace(`API Post : ${url}`);
        return this.http
            .post<T>(`${this.apiServer}${url}`, JSON.stringify(body), {
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
                .get<T>(`${this.apiServer}${url}`, {
                    responseType: responseType as 'json',
                    headers: new HttpHeaders(),
                    observe: 'response',
                })
                .pipe()
                .toPromise();
        } else {
            return this.http
                .get<T>(`${this.apiServer}${url}`, {
                    headers: new HttpHeaders(),
                    observe: 'response',
                })
                .pipe()
                .toPromise();
        }
    }
}
