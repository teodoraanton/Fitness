import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GymPrices } from '../models/gymPrices';
import { GymPricesService } from '../services/gym-prices/gym-prices.service';

@Component({
  selector: 'app-gym-prices',
  templateUrl: './gym-prices.component.html',
  styleUrls: ['./gym-prices.component.scss']
})
export class GymPricesComponent implements OnInit {
  gymPrices: GymPrices[] = [];

  @Input() gymId: string = '';

  displayedColumns: string[] = ['subscriptionType', 'duration', 'price'];
  dataSource : GymPrices[] = [];

  constructor(
    private _activatedRoute: ActivatedRoute,
    private gymPricesService: GymPricesService
  ) { }

  ngOnInit(): void {
    this.gymPricesService
      .getGymPricesByGymID(this.gymId)
      .subscribe((gymPrices) => {
        this.gymPrices = gymPrices;
        this.dataSource = gymPrices;
      });
  }
}
