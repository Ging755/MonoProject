import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VehicleModelCreateComponent } from './vehicle-model-create.component';

describe('VehicleModelCreateComponent', () => {
  let component: VehicleModelCreateComponent;
  let fixture: ComponentFixture<VehicleModelCreateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VehicleModelCreateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VehicleModelCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
