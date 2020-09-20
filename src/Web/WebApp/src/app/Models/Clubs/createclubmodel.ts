/**
 * Supports the creation of new clubs
 */
export interface CreateClubModel {
    name: string;
    active: boolean;
    private: boolean;
    creator: string;
}
