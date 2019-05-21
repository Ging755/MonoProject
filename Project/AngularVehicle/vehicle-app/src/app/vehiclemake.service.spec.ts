import { TestBed } from '@angular/core/testing';

import { VehiclemakeService } from './vehiclemake.service';

describe('VehiclemakeService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: VehiclemakeService = TestBed.get(VehiclemakeService);
    expect(service).toBeTruthy();
  });
});
