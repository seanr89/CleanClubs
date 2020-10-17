import { Injectable } from '@angular/core';
import { ApiService } from '../api.service';
import { HttpResponse } from '@angular/common/http';
import { Match } from 'src/app/Models/interfaces/match/match';

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
     *
     * @param id
     */
    GetMatchesForClub(id: string): Promise<HttpResponse<Match[]>> {
      return this.apiService.get<Match[]>(`${this.api_url_tag}/GetMatchesByClubId/${id}`);
    }

    /**
     * Supports match scheduling with teams already appended
     * @param match
     * @returns : HttpResponse with a match record!
     */
    CreateMatchWithTeams(match: Match): Promise<HttpResponse<Match>> {
        return this.apiService.post<Match>(`${this.api_url_tag}/CreateMatch`, match);
    }
}
