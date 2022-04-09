import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { City } from '../models/city';
import { Gym } from '../models/gym';
import { CityService } from '../services/city/city.service';
import { GymService } from '../services/gym/gym.service';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';

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
    private gymService: GymService,
    private sanitizer: DomSanitizer
  ) {}

  ngOnInit(): void {
    this.cityService.getCities().subscribe((cities) => {
      this.cities = cities;
      this.sortCities();
    });
    this.gymService.getGyms().subscribe((gyms) => {
      this.gyms = gyms;
    });
  }

  sortCities(){
    this.cities = this.cities?.sort((a,b) => a.name < b.name ? -1 : a.name > b.name ? 1 : 0);
  }

  sanitizeImageUrl(imageUrl: string): SafeUrl {
    return this.sanitizer.bypassSecurityTrustUrl(imageUrl);
  }

  show() {
    this.gymService.getGymsByCity(this.selectedCity).subscribe(
      (response) => {
        this.gyms = response;
      },
      (err) => console.log(err)
    );
  }

  showGym(gym: Gym) {
    this.router.navigate(['/gym-details'], {
      queryParams: { gymID: gym.id },
    });
  }
}
