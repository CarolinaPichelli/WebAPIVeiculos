import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditarEmpresaComponent } from './editar-empresa.component';

describe('EditarEmpresaComponent', () => {
  let component: EditarEmpresaComponent;
  let fixture: ComponentFixture<EditarEmpresaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [EditarEmpresaComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditarEmpresaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
