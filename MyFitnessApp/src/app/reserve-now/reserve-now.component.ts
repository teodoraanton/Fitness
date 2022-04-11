import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-reserve-now',
  templateUrl: './reserve-now.component.html',
  styleUrls: ['./reserve-now.component.scss']
})
export class ReserveNowComponent implements OnInit {

  
  constructor(
    private _activatedRoute: ActivatedRoute,
    private formBuilder: FormBuilder,
  ) { }

  ngOnInit(): void {
  }
}
