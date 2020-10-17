import { TeamNumber } from '../../enums/teamnumber.enum';
import { Player } from '../player/player';

export interface Team {
    id: string;
    players: Player[];
    number: TeamNumber;
}
