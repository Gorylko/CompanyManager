import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { WorkArea } from '../models/workArea';

@Injectable({
  providedIn: 'root'
})
export class WorkAreaService {

  private url: string = 'https://localhost:44337/api/v1/workAreas';

  constructor(private httpClient: HttpClient) { }

  Add(workArea: WorkArea) {
    return this.httpClient.post(this.url, workArea);
  }

  Delete(id: number) {

    return this.httpClient.delete(this.url + "/" + id);
  }

  GetById(id: number) {

    return this.httpClient.get<WorkArea>(this.url + "/" + id);
  }

  GetAll() {

    return this.httpClient.get<WorkArea[]>(this.url);
  }

  Update(enterprise: WorkArea) {

    return this.httpClient.put(this.url, enterprise);
  }
}
