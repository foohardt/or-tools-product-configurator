import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductModelFeaturesComponent } from './product-model-features.component';

describe('ProductModelFeaturesComponent', () => {
  let component: ProductModelFeaturesComponent;
  let fixture: ComponentFixture<ProductModelFeaturesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProductModelFeaturesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductModelFeaturesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
