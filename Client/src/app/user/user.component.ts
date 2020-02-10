import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserService } from '../services/user.service';
import { UserLoginModel } from '../models/user';
import { Employee } from '../models/employee';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit {

  constructor(private service: UserService) { }

  ngOnInit() {
  }

  idField: string;
  responseString: string = null;  
  id: number;

  user: UserLoginModel;
  users: UserLoginModel[];

  login: string;
  password: string;  

  CheckGet(){

    if (this.id == null) {
      this.GetAll();
    }
    else {
      this.GetById();
    }
  }

  Add(){

    const user: UserLoginModel = {
      login: this.login,
      password: this.password
    }
    this.service.Add(user)
                .subscribe();
  }

  Delete() {

    this.service.Delete(this.id).subscribe();

    this.id = null;
  }

  GetById() {
    
    this.users = null;
    this.service.GetById(this.id).subscribe(data => {
      
      this.users = [data];
      console.log(this.users.length)
    }, err => {

      if (err.status == 500){
        
      this.responseString = "Check input data\nPerhaps this user doesn't exist";
      }
    })
  }

  GetAll() {
    
    this.users = null;
    this.service.GetAll().subscribe(data => {
            
      this.users = data
    }, err => {
      
      console.log(err.status)
    });

  
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
