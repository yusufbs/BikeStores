import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CategoriesFormComponent } from './categories-form/categories-form.component';
import { CategoriesRoutingModule } from './categories-routing.module';
import { CategoriesComponent } from './categories.component';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    CategoriesComponent,
    CategoriesFormComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    ReactiveFormsModule
  ],
  exports: [
    CategoriesRoutingModule
  ]
})
export class CategoriesModule { }
