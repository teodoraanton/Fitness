import { Component, Input, OnInit } from '@angular/core';
import { GymTrainings } from '../models/gymTrainings';
import { GymTrainingsService } from '../services/gym-trainings/gym-trainings.service';

@Component({
  selector: 'app-gym-trainings',
  templateUrl: './gym-trainings.component.html',
  styleUrls: ['./gym-trainings.component.scss']
})
export class GymTrainingsComponent implements OnInit {
  gymTrainings: GymTrainings[] = [];

  @Input() gymId: string = '';

  constructor(
    private gymTrainingsService: GymTrainingsService
  ) { }

  ngOnInit(): void {
    this.gymTrainingsService
      .getGymTrainingsByGymID(this.gymId)
      .subscribe((gymTrainings) => {
        this.gymTrainings = gymTrainings;
      });
  }

}
