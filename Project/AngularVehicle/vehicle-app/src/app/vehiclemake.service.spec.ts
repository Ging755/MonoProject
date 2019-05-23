import { TestBed } from '@angular/core/testing';

import { VehicleMakeService } from './vehiclemake.service';

describe('VehiclemakeService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: VehicleMakeService = TestBed.get(VehicleMakeService);
    expect(service).toBeTruthy();
  });
});
