import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VehicleModelDetailsComponent } from './vehicle-model-details.component';

describe('VehicleModelDetailsComponent', () => {
  let component: VehicleModelDetailsComponent;
  let fixture: ComponentFixture<VehicleModelDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VehicleModelDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VehicleModelDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
