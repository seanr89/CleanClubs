import { Injectable } from '@angular/core';
import { ApiService } from '../api.service';
import { HttpResponse } from '@angular/common/http';
import { Match } from 'src/app/Models/interfaces/match/match';
import { MatchDetailsUpdateModel } from 'src/app/Models/interfaces/match/matchdetailsupdatemodel';
import { ScheduleMatchModel } from 'src/app/Models/interfaces/match/schedulematchmodel';

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
     * query a single match record based on its unique Id
     * @param id : string/Guid record to query
     */
    GetMatchById(id: string): Promise<HttpResponse<Match>> {
      return this.apiService.get<Match>(`${this.api_url_tag}/GetMatchById/${id}`);
    }

    /**
     * Support the quering of all matches created and recorded for a club!
     * @param id : unique ClubId
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

    ScheduleMatch(match: ScheduleMatchModel): Promise<HttpResponse<Match>> {
      return this.apiService.post<Match>(`${this.api_url_tag}/CreateMatchWithInvites`, match);
    }

    /**
     * TODO: not yet currently enabled/processing!
     * @param match
     */
    UpdateScheduledMatchDetails(match: MatchDetailsUpdateModel){
        return this.apiService.put<MatchDetailsUpdateModel>(`${this.api_url_tag}/UpdateMatchDetails/${match.id}`, match);
    }
}
