import {HttpClient, HttpHeaders} from '@angular/common/http'
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment'
import { Restaurant } from '../_models/restaurant';

@Injectable({
    providedIn: 'root'
  })

export class RestaurantService
{
    baseUrl = environment.apiUrl;

    constructor(private http: HttpClient){ }

    getRestaurant(id: string)
    {
        return this.http.get<Restaurant>(this.baseUrl + 'restaurant/' + id)
    }
}