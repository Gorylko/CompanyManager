import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Enterprise } from '../models/enterprise';

@Injectable({
  providedIn: 'root'
})
export class EnterpriseService {

  private url: string = "http://localhost:63801/api/enterprises";
  
  constructor(private httpClient: HttpClient) { }  

  Add(enterprise: Enterprise) {

    console.log(enterprise.Description + "Здарова");
    console.log("Пока");
    return this.httpClient.post<Enterprise>(this.url, enterprise);
  }

  Delete(id: number) {

    this.httpClient.delete(this.url + "/" + id);
  }

  GetById(id: number) {

    return this.httpClient.get<Enterprise>(this.url + "/" + id);
  }

  GetAll() {

    return this.httpClient.get<Enterprise[]>(this.url);
  }

  Update(enterprise: Enterprise) {

    this.httpClient.put(this.url, enterprise);
  }
}
