import { TestBed } from '@angular/core/testing';

import { GymService } from './gym.service';

describe('GymsService', () => {
  let service: GymService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GymService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
