import { Injectable } from '@angular/core';
import { ApiService } from '../api.service';

@Injectable({
    providedIn: 'root',
})
export class MembersService {
    public api_url_tag: string;

    constructor(private apiService: ApiService) {
        this.api_url_tag = '/members';
    }
}
