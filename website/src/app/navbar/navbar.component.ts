import { Component, OnInit } from '@angular/core';
import { ApiService } from '../services/api.service';
import { AuthService } from '../services/auth.service';
import { SharedDataService } from '../services/shared-data.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  constructor(public auth: AuthService, public apiAuth: ApiService) { 
    
  }

  ngOnInit(): void {
    
  }

  logout() {
    this.auth.logout();
  }

  logout_() {
    this.apiAuth.user = '';
  }

}
