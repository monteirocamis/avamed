<<<<<<< HEAD:front-avamed/src/app/service/crud.service.spec.ts
/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { CrudService } from './crud.service';

describe('Service: Crud', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CrudService]
    });
  });

  it('should ...', inject([CrudService], (service: CrudService) => {
    expect(service).toBeTruthy();
  }));
=======
import { TestBed } from '@angular/core/testing';

import { CrudService } from './crud.service';

describe('CrudService', () => {
  let service: CrudService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CrudService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
>>>>>>> 3e5923cd9e2286a88b87aa0bfb5752493c6cf77f:front-avamed/src/app/services/crud.service.spec.ts
});
