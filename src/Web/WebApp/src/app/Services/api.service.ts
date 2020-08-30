import { Injectable } from "@angular/core";
import { HttpClient, HttpResponse, HttpHeaders } from "@angular/common/http";
import { timeout } from "rxjs/operators";
import { Data } from "@angular/router";

@Injectable({
  providedIn: "root",
})
export class ApiService {
  //protected apiServer = SettingsProvider.appConfig.apiServer.url;
  constructor(private http: HttpClient) {}
}
