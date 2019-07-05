import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductFeatureService } from 'src/app/shared/product-features-service';
import { ProductModelFactory } from 'src/app/shared/product-model-factory';
import {Location} from '@angular/common';

@Component({
  selector: 'app-product-model-features',
  templateUrl: './product-model-features.component.html',
  styleUrls: ['./product-model-features.component.css']
})
export class ProductModelFeaturesComponent implements OnInit {
  engineId: number;
  engineName: string;
  categoryId: number;
  categoryName: string;
  features: any;
  features2: any;
  constructor(private location: Location, private route: ActivatedRoute, private featureService: ProductFeatureService
    // private toasterService: ToasterService,
    // private slimLoadingBarService: SlimLoadingBarService

  ) { }

  ngOnInit() {


    this.engineId = this.route.snapshot.params.engineId;
    this.engineName = ProductModelFactory.getEngineTypeName(this.engineId);

    this.categoryId = this.route.snapshot.params.categoryId;
    this.categoryName = ProductModelFactory.getCategoryTypeName(this.categoryId);


    // this.slimLoadingBarService.start();
    this.featureService.getFeatures(this.categoryId, this.engineId).subscribe((res: any) => {


    console.log(res);
    this.features = res;


  });
/*
    this.featureService.getFeatures(this.categoryId, this.engineId).subscribe((data: any[]) => this.features = data,
      error => () => {
        // this.toasterService.pop('error', 'Damn', 'Something went wrong...');
      },
      () => {
        // this.toasterService.pop('success', 'Complete', 'Getting all values complete');
        // this.slimLoadingBarService.complete();
      });
  */
  }


  private logFeatures(r: any) {
    r.engines.forEach(element => {
      console.log(element.name);
      console.log(element.type);
    }
    );
  }


  cancel() {
    this.location.back();
  }

}
