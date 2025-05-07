import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditarPlanoComponent } from './editar-plano.component';

describe('EditarPlanoComponent', () => {
  let component: EditarPlanoComponent;
  let fixture: ComponentFixture<EditarPlanoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [EditarPlanoComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditarPlanoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
