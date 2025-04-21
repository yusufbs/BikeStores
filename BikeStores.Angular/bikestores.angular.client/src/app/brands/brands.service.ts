import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BrandsService {

  private apiUrl = 'https://example.com/api/users';

  constructor(private http: HttpClient) { }

  getBrands(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }
}
