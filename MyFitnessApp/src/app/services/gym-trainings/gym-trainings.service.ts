import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { GymTrainings } from 'src/app/models/gymTrainings';

@Injectable()
export class GymTrainingsService {
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

    getGymTrainingsByGymID(gymID: String){
      return this.httpClient.get<GymTrainings[]>(
        this.baseUrl + '/GymTrainings/trainings/' + gymID,
        this.httpOptions
      );
    }
}
