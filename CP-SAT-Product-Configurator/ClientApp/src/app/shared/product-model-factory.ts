import { ProductModelService, ValueLabelType } from './product-model-service';
import { ProductModel } from './product-model';
import { ProductModelRaw } from './product-model-raw';

export class ProductModelFactory {

  static categoryTypes1: ValueLabelType[] = [
    { value: 1, label: 'Compact' },
    { value: 2, label: 'Sedan' },
    { value: 3, label: 'SUV' },
    { value: 4, label: 'Sportscar' },
    { value: 5, label: '4WD' },
    { value: 6, label: 'Sportscar' },
    { value: 7, label: 'Van' },
    { value: 8, label: 'Mini' },
    { value: 9, label: 'Truck' }
  ];
  // hard wired, same values as public enum ModelCategory in Model.cs
  static engineTypes1: ValueLabelType[] = [
    { value: 0, label: 'Gas' },
    { value: 1, label: 'Electric' }
  ];


  static engineTypes: string[] = ['Gas', 'Electric'];
  static categoryTypes: string[] = ['Compact', 'Sedan', 'SUV', 'Sportscar']; // , '4WD', 'Sportscar', 'Van', 'Mini', 'Truck'];

  static getCategoryTypeName(index: number): string {
    if (index >= 0 && index < ProductModelFactory.categoryTypes.length) {
      return ProductModelFactory.categoryTypes[index];
    }
    return '-';
  }

  static getEngineTypeName(index: number): string {
    if (index >= 0 && index < ProductModelFactory.engineTypes.length) {
      return ProductModelFactory.engineTypes[index];
    }
    return '-';
  }



  static empty(): ProductModel {
    return new ProductModel(null, null, null, null, null, null, null, null, null);
  }

  static fromObject(rawProductModel: ProductModelRaw | any): ProductModel {

    const pm: ProductModel = new ProductModel(
      rawProductModel.id,
      rawProductModel.code,
      rawProductModel.modelName,
      rawProductModel.modelCategory,
      rawProductModel.modelEngineType,
      rawProductModel.customerRating,
      rawProductModel.internalRating,
      rawProductModel.modelPrice,
      rawProductModel.description
    );

    pm.categoryName = ProductModelFactory.getCategoryTypeName(pm.modelCategory);
    pm.engineTypeName = ProductModelFactory.getEngineTypeName(pm.modelEngineType);

    return pm;
  }
}
