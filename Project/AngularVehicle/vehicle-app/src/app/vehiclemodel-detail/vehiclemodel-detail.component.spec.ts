import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VehiclemodelDetailComponent } from './vehiclemodel-detail.component';

describe('VehiclemodelDetailComponent', () => {
  let component: VehiclemodelDetailComponent;
  let fixture: ComponentFixture<VehiclemodelDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VehiclemodelDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VehiclemodelDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
