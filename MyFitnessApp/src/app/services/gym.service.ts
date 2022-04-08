import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Gym } from '../models/gym';

@Injectable()
export class GymService {
  readonly baseUrl = 'https://localhost:5001';
  readonly httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };

  constructor(private router: Router, private httpClient: HttpClient) {}

  getGyms(): Observable<Gym[]> {
    return this.httpClient.get<Gym[]>(this.baseUrl + '/Gym', this.httpOptions);
  }

  getGymsByCity(cityID: String): Observable<Gym[]> {
    return this.httpClient.get<Gym[]>(
      this.baseUrl + '/Gym/CityID/' + cityID,
      this.httpOptions
    );
  }

  getGymById(gymId: string) {
    return this.httpClient.get<Gym>(
      this.baseUrl + '/Gym/' + gymId,
      this.httpOptions
    );
  }
}
