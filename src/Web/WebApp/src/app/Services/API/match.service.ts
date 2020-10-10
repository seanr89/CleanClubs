import { Injectable } from '@angular/core';
import { ApiService } from '../api.service';
import { Club } from 'src/app/Models/Clubs/club';
import { HttpResponse } from '@angular/common/http';
import { CreateClubModel } from 'src/app/Models/Clubs/createclubmodel';
import { Match } from 'src/app/Models/match/match';

@Injectable({
    providedIn: 'root',
})
export class MatchService {
    public api_url_tag: string;

    constructor(private apiService: ApiService) {
        this.api_url_tag = '/match';
    }

    /**
     * Query and return all club information
     */
    GetAllMatches(): Promise<HttpResponse<Match[]>> {
        return this.apiService.get<Match[]>(`${this.api_url_tag}/Get`);
    }

    /**
     * Not yet fully implemented
     * @param match
     */
    CreateMatchWithTeams(match: Match): Promise<HttpResponse<Match>> {
        return this.apiService.post<Match>(`${this.api_url_tag}/CreateMatch`, match);
    }

    /**
     * Not yet implemented
     * @param match
     */
    CreateMatchWithoutTeams(match: Match) {}
}
