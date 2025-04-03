import { TestBed } from '@angular/core/testing';

import { CustomintercepterService } from './customintercepter.service';

describe('CustomintercepterService', () => {
  let service: CustomintercepterService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CustomintercepterService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
