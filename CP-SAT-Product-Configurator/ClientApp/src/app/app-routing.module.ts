import { ProductModelEditComponent } from './components/product-model-edit/product-model-edit.component';
import { ProductModelList2Component } from './components/product-model-list2/product-model-list2.component';

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProductModelFeaturesComponent } from './components/product-model-features/product-model-features.component';

const routes: Routes = [

{ path: '', pathMatch: 'full', redirectTo: 'product-model-list2' },
{ path: 'product-model-add', component: ProductModelEditComponent},
{ path: 'product-model-edit/:id', component: ProductModelEditComponent },
{ path: 'product-model-list2', component: ProductModelList2Component },
{ path: 'product-model-features/:categoryId/engine/:engineId', component: ProductModelFeaturesComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
