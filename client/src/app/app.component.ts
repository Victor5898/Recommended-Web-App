import { HttpClient } from '@angular/common/http';
import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { User } from './_models/user';
import { AccountService } from './_services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css', '../assets/css/bootstrap.min.css',
    '../assets/css/owl.carousel.min.css',
    '../assets/css/style.css',
    '../assets/css/responsive.css']
})
export class AppComponent implements OnInit
{
  title = 'client';
  restaurants: any;

  constructor(private http: HttpClient, private accountService: AccountService, private router: Router)
  {

  }

  ngOnInit()
  {
    this.setCurrentUser();
  }

  setCurrentUser() {
    const user: User = JSON.parse(localStorage.getItem('user'))
    this.accountService.setCurrentUser(user);
  }

  hasRoute(route: string) {
    return this.router.url.includes(route);
  }

  onActivate(event) {
    // window.scroll(0,0);
 
    window.scroll({ 
            top: 0, 
            left: 0, 
            behavior: 'smooth' 
     });
 }

}
