import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { BrandsComponent } from "./brands.component";
import { BrandsFormComponent } from "./brands-form/brands-form.component";

const routes: Routes = [
  {
    path: 'brands', children: [
      { path: '', component: BrandsComponent },
      { path: 'create', component: BrandsFormComponent },
      { path: 'edit/:id', component: BrandsFormComponent }
    ]
  },
];

@NgModule({
  imports: [
    RouterModule.forChild(routes),
  ],
  exports: [
    RouterModule
  ]
})
export class BrandsRoutingModule { }
