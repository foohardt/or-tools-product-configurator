import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { retry, map, catchError } from 'rxjs/operators';


import { ProductModel } from './product-model';
import { ProductModelRaw } from './product-model-raw';
import { ProductModelFactory } from './product-model-factory';
import { throwError, Observable } from 'rxjs';

import { environment } from 'src/environments/environment';


@Injectable()
export class ProductModelService {

  private api = environment.apiUrl;

  private apiApp = 'models';

  constructor(private http: HttpClient) {}

  getAll(): Observable<Array<ProductModel>> {
    return this.http
      .get<ProductModelRaw[]>(`${this.api}/${this.apiApp}`)
      .pipe(
        retry(3),
        map(rawData => rawData
          .map(productModelRaw => ProductModelFactory.fromObject(productModelRaw)),
        ),
        catchError(this.errorHandler)
      );
  }

  getAll2(): Observable<Array<ProductModel>> {
    return this.http
      .get<ProductModelRaw[]>(`${this.api}/${this.apiApp}`)
      .pipe(
        retry(3),
        map(rawData => rawData
          .map(productModelRaw => ProductModelFactory.fromObject(productModelRaw)),
        ),
        catchError(this.errorHandler)
      );
  }


  getSingle(id: string): Observable<ProductModel> {
    return this.http
      .get<ProductModelRaw>(`${this.api}/${this.apiApp}/${id}`)
      .pipe(
        retry(3),
        map(rawData => ProductModelFactory.fromObject(rawData)),
        catchError(this.errorHandler)
      );
  }

  check(isbn: string): Observable<boolean> {
    return this.http
      .get(`${this.api}/${this.apiApp}/${isbn}/check`)
      .pipe(
        catchError(this.errorHandler)
      );
  }

  create(productModel: ProductModel): Observable<any> {
    return this.http
      .post(`${this.api}/${this.apiApp}`, productModel, { responseType: 'text' })
      .pipe(
        catchError(this.errorHandler)
      );
  }

  update(productModel: ProductModel): Observable<any> {
    return this.http
      .put(`${this.api}/${this.apiApp}/${productModel.id}`, productModel, { responseType: 'text' })
      .pipe(
        catchError(this.errorHandler)
      );
  }

  delete(id: number): Observable<any> {
    return this.http
      .delete(`${this.api}/${this.apiApp}/${id}`, { responseType: 'text' })
      .pipe(
        catchError(this.errorHandler)
      );
  }

  private errorHandler(error: Error | any): Observable<any> {
    return throwError(error);
  }

  getAllSearch(searchTerm: string): Observable<Array<ProductModel>> {
    return this.http
      .get<ProductModelRaw[]>(`${this.api}/${this.apiApp}/search/${searchTerm}`)
      .pipe(
        retry(3),
        map(rawModels => rawModels
          .map(rawModel => ProductModelFactory.fromObject(rawModel)),
        ),
        catchError(this.errorHandler)
      );
  }
}
