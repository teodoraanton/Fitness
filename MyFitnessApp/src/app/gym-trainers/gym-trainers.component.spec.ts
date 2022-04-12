import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GymTrainersComponent } from './gym-trainers.component';

describe('GymTrainersComponent', () => {
  let component: GymTrainersComponent;
  let fixture: ComponentFixture<GymTrainersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GymTrainersComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GymTrainersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
