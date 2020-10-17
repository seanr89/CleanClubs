import { Member } from '../members/member';

export interface Club {
    id: string;
    name: string;
    active: boolean;
    private: boolean;
    creator: string;
    members: Member[];
}
