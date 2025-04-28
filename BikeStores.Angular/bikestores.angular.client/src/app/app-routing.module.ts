import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomersComponent } from './customers/customers.component';
import { OrdersComponent } from './orders/orders.component';
import { ShowAllRoutesComponent } from './show-all-routes/show-all-routes.component';

const routes: Routes = [
  { path: 'customers', component: CustomersComponent },
  { path: 'orders', component: OrdersComponent },
  { path: 'routes', component: ShowAllRoutesComponent }
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
    //RouterModule.forRoot(routes, { enableTracing: true }) // --only to debug - to be used in conjuction with show-all-routes component
  ], 
  exports: [RouterModule]
})
export class AppRoutingModule { }
