import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Category } from './category';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {

  private apiUrl = 'https://localhost:7243/api/categories';

  constructor(private http: HttpClient) { }

  getAll(): Observable<Category[]> {
    return this.http.get<Category[]>(this.apiUrl);
  }

  create(item: Category): Observable<Category> {
    return this.http.post<Category>(this.apiUrl, item);
  }

  update(item: Category): Observable<Category> {
    return this.http.put<Category>(`${this.apiUrl}/${item.categoryId}`, item);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
