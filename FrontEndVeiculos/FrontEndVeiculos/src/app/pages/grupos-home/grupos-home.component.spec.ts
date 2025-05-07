import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GruposHomeComponent } from './grupos-home.component';

describe('GruposHomeComponent', () => {
  let component: GruposHomeComponent;
  let fixture: ComponentFixture<GruposHomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [GruposHomeComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GruposHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
