import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ResultadoProfissionaisComponent } from './resultado-profissionais.component';

describe('ResultadoProfissionaisComponent', () => {
  let component: ResultadoProfissionaisComponent;
  let fixture: ComponentFixture<ResultadoProfissionaisComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ResultadoProfissionaisComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ResultadoProfissionaisComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
