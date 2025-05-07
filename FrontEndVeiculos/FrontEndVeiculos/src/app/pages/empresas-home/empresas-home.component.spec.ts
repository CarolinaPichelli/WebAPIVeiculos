import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmpresasHomeComponent } from './empresas-home.component';

describe('EmpresasHomeComponent', () => {
  let component: EmpresasHomeComponent;
  let fixture: ComponentFixture<EmpresasHomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [EmpresasHomeComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EmpresasHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
