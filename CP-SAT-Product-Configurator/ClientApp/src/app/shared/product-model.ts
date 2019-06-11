export class ProductModel {
  constructor(
    public id: string,
    public code: string,
    public modelName: string,
    public modelType: string,
    public modelEngineType: string,
    public customerRating: number,
    public internalRating: number,
    public basePrice: number,
    public description: string
    ) {
  }
}
