import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { City } from '../models/city';
import { Gym } from '../models/gym';
import { CitiesService } from '../services/cities.service';
import { GymsService } from '../services/gyms.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  cityControl = new FormControl('', Validators.required);
  selectFormControl = new FormControl('', Validators.required);
  selectedValue?: string;
  cities?: City[];

  gyms: Array<Gym> = [
    {id:'1', name:'RedGym', address:'1 Decembrie Street', cityId:"Brasov"},
    {id:'2', name:'WordClass', address:'15 Noiembrie Street', cityId:"Brasov"},
    {id:'3', name:'18Gym', address:'Vasile Alecsandri Street', cityId:'Bucuresti'},
  ]

  constructor(
    private router: Router, 
    private citiesService: CitiesService, 
    private gymsService: GymsService) {}

  ngOnInit(): void {
    this.citiesService.getCities().subscribe((cities) => {
      this.cities = cities;
    });
  }

  show(){

  }

  showGym(id: string){
    
  }

}
