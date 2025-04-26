import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoriesComponent } from './categories/categories.component';
import { CustomersComponent } from './customers/customers.component';
import { OrdersComponent } from './orders/orders.component';
import { BrandsComponent } from './brands/brands.component';
import { BrandsFormComponent } from './brands/brands-form/brands-form.component';

const routes: Routes = [
  {
    path: 'brands', children: [
      { path: '', component: BrandsComponent },
      { path: 'create', component: BrandsFormComponent },
      { path: 'edit/:id', component: BrandsFormComponent }
    ]
  },
  { path: 'categories', component: CategoriesComponent },
  { path: 'customers', component: CustomersComponent },
  { path: 'orders', component: OrdersComponent },
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
