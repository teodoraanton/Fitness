import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { GymSchedule } from 'src/app/models/gymSchedule';

@Injectable()
export class GymScheduleService {
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

    getGymScheduleByGymID(gymID: String){
      return this.httpClient.get<GymSchedule[]>(
        this.baseUrl + '/GymSchedule/schedule/' + gymID,
        this.httpOptions
      );
    }

    getGymScheduleByGymIdAndDay(gymID: string, day: string){
      return this.httpClient.get<GymSchedule[]>(
        this.baseUrl + "/GymSchedule/schedule-day/" + day + "&&" + gymID,
        this.httpOptions
      )
    }
}
