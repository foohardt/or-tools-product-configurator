import { ProductModelService } from 'src/app/shared/product-model-service';
import { ProductModel } from './../../shared/product-model';
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { MatTableDataSource, MatPaginator, MatSort, MatDialog  } from '@angular/material';
import { DataSource } from '@angular/cdk/table';
import { Observable } from 'rxjs';
import { ConfirmDialogModel, ConfirmDialogComponent } from '../confirm-dialog/confirm-dialog.component';


@Component({
  selector: 'app-product-model-list2',
  templateUrl: './product-model-list2.component.html',
  styleUrls: ['./product-model-list2.component.css']
})
export class ProductModelList2Component implements AfterViewInit, OnInit {


  productModelList: ProductModel[];
  displayedColumns: string[] = ['id', 'code', 'modelName', 'modelType', 'modelEngineType', 'basePrice', 'action' ];

  public dataSource = new MatTableDataSource<ProductModel>();


  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  @ViewChild(MatSort, {static: false}) sort: MatSort;


  constructor(private pmService: ProductModelService, private dialog: MatDialog ) {

 //   this.pmService.getAll().subscribe( (data) => {
 //   this.productModelList = data;
 //   this.dataSource = new MatTableDataSource<ProductModel>(this.productModelList);
 //   setTimeout(() => {this.dataSource.paginator = this.paginator; this.dataSource.sort = this.sort; }, 0);
//    });

  }


  public getAllList = () => {
    this.pmService.getAll()
    .subscribe(res => {
      this.dataSource.data =  res as ProductModel[];
    });
  }


  ngOnInit(): void {
    // this.dataService.getPolicies().subscribe((result)=>{   this.dataSource  =  result.body;  })
    this.getAllList();

 }
  ngAfterViewInit(): void {
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;
  }


  public doFilter = (value: string) => {
    this.dataSource.filter = value.trim().toLocaleLowerCase();
  }

  delete(index: number, e: ProductModel) {
    if (window.confirm('Are you sure to delete ' + e.modelName + '?')) {
      const data = this.dataSource.data;
      data.splice((this.paginator.pageIndex * this.paginator.pageSize) + index, 1);
      this.dataSource.data = data;
      this.pmService.delete(e.id).subscribe();
    }
  }


  delete_futsch(index: number, e: ProductModel) {

    /*
    const dialogData = new ConfirmDialogModel('Please confirm deletion', 'Are you sure to delete ' + e.modelName , false);
    const dialogRef = this.dialog.open(ConfirmDialogComponent, { maxWidth: '400px', data: dialogData });

    dialogRef.afterClosed().subscribe(dialogResult => {
      if (dialogResult === true) {
        const data = this.dataSource.data;
        data.splice((this.paginator.pageIndex * this.paginator.pageSize) + index, 1);
        this.dataSource.data = data;
        this.pmService.delete(e.id).subscribe();
      }
    });
    */

  }
}

export class ProductModelDataSource extends DataSource<any> {
  constructor(private ds: ProductModelService) { super(); }
  connect(): Observable<ProductModel[]> { return this.ds.getAll(); }
  disconnect() {}
}
