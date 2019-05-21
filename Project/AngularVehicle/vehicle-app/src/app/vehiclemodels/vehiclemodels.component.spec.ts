import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VehiclemodelsComponent } from './vehiclemodels.component';

describe('VehiclemodelsComponent', () => {
  let component: VehiclemodelsComponent;
  let fixture: ComponentFixture<VehiclemodelsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VehiclemodelsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VehiclemodelsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
