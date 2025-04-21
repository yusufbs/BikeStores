import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BrandsComponent } from './brands/brands.component';
import { CategoriesComponent } from './categories/categories.component';
import { CustomersComponent } from './customers/customers.component';
import { OrdersComponent } from './orders/orders.component';

const routes: Routes = [
  { path: 'brands1', loadChildren: () => import('./brands/brands.module').then(m => m.BrandsModule) }
  { path: 'brands', component: BrandsComponent },
  { path: 'categories', component: CategoriesComponent },
  { path: 'customers', component: CustomersComponent },
  { path: 'orders', component: OrdersComponent },
//  { path: 'categories', component: CategoriesComponent },
//  { path: 'categories', component: CategoriesComponent },
//  { path: 'categories', component: CategoriesComponent },
//  { path: 'categories', component: CategoriesComponent },
//  { path: 'categories', component: CategoriesComponent },
//  { path: 'categories', component: CategoriesComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
