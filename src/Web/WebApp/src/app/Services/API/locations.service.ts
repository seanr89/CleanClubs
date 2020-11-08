import { Injectable } from '@angular/core';
import { ApiService } from '../api.service';
import { HttpResponse } from '@angular/common/http';
import { ILocation } from 'src/app/Models/interfaces/locations/ilocation';

@Injectable({
    providedIn: 'root',
})
export class LocationsService {
    public api_url_tag: string;

    constructor(private apiService: ApiService) {
        this.api_url_tag = '/location';
    }

    /**
     * Query and return all locations available
     * This will be a limited data set to display simple info
     */
    GetAllLocations(): Promise<HttpResponse<ILocation[]>> {
      return this.apiService.get<ILocation[]>(`${this.api_url_tag}/Get`);
    }

    /**
     * Query a singular location record which includes additional details
     * Will become a more detailed object!
     * @param id : unique location id
     */
    GetLocation(id: string): Promise<HttpResponse<ILocation>> {
      return this.apiService.get<ILocation>(`${this.api_url_tag}/GetLocationById/${id}`);
    }
  }
