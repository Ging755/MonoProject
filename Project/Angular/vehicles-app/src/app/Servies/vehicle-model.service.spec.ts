import { TestBed } from '@angular/core/testing';

import { VehicleModelService } from './vehicle-model.service';

describe('VehicleModelService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: VehicleModelService = TestBed.get(VehicleModelService);
    expect(service).toBeTruthy();
  });
});
