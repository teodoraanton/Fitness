import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { GymDescription } from 'src/app/models/gymDescription';

@Injectable()
export class GymDescriptionService {
  readonly baseUrl = 'https://localhost:5001';
  readonly httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };

  constructor(
    private router: Router, 
    private httpClient: HttpClient
    ) { }

    getGymDescriptionByGymID(gymID: String){
      return this.httpClient.get<GymDescription>(
        this.baseUrl + '/GymDescription/description/gymID/' + gymID,
        this.httpOptions
      );
    }
}
