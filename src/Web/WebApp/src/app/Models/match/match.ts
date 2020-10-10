import { Invite } from '../invite/invite';
import { Team } from '../team/team';

export interface Match {
    id: string;
    teams: Team[];
    status: number;
    date: Date;
    invites: Invite[];
    location: string;
    clubId: string;
}
