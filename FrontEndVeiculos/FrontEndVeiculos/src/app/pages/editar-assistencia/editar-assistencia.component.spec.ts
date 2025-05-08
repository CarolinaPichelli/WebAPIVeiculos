import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditarAssistenciaComponent } from './editar-assistencia.component';

describe('EditarAssistenciaComponent', () => {
  let component: EditarAssistenciaComponent;
  let fixture: ComponentFixture<EditarAssistenciaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [EditarAssistenciaComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditarAssistenciaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
