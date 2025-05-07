import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlanosHomeComponent } from './planos-home.component';

describe('PlanosHomeComponent', () => {
  let component: PlanosHomeComponent;
  let fixture: ComponentFixture<PlanosHomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PlanosHomeComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PlanosHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
