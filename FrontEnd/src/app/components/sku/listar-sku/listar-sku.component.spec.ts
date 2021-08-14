import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListarSkuComponent } from './listar-sku.component';

describe('ListarSkuComponent', () => {
  let component: ListarSkuComponent;
  let fixture: ComponentFixture<ListarSkuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListarSkuComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListarSkuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
