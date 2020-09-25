import { Injectable, isDevMode } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { IAppConfig } from '../Models/appConfig';

@Injectable()
export class SettingsProvider {
    static appConfig: IAppConfig;

    constructor(private http: HttpClient) {
        this.load();
    }
    // Http Options
    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json',
        }),
    };

    load() {
        let jsonFile = `/assets/config.json`;
        if (!isDevMode()) {
            //console.log('SettingsProvider !isDevMode')
            jsonFile = `/assets/config.deploy.json`;
        }
        return new Promise<IAppConfig>((resolve, reject) => {
            this.http.get(jsonFile).subscribe((response: IAppConfig) => {
                SettingsProvider.appConfig = {
                    env: response.env,
                    apiServer: response.apiServer,
                };
                resolve();
            });
        });
    }
}
