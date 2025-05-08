import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastroAssistenciaComponent } from './cadastro-assistencia.component';

describe('CadastroAssistenciaComponent', () => {
  let component: CadastroAssistenciaComponent;
  let fixture: ComponentFixture<CadastroAssistenciaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CadastroAssistenciaComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CadastroAssistenciaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
