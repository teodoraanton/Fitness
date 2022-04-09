import { TestBed } from '@angular/core/testing';

import { GymDescriptionService } from './gym-description.service';

describe('GymDescriptionService', () => {
  let service: GymDescriptionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GymDescriptionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
