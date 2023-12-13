import { TestBed } from '@angular/core/testing';

import { accountService } from './account.service';

describe('accountService', () => {
  let service: accountService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(accountService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
