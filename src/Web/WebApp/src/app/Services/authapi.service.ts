import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpHeaders } from '@angular/common/http';
import { catchError, timeout } from 'rxjs/operators';
import { Data } from '@angular/router';
import { SettingsProvider } from './settingsprovider';
import { environment } from 'src/environments/environment';
import { AuthService } from './auth.service';
import { throwError } from 'rxjs';

@Injectable({
    providedIn: 'root',
})

export class AuthApiService {
  protected settings = environment.ApiConfig;
    constructor(private http: HttpClient, private authService: AuthService) {
    }

    //Formats the errors that come from API requests and outputs them to the console.
  private formatErrors(error: any) {
    return throwError(error.error);
  }

    //Used to get data from the API.
  async get<T>(url: string): Promise<HttpResponse<T>> {
    return this.http
      .get<T>(`${this.settings.url}${url}`, { 
        responseType: 'json',
        headers: await this.authService.getAPIHeaders(),
        observe: 'response', })
      .pipe()
      .toPromise();
  }

  //Used to pass objects to the API for use elsewhere, not for inserting. Replace used on json to from _ when handling private variables.
  async post(url: string, body: Object = {}): Promise<any> {
    return this.http
      .post(`${this.settings.url}${url}`, JSON.stringify(body), {
        headers: await this.authService.getAPIHeaders(),
      })
      .pipe
      // catchError(error => {
      //   return this.formatErrors(error);
      // })
      ()
      .toPromise();
  }
}
