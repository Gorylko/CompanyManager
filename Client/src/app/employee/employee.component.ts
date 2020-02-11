import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../services/employee.service';
import { Employee } from '../models/employee';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.scss']
})
export class EmployeeComponent implements OnInit {

  employee: Employee;
  employees: Employee[];

  responseString: string = null;  
  id: number;

  EnterpriseId: number;
  FirstName: string;
  LastName: string;
  Position: string;
  Salary: number;

  constructor(private service: EmployeeService) { }

  ngOnInit() {
  }

  CheckGet(){

    if (this.id == null) {
      this.GetAll();
    }
    else {
      this.GetById();
    }
  }
  
  Add(){

    const employee: Employee = {
      enterpriseId: this.EnterpriseId,
      firstName: this.FirstName,
      lastName: this.LastName,
      position: this.Position,
      salary: this.Salary
    }

    this.EnterpriseId = null;
    this.FirstName = null;
    this.LastName = null;
    this.Position = null;
    this.Salary = null;

    this.service.Add(employee).subscribe(resp => {

      this.responseString = 'Index of this employee ' + resp.toString();
    }, err => {
      
      this.responseString = 'Error ' + err.status;
    });
  }

  Delete() {

    this.service.Delete(this.id).subscribe(resp => {
      this.responseString = resp.toString();
    })
  }

  GetById() {

    this.employees = null;
    this.service.GetById(this.id).subscribe(data => {

      this.employees = [data];
    }, err => {

      if (err.status == 500){

      this.responseString = "Check input data\nPerhaps this employee doesn't exist";
      }
    });


  }

  GetAll() {

    this.employees = null;
    this.service.GetAll().subscribe(data => {

      this.employees = data;
    }, err => {
      
      this.responseString = "Check input data\n" + "Status code:" + err.status;
    });
  }

  Update() {

    const employee: Employee = {
      enterpriseId: this.EnterpriseId,
      firstName: this.FirstName,
      lastName: this.LastName,
      position: this.Position,
      salary: this.Salary
    }

    this.service.Update(employee).subscribe(resp =>{
      this.responseString = resp.toString();
    }, err => {
      
      this.responseString = "Check input data\n" + "Status code:" + err.status;
    });
  }
}
