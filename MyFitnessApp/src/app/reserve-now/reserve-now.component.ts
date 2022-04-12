import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Reservation } from '../models/reservation';
import { ReservationService } from '../services/reservation/reservation.service';

@Component({
  selector: 'app-reserve-now',
  templateUrl: './reserve-now.component.html',
  styleUrls: ['./reserve-now.component.scss']
})
export class ReserveNowComponent implements OnInit {
  day: string = "";
  training: string = "";
  trainer: string = "";
  gymId: string = "";

  reserveForm!: FormGroup;

  public get nameControl() {
    return this.reserveForm.get('name');
  }

  public get emailControl() {
    return this.reserveForm.get('email');
  }

  constructor(
    private _activatedRoute: ActivatedRoute,
    private formBuilder: FormBuilder,
    private router: Router,
    private reservationService: ReservationService,
    private _snackBar: MatSnackBar
  ) { }

  ngOnInit(): void {
    this._activatedRoute.queryParams.subscribe((params) => {
      this.day = params['day'];
      this.training = params['training'];
      this.trainer = params['trainer'];
      this.gymId = params['gymID']
    });
    this.reserveForm = new FormGroup({
      name: new FormControl(),
      email: new FormControl()
    })
  }

  save() {
    const reservation: Reservation = {
      id: this.reserveForm.get('id')?.value,
      name: this.reserveForm.get('name')?.value,
      email: this.reserveForm.get('email')?.value,
      day: this.day,
      training: this.training,
      trainer: this.trainer
    }
    
    this.reservationService.addReservation(reservation);

    this.router.navigate(['/gym-details'], {
      queryParams: { gymID: this.gymId },
    });

    this._snackBar.open("The reservation was successfully saved", "Thanks!");
    
  }

  close(){
    this.router.navigate(['/gym-details'], {
      queryParams: { gymID: this.gymId },
    });
  }


  setupReservationDetails(reservation: Reservation) {
    this.reserveForm = this.formBuilder.group({
      id: reservation.id,
      name: [reservation.name, Validators.required],
      email: [reservation.email, Validators.required],
      day: [reservation.day, Validators.required],
      training: [reservation.training, Validators.required]
    });
  }
}
