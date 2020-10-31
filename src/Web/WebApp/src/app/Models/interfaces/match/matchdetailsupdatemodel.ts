import { MatchStatus } from '../../enums/matchstatus.enum';

export interface MatchDetailsUpdateModel {
    
    id: string;
    date: Date;
    location: string;
    status: MatchStatus;
}
