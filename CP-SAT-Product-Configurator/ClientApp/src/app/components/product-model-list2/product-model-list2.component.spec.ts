import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductModelList2Component } from './product-model-list2.component';

describe('ProductModelList2Component', () => {
  let component: ProductModelList2Component;
  let fixture: ComponentFixture<ProductModelList2Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProductModelList2Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductModelList2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
