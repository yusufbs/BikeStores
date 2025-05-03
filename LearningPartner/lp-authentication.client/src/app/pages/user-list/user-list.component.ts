import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrl: './user-list.component.css',
})
export class UserListComponent implements OnInit {
  userList: any[] = [];
  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getUsers();
  }

  getUsers() {
    this.http.get('https://localhost:7224/api/user/getUsers').subscribe({
      next: (res: any) => {
        this.userList = res;
      },
      error: (e) => {
        alert(e.error);
      },
      complete: () => console.log('All Users Listed'),
    });
  }
}
