import { MatchStatus } from '../../enums/matchstatus.enum';
import { Invite } from '../invite/invite';
import { Team } from '../team/team';

export interface Match {
    id: string;
    teams: Team[];
    status: MatchStatus;
    date: Date;
    invites: Invite[];
    invitesSent: boolean;
    location: string;
    clubId: string;
}
