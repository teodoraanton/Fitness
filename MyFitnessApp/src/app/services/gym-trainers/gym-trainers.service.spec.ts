import { TestBed } from '@angular/core/testing';

import { GymTrainersService } from './gym-trainers.service';

describe('GymTrainersService', () => {
  let service: GymTrainersService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GymTrainersService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
