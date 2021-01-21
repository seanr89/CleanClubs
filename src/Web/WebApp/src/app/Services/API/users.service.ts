import { HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AppUser } from 'src/app/Models/appuser';
import { ApiService } from '../api.service';

@Injectable({
    providedIn: 'root',
})
export class UsersService {
    public api_url_tag: string;

    constructor(private apiService: ApiService) {
        this.api_url_tag = '/user';
    }

    /**
     * Query and return all club information
     */
    GetAllUsers(): Promise<HttpResponse<AppUser[]>> {
      return this.apiService.get<AppUser[]>(`${this.api_url_tag}/Get`);
    }

    GetUserByObjectId(objectId : string) : Promise<HttpResponse<AppUser>> {
        return this.apiService.get<AppUser>(`${this.api_url_tag}/GetUserByObjectId/${objectId}`);
    }

    /**
     * Process to support saving a new user
     * @param user
     */
    CreateUser(user: AppUser): Promise<HttpResponse<any>> {
        return this.apiService.post(
            `${this.api_url_tag}/NewUser`,
            user
        );
    }
  }
