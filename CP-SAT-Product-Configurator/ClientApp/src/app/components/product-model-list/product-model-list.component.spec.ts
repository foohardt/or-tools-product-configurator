import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductModelListComponent } from './product-model-list.component';

describe('ProductModelListComponent', () => {
  let component: ProductModelListComponent;
  let fixture: ComponentFixture<ProductModelListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProductModelListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductModelListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
