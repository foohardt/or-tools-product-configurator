import { ProductModel } from './product-model';
import { ProductModelRaw } from './product-model-raw';

export class ProductModelFactory {

  static empty(): ProductModel {
    return new ProductModel(0, '', '', null, null, null, null, null, null);
  }

  static fromObject(rawProductModel: ProductModelRaw | any): ProductModel {
    return new ProductModel(
      rawProductModel.id,
      rawProductModel.code,
      rawProductModel.modelName,
      rawProductModel.modelType,
      rawProductModel.modelEngineType,
      rawProductModel.customerRating,
      rawProductModel.internalRating,
      rawProductModel.basePrice,
      rawProductModel.description
    );
  }
}
