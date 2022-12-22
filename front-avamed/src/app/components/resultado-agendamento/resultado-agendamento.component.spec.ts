import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ResultadoAgendamentoComponent } from './resultado-agendamento.component';

describe('ResultadoAgendamentoComponent', () => {
  let component: ResultadoAgendamentoComponent;
  let fixture: ComponentFixture<ResultadoAgendamentoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ResultadoAgendamentoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ResultadoAgendamentoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
