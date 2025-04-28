import { NgModule } from '@angular/core';
import { BrandsComponent } from './brands.component';
import { BrandsFormComponent } from './brands-form/brands-form.component';
import { CommonModule } from '@angular/common';
import { BrandsRoutingModule } from './brands-routing.module';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    BrandsComponent,
    BrandsFormComponent
  ],
  exports: [
    BrandsRoutingModule
  ],
  imports: [
    CommonModule,
    RouterModule,
    ReactiveFormsModule
  ]
})
export class BrandsModule { }
