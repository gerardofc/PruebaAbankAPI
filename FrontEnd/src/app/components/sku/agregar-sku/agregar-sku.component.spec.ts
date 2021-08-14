import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AgregarSkuComponent } from './agregar-sku.component';

describe('AgregarSkuComponent', () => {
  let component: AgregarSkuComponent;
  let fixture: ComponentFixture<AgregarSkuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AgregarSkuComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AgregarSkuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
