import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserService } from '../services/user.service';
import { UserLoginModel } from '../models/user';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit {

  constructor(private service: UserService) { }

  ngOnInit() {
  }

  id: number;

  user: UserLoginModel;
  users: UserLoginModel[];

  login: string;
  password: string;  

  Add(){

    const user: UserLoginModel = {
      login: this.login,
      password: this.password
    }
    this.service.Add(user)
                .subscribe();
  }

  Delete() {

    this.service.Delete(this.id)
                .subscribe()
  }

  GetById() {

    this.service.GetById(this.id)
                .subscribe(data => this.user = data);
  }

  GetAll() {

    this.service.GetAll()
                .subscribe(data => this.users = data);
  }

  Update() {

    const user: UserLoginModel = {
      login: this.login,
      password: this.password
    }
 
    this.service.Update(user)
                .subscribe();
  }

}
