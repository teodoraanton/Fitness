import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GymDescription } from '../models/gymDescription';
import { GymDescriptionService } from '../services/gym-description/gym-description.service';

@Component({
  selector: 'app-gym-description',
  templateUrl: './gym-description.component.html',
  styleUrls: ['./gym-description.component.scss'],
})
export class GymDescriptionComponent implements OnInit {
  gymDescription: GymDescription = {
    id: '',
    description: '',
    interiorImagesPath: [],
    gymID: '',
  };

  @Input() gymId: string = '';

  constructor(
    private _activatedRoute: ActivatedRoute,
    private gymDescriptionService: GymDescriptionService
  ) {}

  ngOnInit(): void {
    this.gymDescriptionService
      .getGymDescriptionByGymID(this.gymId)
      .subscribe((gymDescription) => {
        this.gymDescription = gymDescription;
      });
  }
}
