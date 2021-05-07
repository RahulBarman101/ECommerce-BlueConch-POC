import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  port: number = 44348;
  userUrl: string = `https://localhost:${this.port}/api/user/`
  itemUrl: string = `https://localhost:${this.port}/api/item/`
  cartUrl: string = `https://localhost:${this.port}/api/cart/`
  orderUrl: string = `https://localhost:${this.port}/api/order/`
  constructor(private http: HttpClient) { }
  userName: string;
  user: Object;

  authenticateUser(user) {
    let headers = {'Content-Type':'application/json','Accept':'application/json'};
    let httpParams = new HttpParams().set('username',user['username']).set('passwd',user['passwd']);
    // console.log(httpParams.toString());
    return this.http.get(this.userUrl+'login',{
      headers: headers,
      params: httpParams,
      responseType: 'json',
    });
  }

  addNewUser(user) {
    return this.http.post(this.userUrl,user);
  }

  getAllItems() {
    return this.http.get(this.itemUrl);
  }

  getItem(id) {
    return this.http.get(this.itemUrl+id);
  }

  getCategories() {
    return this.http.get(this.itemUrl + 'categories');
  }

  addToCart(order_item) {
    let order = {
      userId: this.user['userid'],
      itemid: order_item['itemid'],
      quantity: 1,
      totalPrice: order_item['itemPrice']
    }
    return this.http.post(this.cartUrl,order);
  } 

  getShoppingCart (id: number) {
    return this.http.get(this.cartUrl+id);
  }

  getShoppingCartItem(id: number) {
    return this.http.get(this.itemUrl+id);
  }

  addItem(id: number) {
    return this.http.post(this.cartUrl+'add/'+id,{});
  }

  removeItem(id: number) {
    return this.http.post(this.cartUrl+'remove/'+id,{});
  }

  confirmOrder(order) {
    return this.http.post(this.orderUrl,order);
  }

  getOrderId() {
    return this.http.get(this.orderUrl+"order-id");
  }
}
