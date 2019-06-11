import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA} from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductModelEditComponent } from './components/product-model-edit/product-model-edit.component';
import { ProductModelListComponent } from './components/product-model-list/product-model-list.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AngularMaterialModule } from './material.module';
import { AngularFontAwesomeModule } from 'angular-font-awesome';

import { ReactiveFormsModule } from '@angular/forms';
import { ProductModelService } from './shared/product-model-service';
import { HttpClientModule } from '@angular/common/http';
import { ProductModelList2Component } from './components/product-model-list2/product-model-list2.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import { ConfirmDialogComponent } from './components/confirm-dialog/confirm-dialog.component';
import { APP_BASE_HREF } from '@angular/common';


@NgModule({
  declarations: [
    AppComponent,
    ProductModelEditComponent,
    ProductModelListComponent,
    ProductModelList2Component,
    ConfirmDialogComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule ,
    AppRoutingModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    AngularMaterialModule,
    AngularFontAwesomeModule,
    FlexLayoutModule
  ],
  // providers: [ ProductModelService, {provide: APP_BASE_HREF, useValue: '/' + (window.location.pathname.split('/')[1] || '')} ],
  providers: [ ProductModelService ],
  entryComponents: [ConfirmDialogComponent],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
