import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Gym } from '../models/gym';
import { CityService } from '../services/city.service';
import { GymService } from '../services/gym.service';

@Component({
  selector: 'app-gym-details',
  templateUrl: './gym-details.component.html',
  styleUrls: ['./gym-details.component.scss']
})
export class GymDetailsComponent implements OnInit {
  gymId: string = "";
  gymName: string = "";
  days: string[] = ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday'];

  constructor(
    private _activatedRoute: ActivatedRoute,
    private gymService: GymService,
    private cityService: CityService
  ) { }

  ngOnInit(): void {
    this._activatedRoute.queryParams.subscribe((params) => {
      this.gymId = params['gymId'];
    }),
    this.gymService.getGymById(this.gymId).subscribe(gym => {
      this.gymName = gym.name;
      console.log(this.gymName);
    })
  }

}
