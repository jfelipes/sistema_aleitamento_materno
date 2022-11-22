import { TestBed } from '@angular/core/testing';

import { LeiteMaternoService } from './leite-materno.service';

describe('LeiteMaternoService', () => {
  let service: LeiteMaternoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LeiteMaternoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
