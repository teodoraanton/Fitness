import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { GymOpenHours } from '../models/gymOpenHours';
import { GymSchedule } from '../models/gymSchedule';
import { GymOpenHoursService } from '../services/gym-open-hours/gym-open-hours.service';
import { GymScheduleService } from '../services/gym-schedule/gym-schedule.service';

@Component({
  selector: 'app-gym-schedule',
  templateUrl: './gym-schedule.component.html',
  styleUrls: ['./gym-schedule.component.scss']
})
export class GymScheduleComponent implements OnInit {
  gymScheduleMonday: GymSchedule[] = [];
  gymScheduleTuesday: GymSchedule[] = [];
  gymScheduleWednesday: GymSchedule[] = [];
  gymScheduleThursday: GymSchedule[] = [];
  gymScheduleFriday: GymSchedule[] = [];
  gymScheduleSaturday: GymSchedule[] = [];
  gymScheduleSunday: GymSchedule[] = [];

  gymOpenHours: GymOpenHours[] = [];

  displayedColumns = ["timeSlot", "training", "trainer", "reserve"]

  @Input() gymId: string = '';

  constructor(
    private router: Router,
    private gymScheduleService: GymScheduleService,
    private gymOpenHoursService: GymOpenHoursService
  ) { }

  ngOnInit(): void {
    this.gymScheduleService.getGymScheduleByGymIdAndDay(this.gymId, "Monday").subscribe((gymSchedule) => {
      this.gymScheduleMonday = gymSchedule;
    });
    this.gymScheduleService.getGymScheduleByGymIdAndDay(this.gymId, "Tuesday").subscribe((gymSchedule) => {
      this.gymScheduleTuesday = gymSchedule;
    });
    this.gymScheduleService.getGymScheduleByGymIdAndDay(this.gymId, "Wednesday").subscribe((gymSchedule) => {
      this.gymScheduleWednesday = gymSchedule;
    });
    this.gymScheduleService.getGymScheduleByGymIdAndDay(this.gymId, "Thursday").subscribe((gymSchedule) => {
      this.gymScheduleThursday = gymSchedule;
    });
    this.gymScheduleService.getGymScheduleByGymIdAndDay(this.gymId, "Friday").subscribe((gymSchedule) => {
      this.gymScheduleFriday = gymSchedule;
    });
    this.gymScheduleService.getGymScheduleByGymIdAndDay(this.gymId, "Saturday").subscribe((gymSchedule) => {
      this.gymScheduleSaturday = gymSchedule;
    });
    this.gymScheduleService.getGymScheduleByGymIdAndDay(this.gymId, "Sunday").subscribe((gymSchedule) => {
      this.gymScheduleSunday = gymSchedule;
    });
    this.gymOpenHoursService.getGymOpenHoursByGymID(this.gymId).subscribe((gymOpenHours) => {
      this.gymOpenHours = gymOpenHours;
    });
  }

  reserveNow(gymSchedule: GymSchedule){
    this.router.navigate(['/reserve-now'], {
      queryParams: { day: gymSchedule.day, training: gymSchedule.training, trainer: gymSchedule.trainer, gymID: this.gymId },
    });
  }

}
