
import { MatchStatus } from '../../enums/matchstatus.enum';
import { Team } from '../team/team';

export interface CreateMatchModel {
    teams: Team[];
    status: MatchStatus;
    date: Date;
    sendInvites: boolean;
    location: string;
    clubId: string;
}
