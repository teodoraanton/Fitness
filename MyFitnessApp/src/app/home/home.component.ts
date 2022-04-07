import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { City } from '../models/city';
import { Gym } from '../models/gym';
import { CityService } from '../services/city.service';
import { GymService } from '../services/gym.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  cityControl = new FormControl('', Validators.required);
  selectFormControl = new FormControl('', Validators.required);

  selectedCity: String = '';

  cities: City[] | undefined;
  gyms: Gym[] = [];

  constructor(
    private router: Router,
    private cityService: CityService,
    private gymService: GymService
  ) {}

  ngOnInit(): void {
    this.cityService.getCities().subscribe((cities) => {
      this.cities = cities;
    });
    this.gymService.getGyms().subscribe((gyms) => {
      this.gyms = gyms;
    });
  }

  show() {
    this.gymService.getGymsByCity(this.selectedCity).subscribe(
      (response) => {
        this.gyms = response;
      },
      (err) => console.log(err)
    );
  }

  showGym(id: string) {
    this.router.navigate(['/gym-details'], {
      queryParams: { gymID: id },
    });
  }
}
