import { TestBed } from '@angular/core/testing';

import { JwtActiveguardService } from './jwt-activeguard.service';

describe('JwtActiveguardService', () => {
  let service: JwtActiveguardService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(JwtActiveguardService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
