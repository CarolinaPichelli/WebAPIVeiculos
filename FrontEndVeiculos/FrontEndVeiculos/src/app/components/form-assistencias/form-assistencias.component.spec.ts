import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormAssistenciasComponent } from './form-assistencias.component';

describe('FormAssistenciasComponent', () => {
  let component: FormAssistenciasComponent;
  let fixture: ComponentFixture<FormAssistenciasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FormAssistenciasComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FormAssistenciasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
