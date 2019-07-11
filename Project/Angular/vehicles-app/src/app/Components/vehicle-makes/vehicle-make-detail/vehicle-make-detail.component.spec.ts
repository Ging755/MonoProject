import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VehicleMakeDetailComponent } from './vehicle-make-detail.component';

describe('VehicleMakeDetailComponent', () => {
  let component: VehicleMakeDetailComponent;
  let fixture: ComponentFixture<VehicleMakeDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VehicleMakeDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VehicleMakeDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
