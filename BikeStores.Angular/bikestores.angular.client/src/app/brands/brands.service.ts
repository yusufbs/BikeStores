import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Brand } from './brand';

@Injectable({
  providedIn: 'root'
})
export class BrandsService {

  private apiUrl = 'https://localhost:7243/api/brands';

  constructor(private http: HttpClient) { }

  getBrands(): Observable<Brand[]> {
    return this.http.get<Brand[]>(this.apiUrl);
  }

  createBrand(item: Brand): Observable<Brand> {
    return this.http.post<Brand>(this.apiUrl, item);
  }

  updateBrand(item: Brand): Observable<Brand> {
    return this.http.put<Brand>(`${this.apiUrl}/${item.brandId}`, item);
  }

  deleteBrand(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
