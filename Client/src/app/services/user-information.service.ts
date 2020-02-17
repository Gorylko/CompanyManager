import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserInformation } from '../models/userInformation';

@Injectable({
  providedIn: 'root'
})
export class UserInformationService {

  private url: string = 'https://localhost:44337/api/v1/UserInformation';

  constructor(private httpClient: HttpClient) { }

  Add(user: UserInformation) {
    return this.httpClient.post<UserInformation>(this.url, user);
  }

  Delete(id: number) {

    return this.httpClient.delete(this.url + "/" + id);
  }

  GetById(id: number) {

    return this.httpClient.get<UserInformation>(this.url + "/" + id);
  }

  GetAll() {

    return this.httpClient.get<UserInformation[]>(this.url);
  }

  Update(user: UserInformation) {

    return this.httpClient.put(this.url, user);
  }
}
