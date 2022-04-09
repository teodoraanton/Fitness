import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { GymTrainers } from 'src/app/models/gymTrainers';

@Injectable()
export class GymTrainersService {
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

    getGymTrainersByGymID(gymID: String){
      return this.httpClient.get<GymTrainers[]>(
        this.baseUrl + '/GymTrainers/trainer/' + gymID,
        this.httpOptions
      );
    }
}
