import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AssistenciasHomeComponent } from './assistencias-home.component';

describe('AssistenciasHomeComponent', () => {
  let component: AssistenciasHomeComponent;
  let fixture: ComponentFixture<AssistenciasHomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AssistenciasHomeComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AssistenciasHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
