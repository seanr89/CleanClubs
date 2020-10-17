import { Match } from '../match/match';
import { Member } from '../members/member';
import { Team } from '../team/team';

export interface Invite {

    id: string;
    member: Member;
    email:string;
    accepted: boolean;
    date: Date;
    match: Match;
}
