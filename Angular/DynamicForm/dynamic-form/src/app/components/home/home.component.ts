import { Component, inject, OnInit } from '@angular/core';
import {
  JsonFormData,
  JsonFormComponent,
} from '../json-form/json-form.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [JsonFormComponent, HttpClientModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
})
export class HomeComponent implements OnInit {
  jsonFormData: JsonFormData;

  constructor() {
    // Initialize formData with an empty object or a default value
    this.jsonFormData = { controls: [] };
  }

  http = inject(HttpClient);

  ngOnInit(): void {
    this.http
      .get<JsonFormData>('/assets/my-form.json')
      .subscribe((data: JsonFormData) => {
        this.jsonFormData = data;
      });
  }
}
