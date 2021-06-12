import { TestBed } from '@angular/core/testing';

import { ProsumatorService } from './prosumator.service';

describe('ProsumatorService', () => {
  let service: ProsumatorService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProsumatorService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
