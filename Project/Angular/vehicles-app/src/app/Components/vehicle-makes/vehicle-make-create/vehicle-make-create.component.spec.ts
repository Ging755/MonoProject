import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VehicleMakeCreateComponent } from './vehicle-make-create.component';

describe('VehicleMakeCreateComponent', () => {
  let component: VehicleMakeCreateComponent;
  let fixture: ComponentFixture<VehicleMakeCreateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VehicleMakeCreateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VehicleMakeCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
