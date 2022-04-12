import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GymTrainers } from '../models/gymTrainers';
import { GymTrainersService } from '../services/gym-trainers/gym-trainers.service';

@Component({
  selector: 'app-gym-trainers',
  templateUrl: './gym-trainers.component.html',
  styleUrls: ['./gym-trainers.component.scss']
})
export class GymTrainersComponent implements OnInit {
  gymTrainers: GymTrainers[] = [];

  @Input() gymId: string = '';

  constructor(
    private gymTrainersService: GymTrainersService
  ) { }

  ngOnInit(): void {
    this.gymTrainersService
      .getGymTrainersByGymID(this.gymId)
      .subscribe((gymTrainers) => {
        this.gymTrainers = gymTrainers;
      });
  }

}
