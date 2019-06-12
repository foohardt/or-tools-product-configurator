import { KeyValue } from '@angular/common';

export class ProductModel {
  constructor(
    public id: string,
    public code: string,
    public modelName: string,
    public modelCategory: number ,
    public modelEngineType: number,
    public customerRating: number,
    public internalRating: number,
    public modelPrice: number,
    public description: string
    ) {
  }
}
