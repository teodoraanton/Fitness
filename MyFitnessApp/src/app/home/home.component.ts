import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { City } from '../models/city';
import { Gym } from '../models/gym';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  cityControl = new FormControl('', Validators.required);
  selectFormControl = new FormControl('', Validators.required);

  selectedValue?: string;

  cities: Array<City> = [
    {id: '1', name: 'Buzau'},
    {id: '2', name: 'Bucuresti'},
    {id: '3', name: 'Brasov'}
  ]

  gyms: Array<Gym> = [
    {id:'1', name:'RedGym', address:'1 Decembrie Street', city:"Brasov"},
    {id:'2', name:'WordClass', address:'15 Noiembrie Street', city:"Brasov"},
    {id:'3', name:'18Gym', address:'Vasile Alecsandri Street', city:'Bucuresti'},
  ]

  constructor() { }

  findCity(){
    //return this.cities.filter(x => x.id == this.selectedValue);
  }

  ngOnInit(): void {
    //this.gymsF = this.gyms.filter(x => x.city == this.findCity().name)
  }

  show(){

  }

}
