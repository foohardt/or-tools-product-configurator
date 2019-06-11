import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductModelEditComponent } from './product-model-edit.component';

describe('ProductModelEditComponent', () => {
  let component: ProductModelEditComponent;
  let fixture: ComponentFixture<ProductModelEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProductModelEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductModelEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
