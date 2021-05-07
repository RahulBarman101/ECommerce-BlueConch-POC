import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { ApiService } from '../services/api.service';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit, OnDestroy {

  login$: Subscription

  constructor(public auth: AuthService, public apiAuth: ApiService, private router: Router) { 
  }

  ngOnInit(): void {
  }

  // login() {
  //   this.auth.login();
  // }

  submit(f:HTMLInputElement) {
    // console.log(f.value);
      this.login$ = this.apiAuth.authenticateUser(f.value).subscribe((x:Object) => {
      if(x) {
        this.apiAuth.userName = x['firstname'];
        this.apiAuth.user = x;
        this.router.navigate(['/']);
      }
    },(error) => {
      alert('invalid username or password');
    });
  }

  ngOnDestroy() {
    if(this.login$)
      this.login$.unsubscribe();
  }

}
