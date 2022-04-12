import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Reservation } from '../models/reservation';
import { GymScheduleService } from '../services/gym-schedule/gym-schedule.service';
import { ReservationService } from '../services/reservation/reservation.service';

@Component({
  selector: 'app-reserve-now',
  templateUrl: './reserve-now.component.html',
  styleUrls: ['./reserve-now.component.scss']
})
export class ReserveNowComponent implements OnInit {

  reserveForm!: FormGroup;

  public get nameControl() {
    return this.reserveForm.get('name');
  }

  public get emailControl() {
    return this.reserveForm.get('email');
  }

  public get dayControl() {
    return this.reserveForm.get('day');
  }
  
  public get trainingControl() {
    return this.reserveForm.get('training');
  }

  constructor(
    private _activatedRoute: ActivatedRoute,
    private formBuilder: FormBuilder,
    private reservationService: ReservationService,
    private gymScheduleService: GymScheduleService
  ) { }

  ngOnInit(): void {
  }

  add() {
    const reservation: Reservation = {
      id: this.reserveForm.get('id')?.value,
      name: this.reserveForm.get('name')?.value,
      email: this.reserveForm.get('email')?.value,
      day: this.reserveForm.get('day')?.value,
      training: this.reserveForm.get('training')?.value
    }
    
    //this.reservationService.addEmployee(reservetion);
    
  }
}
