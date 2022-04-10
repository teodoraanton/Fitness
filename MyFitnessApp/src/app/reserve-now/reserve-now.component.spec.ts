import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReserveNowComponent } from './reserve-now.component';

describe('ReserveNowComponent', () => {
  let component: ReserveNowComponent;
  let fixture: ComponentFixture<ReserveNowComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReserveNowComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReserveNowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
