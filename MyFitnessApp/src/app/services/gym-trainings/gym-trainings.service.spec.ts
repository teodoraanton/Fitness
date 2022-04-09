import { TestBed } from '@angular/core/testing';

import { GymTrainingsService } from './gym-trainings.service';

describe('GymTrainingsService', () => {
  let service: GymTrainingsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GymTrainingsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
