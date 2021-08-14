import { TestBed } from '@angular/core/testing';

import { SKUService } from './sku.service';

describe('SKUService', () => {
  let service: SKUService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SKUService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
