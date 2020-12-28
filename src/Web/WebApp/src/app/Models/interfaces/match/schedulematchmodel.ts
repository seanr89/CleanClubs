import { MatchStatus } from '../../enums/matchstatus.enum';
import { Member } from '../members/member';

/**
 * Explicity model to support match scheduling over match creation!
 */
export interface ScheduleMatchModel {
    status: MatchStatus;
    date: Date;
    sendInvites: boolean;
    location: string;
    clubId: string;
    selectedMembers: Member[];
}
