import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { CategoriesService } from '../categories.service';
import { Category } from '../category';

@Component({
  selector: 'app-categories-form',
  templateUrl: './categories-form.component.html',
  styleUrl: './categories-form.component.css'
})
export class CategoriesFormComponent implements OnInit {
  form: FormGroup;
  isEdit = false;

  constructor(
    private fb: FormBuilder,
    private svc: CategoriesService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.form = this.fb.group({
      categoryName: ['', Validators.required],
    });
  }

  ngOnInit() {
    const id = this.route.snapshot.params['id'];
    if (id) {
      this.isEdit = true;
      this.svc.getAll().subscribe(categories => {
        const category = categories.find(i => i.categoryId === +id);
        if (category) this.form.patchValue(category);
      });
    }
  }

  onSubmit() {
    if (this.form.valid) {
      const item: Category = this.form.value;
      const operation = this.isEdit ?
        this.svc.update({ ...item, categoryId: this.route.snapshot.params['id'] }) :
        this.svc.create(item);

      operation.subscribe(() => this.router.navigate(['/categories']));
    }
  }

}
