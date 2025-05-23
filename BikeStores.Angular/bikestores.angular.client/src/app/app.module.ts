import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductsComponent } from './products/products.component';
import { CustomersComponent } from './customers/customers.component';
import { StoresComponent } from './stores/stores.component';
import { OrdersComponent } from './orders/orders.component';
import { StaffsComponent } from './staffs/staffs.component';
import { StocksComponent } from './stocks/stocks.component';
import { RouterModule } from '@angular/router';
import { BrandsModule } from './brands/brands.module';
import { ShowAllRoutesComponent } from './show-all-routes/show-all-routes.component';
import { CategoriesModule } from './categories/categories.module';

@NgModule({
  declarations: [
    AppComponent,
    ProductsComponent,
    CustomersComponent,
    StoresComponent,
    OrdersComponent,
    StaffsComponent,
    StocksComponent,
    ShowAllRoutesComponent,
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule,
    RouterModule,
    BrandsModule,
    CategoriesModule
  ],
  exports: [],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
