import { NgModule } from '@angular/core';
import { CategoriesFormComponent } from './categories-form/categories-form.component';
import { CategoriesComponent } from './categories.component';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'categories', children: [
      { path: '', component: CategoriesComponent },
      { path: 'create', component: CategoriesFormComponent },
      { path: 'edit/:id', component: CategoriesFormComponent }
    ]
  },
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes),
  ],
  exports: [
    RouterModule
  ]
})
export class CategoriesRoutingModule { }
