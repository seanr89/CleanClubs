import { Member } from '../Members/member';

export interface Player {
    id: string;
    firstName: string;
    lastName: string;
    email: string;
    rating: number;
    memberId: string;
}
