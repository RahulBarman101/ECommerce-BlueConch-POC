import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SharedDataService {
  constructor() { }

  
  private Name : string;
  public get value() : string {
    return this.Name;
  }
  public set value(v : string) {
    this.Name = v;
  }
  
}
