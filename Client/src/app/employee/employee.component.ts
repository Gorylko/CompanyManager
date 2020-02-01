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


  id: number;

  EnterpriseId: number;
  FirstName: string;
  LastName: string;
  Position: string;
  Salary: number;

  constructor(private service: EmployeeService) { }

  ngOnInit() {
  }
  
  Add(){

    const employee: Employee = {
      EnterpriseId: this.EnterpriseId,
      FirstName: this.FirstName,
      LastName: this.LastName,
      Position: this.Position,
      Salary: this.Salary
    }

    this.service.Add(employee)
                .subscribe();
  }

  Delete() {

    this.service.Delete(this.id)
                .subscribe()
  }

  GetById() {

    this.service.GetById(this.id)
                .subscribe(data => this.employee = data);
  }

  GetAll() {

    this.service.GetAll()
                .subscribe(data => this.employees = data);
  }

  Update() {

    const employee: Employee = {
      EnterpriseId: this.EnterpriseId,
      FirstName: this.FirstName,
      LastName: this.LastName,
      Position: this.Position,
      Salary: this.Salary
    }

    this.service.Update(employee)
                .subscribe();
  }
}
