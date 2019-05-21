import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VehiclemakeDetailComponent } from './vehiclemake-detail.component';

describe('VehiclemakeDetailComponent', () => {
  let component: VehiclemakeDetailComponent;
  let fixture: ComponentFixture<VehiclemakeDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VehiclemakeDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VehiclemakeDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
