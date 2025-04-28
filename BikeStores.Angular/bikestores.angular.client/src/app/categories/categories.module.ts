import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CategoriesFormComponent } from './categories-form/categories-form.component';
import { CategoriesRoutingModule } from './categories-routing.module';
import { CategoriesComponent } from './categories.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    CategoriesComponent,
    CategoriesFormComponent
  ],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    CategoriesRoutingModule
  ]
})
export class CategoriesModule { }
