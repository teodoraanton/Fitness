import { TestBed } from '@angular/core/testing';

import { GymPricesService } from './gym-prices.service';

describe('GymPricesService', () => {
  let service: GymPricesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GymPricesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
