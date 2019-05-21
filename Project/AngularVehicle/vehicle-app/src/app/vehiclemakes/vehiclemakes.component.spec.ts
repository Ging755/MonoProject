import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VehiclemakesComponent } from './vehiclemakes.component';

describe('VehiclemakesComponent', () => {
  let component: VehiclemakesComponent;
  let fixture: ComponentFixture<VehiclemakesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VehiclemakesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VehiclemakesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
