import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GymScheduleComponent } from './gym-schedule.component';

describe('GymScheduleComponent', () => {
  let component: GymScheduleComponent;
  let fixture: ComponentFixture<GymScheduleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GymScheduleComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GymScheduleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
