import { Injectable } from '@angular/core';
import { AngularFireAuth } from '@angular/fire/auth';
import { ActivatedRoute, Router } from '@angular/router';
import * as firebase from 'firebase';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  user$: Observable<firebase.default.User>;
  
  constructor(private fbAuth: AngularFireAuth, private route: ActivatedRoute, private router: Router) { 
    this.user$ = fbAuth.authState;
  }

  login() {
    this.fbAuth.signInWithPopup(new firebase.default.auth.GoogleAuthProvider()).then(x => this.router.navigate(['/']));
  }

  logout() {
    this.fbAuth.signOut();
  }

}
