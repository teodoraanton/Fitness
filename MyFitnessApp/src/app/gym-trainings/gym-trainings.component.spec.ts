import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GymTrainingsComponent } from './gym-trainings.component';

describe('GymTrainingsComponent', () => {
  let component: GymTrainingsComponent;
  let fixture: ComponentFixture<GymTrainingsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GymTrainingsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GymTrainingsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
