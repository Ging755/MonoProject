import { TestBed } from '@angular/core/testing';

import { VehiclemodelService } from './vehiclemodel.service';

describe('VehiclemodelService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: VehiclemodelService = TestBed.get(VehiclemodelService);
    expect(service).toBeTruthy();
  });
});
