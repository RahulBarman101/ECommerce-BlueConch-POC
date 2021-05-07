import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { forkJoin } from 'rxjs';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css']
})
export class ShoppingCartComponent implements OnInit {

  items: any[];
  itemsList: any[] = [];
  prices: any[] = [];
  _:any[] = [];
  constructor(private apiService: ApiService, private router: Router) { }

  ngOnInit(): void {
    if(!this.apiService.user) {
      this.router.navigate(['/login']);
    }
    console.log(this.apiService.user);
    this.apiService.getShoppingCart(this.apiService.user['userid']).subscribe((x:any[]) => {
      this.items = x;
      console.log(x);
      for(let [i,item] of this.items.entries()) {
        this.apiService.getShoppingCartItem(item['itemId']).subscribe((x:Object) => {
          if(x) 
            this.itemsList.push(x);
            this.itemsList[i]['itemPrice'] *= this.items[i]['quantity'];
        });
      } 
    });
  }

  addQuantity(id,i,iid) {
    this.apiService.addItem(id).subscribe((x:number) => {
      this.items[i]['quantity'] = x;
      // this.itemsList[i]['itemPrice'] = this.items[i]['quantity'] = x * this.items,s;
    })
  }

  removeQuantity(id,i) {
    this.apiService.removeItem(id).subscribe((x:number) => {
      this.items[i]['quantity'] = x;
    })
  }

  confirmOrder() {
    let orders: any[] = [];
    let orderId: number;
    this.apiService.getOrderId().subscribe((x: number) => {
      orderId = x;
      for (let [i,item] of this.itemsList.entries()) {
        orders.push({
          order_id:orderId + i,
          userid: this.apiService.user['userid'],
          itemId: item['itemid'],
          quantity: this.items[i]['quantity'],
          totalPrice: item['itemPrice'] * this.items[i]['quantity'],
        });
      }
      console.log(orders);
      this.apiService.confirmOrder(orders).subscribe(x => {
        this.router.navigate(['/checkout']);
      },
      error => {
        alert(error.message);
      });
    });
    
  }
  
}
