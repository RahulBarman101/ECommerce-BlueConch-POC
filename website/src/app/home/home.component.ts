import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit, OnDestroy {
  items$: Subscription;
  categories$: Subscription;
  items:any[];
  categories:string[];
  constructor(private apiRequest: ApiService, private router: Router) { }

  ngOnInit(): void {
    this.items$ = this.apiRequest.getAllItems().subscribe((x:any[]) => {
      this.items = x;
    });
    this.categories$ = this.apiRequest.getCategories().subscribe((x:string[]) => {
      this.categories = x;
    })
  }

  ngOnDestroy() {
    if(this.items$)
      this.items$.unsubscribe();
    if(this.categories$)
      this.categories$.unsubscribe();
  }

  addToCart(item) {
    if(this.apiRequest.user)
      this.apiRequest.addToCart(item).subscribe(x => {
        console.log(x);
      },
      error => {
        console.log("flase");
      });
    else
      alert("please login first");
  }

}
