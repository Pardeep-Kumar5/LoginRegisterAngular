import { TestBed } from '@angular/core/testing';

import { JwtintersepterService } from './jwtintercepter.service';

describe('JwtintersepterService', () => {
  let service: JwtintersepterService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(JwtintersepterService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
