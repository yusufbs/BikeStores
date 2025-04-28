import { Component, OnInit } from '@angular/core';
import { Category } from './category';
import { CategoriesService } from './categories.service';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrl: './categories.component.css'
})
export class CategoriesComponent implements OnInit {
  items: Category[] = [];

  constructor(private svc: CategoriesService) { }

  ngOnInit(): void {
    return this.loadItems();
  }

  loadItems() {
    this.svc.getAll().subscribe(items => this.items = items);
  }

  deleteItem(categoryId: number) {
    this.svc.delete(categoryId).subscribe(() => {
      this.items = this.items.filter(category => category.categoryId !== categoryId);
    });
  }
}

