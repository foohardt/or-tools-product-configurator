import { ProductModel } from './../../shared/product-model';
import { ProductModelFactory } from './../../shared/product-model-factory';
import { Component, OnInit, ViewChild, NgZone } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl, FormArray } from '@angular/forms';

import { AngularMaterialModule } from './../../material.module';
import { Router, ActivatedRoute } from '@angular/router';
import { ProductModelService } from 'src/app/shared/product-model-service';
import { ConfirmDialogModel, ConfirmDialogComponent } from '../confirm-dialog/confirm-dialog.component';
import { MatDialog } from '@angular/material';

@Component({
  selector: 'app-product-model-edit',
  templateUrl: './product-model-edit.component.html',
  styleUrls: ['./product-model-edit.component.css']
})

export class ProductModelEditComponent {

  constructor(
    public fb: FormBuilder,
    private router: Router,
    private ngZone: NgZone,
    private route: ActivatedRoute,
    private pmService: ProductModelService,
    private dialog: MatDialog
  ) {
    const id: number = +this.route.snapshot.paramMap.get('id');

    if ( id > 0 ) {
    this.isUpdating = true;
    this.pmService.getSingle('' + id).subscribe(data => {
    console.log(data.id);

    this.productModelForm = this.fb.group({
        id: [{value: data.id, disabled: false }, [Validators.required]],
        code: [data.code, [Validators.required]],
        modelName: [data.modelName, [Validators.required]],
        modelType: [data.modelType, [Validators.required]],
        modelEngineType: [data.modelEngineType, [Validators.required]],
        basePrice: [data.basePrice],
        description: [data.description, [Validators.maxLength(100)]]
      });
    });
  }
  }

  productModelForm = new FormGroup(
    {
      id: new FormControl({ value: '00000', disabled: true }),
      code: new FormControl(null, [Validators.required]),
      modelName: new FormControl('', [Validators.required]),
      modelType: new FormControl('', [Validators.required]),
      modelEngineType: new FormControl('', [Validators.required]),
      basePrice: new FormControl(''),
      description: new FormControl('', [Validators.maxLength(100)])
    });


  productModel = ProductModelFactory.empty();

  isUpdating = false;

  onFormSubmit() {

    // filter empty values
    // this.productModelForm.value.code = this.productModelForm.value.code.filter(c => c);
    // this.productModelForm.value.thumbnails = this.productModelForm.value.thumbnails.filter(thumbnail => thumbnail.url);

    if (!this.productModelForm.valid) {
/*
      const dialogData = new ConfirmDialogModel('Invalid data', 'Please check your input. Something is wrong' , true);
      const dialogRef = this.dialog.open(ConfirmDialogComponent, { maxWidth: '400px', data: dialogData });

      dialogRef.afterClosed().subscribe(dialogResult => {
        if (dialogResult === true) {}   });
  */
        return;
    }



    const pm: ProductModel = ProductModelFactory.fromObject(this.productModelForm.value);

    console.log(pm);

    if (this.isUpdating) {
      this.pmService.update(pm).subscribe(res => {
        this.router.navigate(['/product-model-list'], { relativeTo: this.route });
        // this.router.navigate(['/product-model-list', pm.id], { relativeTo: this.route });
      });
    } else {
      this.pmService.create(pm).subscribe(res => {
        this.router.navigate(['/product-model-list'], { relativeTo: this.route });
        this.productModel = ProductModelFactory.empty();
        this.productModelForm.reset(ProductModelFactory.empty());
      });
    }
  }

  /*

    getAllFormData() {
    this.pmService.getData().subscribe(
      data => {
        this.data1 = data[0]
        this.data1 = data[1]
      }
      // No error or completion callbacks here. They are optional, but
      // you will get console errors if the Observable is in an error state.
    );
  }
  */

  onFormCanceled() {
    this.ngZone.run(() => this.router.navigateByUrl('/product-model-list2'));
  }

  public handleError = (controlName: string, errorName: string) => {
    return this.productModelForm.controls[controlName].hasError(errorName);
  }

}
