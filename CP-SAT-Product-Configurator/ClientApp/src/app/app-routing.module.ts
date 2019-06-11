import { ProductModelEditComponent } from './components/product-model-edit/product-model-edit.component';
import { ProductModelListComponent } from './components/product-model-list/product-model-list.component';
import { ProductModelList2Component } from './components/product-model-list2/product-model-list2.component';

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [

{ path: '', pathMatch: 'full', redirectTo: 'product-model-list2' },
{ path: 'product-model-add', component: ProductModelEditComponent},
{ path: 'product-model-edit/:id', component: ProductModelEditComponent },
{ path: 'product-model-list', component: ProductModelListComponent },
{ path: 'product-model-list2', component: ProductModelList2Component }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
