import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VehicleMakesComponent } from './vehicle-makes.component';

describe('VehicleMakesComponent', () => {
  let component: VehicleMakesComponent;
  let fixture: ComponentFixture<VehicleMakesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VehicleMakesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VehicleMakesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
