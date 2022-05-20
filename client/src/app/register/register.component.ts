import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css',
    '../../assets/vendor/mdi-font/css/material-design-iconic-font.min.css',
    '../../assets/vendor/font-awesome-4.7/css/font-awesome.min.css',
    '../../assets/vendor/select2/select2.min.css',
    '../../assets/vendor/datepicker/daterangepicker.css']
})
export class RegisterComponent implements OnInit {
  model: any = {};

  constructor(private accountService: AccountService, private toastr: ToastrService, private router: Router) { }

  ngOnInit(): void {
  }

  register() {
    console.log(this.model);
    this.accountService.register(this.model).subscribe(response => {
      this.router.navigateByUrl("/login");
    }, error => {
      console.log(error);
      this.toastr.error(error.error);
    });
  }

}
