import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Enterprise } from '../models/enterprise';

@Injectable({
  providedIn: 'root'
})
export class EnterpriseService {

  private url: string = 'https://localhost:44337/api/v1/enterprises';
  
  constructor(private httpClient: HttpClient) { }  

  Add(enterprise: Enterprise) {

    
    return this.httpClient.post<Enterprise>(this.url, enterprise);
  }

  Delete(id: number) {
    console.log('And im here ' + this.url + "/" + id);
    return this.httpClient.delete(this.url + "/" + id);
  }

  GetById(id: number) {

    return this.httpClient.get<Enterprise>(this.url + "/" + id);
  }

  GetAll() {

    return this.httpClient.get<Enterprise[]>(this.url);
  }

  Update(enterprise: Enterprise, id: number) {

    return this.httpClient.put<Enterprise>(this.url + "/" + id, enterprise);
  }
}
