import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { GymOpenHours } from 'src/app/models/gymOpenHours';

@Injectable()
export class GymOpenHoursService {
  readonly baseUrl = 'https://localhost:5001';
  readonly httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };

  constructor(private router: Router, private httpClient: HttpClient) {}

  getGymOpenHoursByGymID(gymID: String) {
    return this.httpClient.get<GymOpenHours[]>(
      this.baseUrl + '/GymOpenHours/open-hour/' + gymID,
      this.httpOptions
    );
  }
}
