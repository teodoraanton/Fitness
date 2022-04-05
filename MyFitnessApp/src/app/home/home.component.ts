import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { City } from '../models/city';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  cityControl = new FormControl('', Validators.required);
  selectFormControl = new FormControl('', Validators.required);

  cities: Array<City> = [
    {id: '1', name: 'Buzau'},
    {id: '2', name: 'Bucuresti'},
    {id: '3', name: 'Brasov'}
  ]

  constructor() { }

  ngOnInit(): void {
  }

  show(){
    
  }

}
