import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserLoginModel } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private url: string = 'https://localhost:44337/api/v1/users';

  constructor(private httpClient: HttpClient) { }

  Add(user: UserLoginModel) {
    return this.httpClient.post<UserLoginModel>(this.url, user);
  }

  Delete(id: number) {

    return this.httpClient.delete(this.url + "/" + id);
  }

  GetById(id: number) {

    return this.httpClient.get<UserLoginModel>(this.url + "/" + id);
  }

  GetAll() {

    return this.httpClient.get<UserLoginModel[]>(this.url);
  }

  Update(user: UserLoginModel, id: number) {

    return this.httpClient.put(this.url + "/" + id, user);
  }
}
