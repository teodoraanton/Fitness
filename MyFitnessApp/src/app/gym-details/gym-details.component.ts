import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Gym } from '../models/gym';
import { CityService } from '../services/city/city.service';
import { GymService } from '../services/gym/gym.service';

@Component({
  selector: 'app-gym-details',
  templateUrl: './gym-details.component.html',
  styleUrls: ['./gym-details.component.scss']
})
export class GymDetailsComponent implements OnInit {
  gymId: string = "";
  gym: Gym = {
    id: "",
    name: "",
    address: "",
    gymImagePath: "",
    city: ""
  };

  constructor(
    private _activatedRoute: ActivatedRoute,
    private router: Router,
    private gymService: GymService
  ) { }

  ngOnInit(): void {
    this._activatedRoute.queryParams.subscribe((params) => {
      this.gymId = params['gymID'];

      this.gymService.getGymById(this.gymId).subscribe(gym => {
        this.gym = gym;
      })
    });
  }

  backHomePage(){
    this.router.navigate([''], {});
  }

}
