import { Injectable } from '@angular/core';
import { ApiService } from '../api.service';
import { HttpResponse } from '@angular/common/http';
import { Club } from 'src/app/Models/interfaces/clubs/club';
import { CreateClubModel } from 'src/app/Models/interfaces/clubs/createclubmodel';

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
        return this.apiService.get<Club[]>(`${this.api_url_tag}/Get`);
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

    /**
     * Process to support saving a new club
     * @param club
     */
    CreateClub(club: CreateClubModel): Promise<HttpResponse<CreateClubModel>> {
        return this.apiService.post<CreateClubModel>(
            `${this.api_url_tag}/post`,
            club
        );
    }

    /**
     * Supports on club details being updated! (initially not players as well!)
     * @param club
     */
    UpdateClubDetails(club: Club): Promise<HttpResponse<Club>> {
        return this.apiService.post<Club>(`${this.api_url_tag}/update`, club);
    }
}
