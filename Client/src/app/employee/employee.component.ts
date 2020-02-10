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

  idField: string;
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
      EnterpriseId: this.EnterpriseId,
      FirstName: this.FirstName,
      LastName: this.LastName,
      Position: this.Position,
      Salary: this.Salary
    }

    this.service.Add(employee).subscribe();
  }

  Delete() {

    this.service.Delete(this.id).subscribe()
  }

  GetById() {

    this.employees = null;
    this.service.GetById(this.id).subscribe(data => {
      this.employees = [data]
    }, err => {

      if (err.status == 500){

      this.responseString = "Check input data\nPerhaps this employee doesn't exist";
      }
    });


  }

  GetAll() {

    this.employees = null;
    this.service.GetAll().subscribe(data => {
      
      this.employees = data
    }, err => {
      
      this.responseString = "Check input data\n" + "Status code:" + err.status;
    });
  }

  Update() {

    const employee: Employee = {
      EnterpriseId: this.EnterpriseId,
      FirstName: this.FirstName,
      LastName: this.LastName,
      Position: this.Position,
      Salary: this.Salary
    }

    this.service.Update(employee).subscribe(resp =>{
      this.responseString = resp.toString();
    }, err => {
      
      this.responseString = "Check input data\n" + "Status code:" + err.status;
    });
  }
}
