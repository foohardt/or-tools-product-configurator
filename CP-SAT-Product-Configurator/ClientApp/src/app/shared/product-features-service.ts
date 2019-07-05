import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


import { ProductModel } from './product-model';
import { Observable } from 'rxjs';

import { environment } from 'src/environments/environment';
import { ProductFeatures } from './product-features';


@Injectable()
export class ProductFeatureService {

  constructor(private http: HttpClient) {}


  private api = environment.apiUrl;

  private apiApp = 'features';

  getFeatures<T>(category: number, engine: number): Observable<T> {
    return this.http.get<T>(`${this.api}/${this.apiApp}?category=${category}&engine=${engine}`);
  }


}
