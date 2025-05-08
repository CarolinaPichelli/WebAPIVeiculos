import { TestBed } from '@angular/core/testing';

import { AssistenciaService } from './assistencia.service';

describe('AssistenciaService', () => {
  let service: AssistenciaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AssistenciaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
