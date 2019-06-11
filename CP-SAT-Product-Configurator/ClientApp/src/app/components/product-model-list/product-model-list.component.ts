import { ProductModelService } from 'src/app/shared/product-model-service';
import { ProductModel } from './../../shared/product-model';
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { MatTableDataSource, MatPaginator, MatSort } from '@angular/material';
import { DataSource } from '@angular/cdk/table';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-product-model-list',
  templateUrl: './product-model-list.component.html',
  styleUrls: ['./product-model-list.component.css']
})
export class ProductModelListComponent implements AfterViewInit, OnInit {


  productModelList: ProductModel[];
  displayedColumns: string[] = ['id', 'code', 'modelName', 'modelType', 'modelEngineType', 'basePrice', 'action' ];

  dataSource: MatTableDataSource<ProductModel>;

  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  @ViewChild(MatSort, {static: false}) sort: MatSort;


  constructor(private pmService: ProductModelService) {

    this.pmService.getAll().subscribe( (data) => {
      this.productModelList = data;
      this.dataSource = new MatTableDataSource<ProductModel>(this.productModelList);
      setTimeout(() => {this.dataSource.paginator = this.paginator; this.dataSource.sort = this.sort; }, 0);

    });

  }


  ngOnInit(): void {
    // this.dataService.getPolicies().subscribe((result)=>{   this.dataSource  =  result.body;  })

 }
  ngAfterViewInit(): void {

  }

  delete(index: number, e) {
    if (window.confirm('Are you sure')) {
      const data = this.dataSource.data;
      data.splice((this.paginator.pageIndex * this.paginator.pageSize) + index, 1);
      this.dataSource.data = data;
      this.pmService.delete(e.id).subscribe();
    }
  }


}

export class ProductModelDataSource extends DataSource<any> {
  constructor(private ds: ProductModelService) { super(); }
  connect(): Observable<ProductModel[]> { return this.ds.getAll(); }
  disconnect() {}
}
