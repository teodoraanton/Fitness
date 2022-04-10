import { TestBed } from '@angular/core/testing';

import { GymOpenHoursService } from './gym-open-hours.service';

describe('GymOpenHoursService', () => {
  let service: GymOpenHoursService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GymOpenHoursService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
