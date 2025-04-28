import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-show-all-routes',
  templateUrl: './show-all-routes.component.html',
  styleUrl: './show-all-routes.component.css'
})
export class ShowAllRoutesComponent implements OnInit {
  constructor(private router: Router) { }

  ngOnInit() {
    const routes = this.router.config;
    console.log(routes);
    this.printRouteTree(routes);
  }

  printRouteTree(routes: any[], indent: string = '') {
    routes.forEach(route => {
      console.log(indent + (route.path ? route.path : ''));
      if (route.children) {
        this.printRouteTree(route.children, indent + '  ');
      }
    });
  }
}
