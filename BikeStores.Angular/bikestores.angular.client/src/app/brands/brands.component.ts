import { Component, OnInit } from '@angular/core';
import { Brand } from './brand';
import { BrandsService } from './brands.service';

@Component({
  selector: 'app-brands',
  templateUrl: './brands.component.html',
  styleUrl: './brands.component.css'
})
export class BrandsComponent implements OnInit {
  brands: Brand[] = [];

  constructor(private brandsService: BrandsService) { }

  ngOnInit(): void {
    return this.loadItems();
  }

  loadItems() {
    this.brandsService.getBrands().subscribe(brands => this.brands = brands);
  }

  deleteItem(brandId: number) {
    this.brandsService.deleteBrand(brandId).subscribe(() => {
      this.brands = this.brands.filter(brand => brand.brandId !== brandId);
    });
  }

}
