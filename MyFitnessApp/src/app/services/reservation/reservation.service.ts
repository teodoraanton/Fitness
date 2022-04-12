import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Reservation } from 'src/app/models/reservation';

@Injectable()
export class ReservationService {
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

  addReservation(reservation: Reservation){
    return this.httpClient.post(this.baseUrl+"/reservation", reservation).subscribe(response => {
      this.router.navigate(['reservation']);
    }, (err:HttpErrorResponse) => console.log(err));
  }
}
