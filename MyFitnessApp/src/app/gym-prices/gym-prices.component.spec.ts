import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GymPricesComponent } from './gym-prices.component';

describe('GymPricesComponent', () => {
  let component: GymPricesComponent;
  let fixture: ComponentFixture<GymPricesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GymPricesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GymPricesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
