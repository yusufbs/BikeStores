import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Brand } from '../brand';
import { BrandsService } from '../brands.service';

@Component({
  selector: 'app-brands-form',
  templateUrl: './brands-form.component.html',
  styleUrl: './brands-form.component.css'
})
export class BrandsFormComponent implements OnInit {
  form: FormGroup;
  isEdit = false;

  constructor(
    private fb: FormBuilder,
    private brandsService: BrandsService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.form = this.fb.group({
      brandName: ['', Validators.required],
    });
  }

  ngOnInit() {
    const id = this.route.snapshot.params['id'];
    if (id) {
      this.isEdit = true;
      this.brandsService.getBrands().subscribe(brands => {
        const brand = brands.find(i => i.brandId === +id);
        if (brand) this.form.patchValue(brand);
      });
    }
  }

  onSubmit() {
    if (this.form.valid) {
      const item: Brand = this.form.value;
      const operation = this.isEdit ?
        this.brandsService.updateBrand({ ...item, brandId: this.route.snapshot.params['id'] }) :
        this.brandsService.createBrand(item);

      operation.subscribe(() => this.router.navigate(['/brands']));
    }
  }

}
