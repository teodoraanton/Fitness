import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-gym-description',
  templateUrl: './gym-description.component.html',
  styleUrls: ['./gym-description.component.scss']
})
export class GymDescriptionComponent implements OnInit {

  @Input() gymId: string = '';

  constructor() { }

  ngOnInit(): void {
  }

}
