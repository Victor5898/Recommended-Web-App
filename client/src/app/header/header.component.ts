import { Component, OnInit } from '@angular/core';
import { take } from 'rxjs/operators';
import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit 
{
  loggedIn: boolean
  username: string
  user: User

  constructor(public accountService: AccountService) 
  {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
  }

  ngOnInit(): void 
  {
    this.getCurrentUser()
  }

  getCurrentUser()
  {
    this.accountService.currentUser$.subscribe(user =>
      {
        this.loggedIn = !!user;
      },
      error => 
      {
        console.log(error);
      }
    )}
    
  setUsername()
  {
    this.username = this.accountService.username;
  }
}
