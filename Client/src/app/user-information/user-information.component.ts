import { Component, OnInit } from '@angular/core';
import { UserInformationService } from '../services/user-information.service';
import { UserInformation } from '../models/userInformation';

@Component({
  selector: 'app-user-information',
  templateUrl: './user-information.component.html',
  styleUrls: ['./user-information.component.scss']
})
export class UserInformationComponent implements OnInit {

  constructor(private service: UserInformationService) { }

  employee: UserInformation;
  employees: UserInformation[];

  responseString: string = null;  
  id: number;

  UserId: number;
  FirstName: string;
  LastName: string;
  PhoneNumber: string;

  ngOnInit() {
  }
  
  add(){

    const userInformation: UserInformation = {
      userId: this.UserId,
      firstName: this.FirstName,
      lastName: this.LastName,
      phoneNumber: this.PhoneNumber
    }

    this.UserId = null;
    this.FirstName = null;
    this.LastName = null;
    this.PhoneNumber = null;

    this.service.Add(userInformation).subscribe(resp => {

      this.responseString = 'Index of this employee ' + resp.toString();
    }, err => {
      
      this.responseString = 'Error ' + err.status;
    });
  }

  delete() {

    this.service.Delete(this.id).subscribe(resp => {
      this.responseString = resp.toString();
    })
  }

  getById() {

    this.employees = null;
    this.service.GetById(this.id).subscribe(data => {

      this.employees = [data];
    }, err => {

      if (err.status == 500){

      this.responseString = "Check input data\nPerhaps this employee doesn't exist";
      }
    });


  }

  getAll() {

    this.employees = null;
    this.service.GetAll().subscribe(data => {

      this.employees = data;
    }, err => {
      
      this.responseString = "Check input data\n" + "Status code:" + err.status;
    });
  }

  update() {

    const userInformation: UserInformation = {
      userInformationId: this.id,
      userId: this.UserId,
      firstName: this.FirstName,
      lastName: this.LastName,
      phoneNumber: this.PhoneNumber
    }

    this.service.Update(userInformation).subscribe(resp =>{
      this.responseString = resp.toString();
    }, err => {
      
      this.responseString = "Check input data\n" + "Status code:" + err.status;
    });
  }

}
