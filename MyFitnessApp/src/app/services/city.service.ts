import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/internal/Observable';
import { City } from '../models/city';

@Injectable()
export class CityService {
  readonly baseUrl = 'https://localhost:5001';
  readonly httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };

  constructor(private router: Router, private httpClient: HttpClient) {}

  getCities(): Observable<City[]> {
    return this.httpClient.get<City[]>(
      this.baseUrl + '/City',
      this.httpOptions
    );
  }
}
