import { TestBed } from '@angular/core/testing';

import { VehicleMakeService } from './vehicle-make.service';

describe('VehicleMakeService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: VehicleMakeService = TestBed.get(VehicleMakeService);
    expect(service).toBeTruthy();
  });
});
