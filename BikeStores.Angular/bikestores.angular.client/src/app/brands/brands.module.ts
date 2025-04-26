import { NgModule } from '@angular/core';
import { BrandsComponent } from './brands.component';
import { BrandsFormComponent } from './brands-form/brands-form.component';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';



@NgModule({
  declarations: [
    BrandsComponent,
    BrandsFormComponent
  ],
  exports: [
    BrandsComponent,
    BrandsFormComponent
  ],
  imports: [
    RouterModule,
    CommonModule
  ]
})
export class BrandsModule { }
