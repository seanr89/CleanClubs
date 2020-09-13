import { Injectable } from '@angular/core';
import { ApiService } from '../api.service';
import { Club } from 'src/app/Models/club';
import { HttpResponse } from '@angular/common/http';

@Injectable({
    providedIn: 'root',
})
export class ClubsService {
    public api_url_tag: string;

    constructor(private apiService: ApiService) {
        this.api_url_tag = '/clubs';
    }

    /**
     * Query and return all club information
     */
    GetAllClubs(): Promise<HttpResponse<Club[]>> {
        return this.apiService.get<Club[]>(`${this.api_url_tag}/GetAllClubs`);
    }

    /**
     * Query a singular club record
     * @param id : unique ID for a club
     */
    GetClubById(id: string): Promise<HttpResponse<Club>> {
        return this.apiService.get<Club>(
            `${this.api_url_tag}/GetClubById/${id}`
        );
    }

    CreateClub(club: Club) {}
}
