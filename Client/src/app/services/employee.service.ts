import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Employee } from '../models/employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private url: string = "https://localhost:44337/api/employees";

  constructor(private httpClient: HttpClient) { }

  Add(employee: Employee) {

    return this.httpClient.post(this.url, employee);
  }

  Delete(id: number) {

    return this.httpClient.delete(this.url + "/" + id);
  }

  GetById(id: number) {

    return this.httpClient.get<Employee>(this.url + "/" + id);
  }

  GetAll() {

    return this.httpClient.get<Employee[]>(this.url);
  }

  Update(employee: Employee) {

    return this.httpClient.put(this.url, employee);
  }
}
