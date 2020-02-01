import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Purchase } from '../models/purchase';

@Injectable({
  providedIn: 'root'
})
export class PurchaseService {

  private url: string = 'https://localhost:44337/api/purchases';

  constructor(private httpClient: HttpClient) { }

  Add(purchase: Purchase) {
    this.httpClient.post<Purchase>(this.url, purchase);
  }

  Delete(id: number) {

    this.httpClient.delete(this.url + "/" + id);
  }

  GetById(id: number) {

    return this.httpClient.get<Purchase>(this.url + "/" + id);
  }

  GetAll() {

    return this.httpClient.get<Purchase[]>(this.url);
  }

  Update(enterprise: Purchase) {

    this.httpClient.put(this.url, enterprise);
  }
}
