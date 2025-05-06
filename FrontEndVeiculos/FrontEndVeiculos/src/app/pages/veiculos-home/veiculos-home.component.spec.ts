import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VeiculosHomeComponent } from './veiculos-home.component';

describe('VeiculosHomeComponent', () => {
  let component: VeiculosHomeComponent;
  let fixture: ComponentFixture<VeiculosHomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [VeiculosHomeComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VeiculosHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
