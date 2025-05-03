import { HttpClient } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent {
  toggleForm: boolean = false;

  registerObj: any = {
    userId: 0,
    emailId: '',
    password: '',
    createdDate: new Date(),
    fullName: '',
    mobileNo: '',
  };

  loginObj: any = {
    emailId: '',
    password: '',
  };

  http = inject(HttpClient);
  router = inject(Router);

  onRegister() {
    this.http
      .post('https://localhost:7224/api/user/CreateNewUser', this.registerObj)
      .subscribe({
        next: (res: any) => alert('Registration Successful'),
        error: (e) => {
          if (e.status == 400) {
            alert('Invalid Body');
          } else if (e.status == 500) {
            alert(e.error);
          }
        },
        complete: () => console.log('New User Registered'),
      });
  }

  onLogin() {
    this.http
      .post('https://localhost:7224/api/user/Login', this.loginObj)
      .subscribe({
        next: (res: any) => {
          alert('Login Successful');
          localStorage.setItem('userApp', JSON.stringify(res));
          this.router.navigateByUrl('user-list');
        },
        error: (e) => {
          if (e.status == 401) {
            alert(e.error);
          } else if (e.status == 500) {
            alert(e.error);
          }
        },
        complete: () => console.log('User Logged In'),
      });
  }
}
