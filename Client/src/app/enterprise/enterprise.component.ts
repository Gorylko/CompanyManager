import { Component, OnInit } from '@angular/core';
import { Enterprise } from '../models/enterprise';
import { EnterpriseService } from '../services/enterprise.service';

@Component({
  selector: 'app-enterprise',
  templateUrl: './enterprise.component.html',
  styleUrls: ['./enterprise.component.scss']
})

export class EnterpriseComponent implements OnInit {

  constructor(private service: EnterpriseService) { }

  enterprises: Enterprise[];
  getEnterprise: Enterprise;

  responseString: string;
  id: number;

  Name: string;
  Description: string;

  ngOnInit() {
  }

  add(){
    const enterprise: Enterprise = {
      name: this.Name,
      description: this.Description
    }

    this.Name = null;
    this.Description = null;

    this.service.Add(enterprise).subscribe(resp => {

      this.responseString = 'Index of this employee ' + resp.toString();
    }, err => {
      
      this.responseString = 'Error ' + err.status;
    });
  }

  getById() {

    this.enterprises = null;
    this.service.GetById(this.id).subscribe(data => {
      this.enterprises = [data]
    }, err => {

      if (err.status == 500){

      this.responseString = "Check input data\nPerhaps this employee doesn't exist";
      }
    });
  }

  delete() {

    this.service.Delete(this.id).subscribe(resp => {
      this.responseString = resp.toString();
    });
    
    this.id = null;
  }

  update() { 

    const enterprise: Enterprise = {
      name: this.Name,
      description: this.Description
    }

    this.Name = null;
    this.Description = null;

    this.service.Update(enterprise, this.id).subscribe(resp =>{
      this.responseString = resp.toString();
    }, err => {
      
      this.responseString = "Check input data\n" + "Status code:" + err.status;
    });
  }

  getAll() { 

    this.enterprises = null;
    this.service.GetAll().subscribe(data => {

      this.enterprises = data
    }, err => {
      
      this.responseString = "Check input data\n" + "Status code:" + err.status;
    });
  }
}
