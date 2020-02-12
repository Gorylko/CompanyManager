import { Component, OnInit } from '@angular/core';
import { WorkAreaService } from '../services/work-area.service';
import { WorkArea } from '../models/workArea';

@Component({
  selector: 'app-work-area',
  templateUrl: './work-area.component.html',
  styleUrls: ['./work-area.component.scss']
})
export class WorkAreaComponent implements OnInit {

  constructor(private service: WorkAreaService) { }

  ngOnInit() {
  }

  id: number;
  responseString: string;

  workArea: WorkArea;
  workAreas: WorkArea[];

  EnterpriseId: number;
  Name: string;
  Cost: number;
  rentRrice: number;
  Location: string; 

  CheckGet(){

    if (this.id == null) {
      this.GetAll();
    }
    else {
      this.GetById();
    }
  }

  Add(){

    const workArea: WorkArea = {
      enterpriseId: this.EnterpriseId,
      name: this.Name,
      location: this.Location,
      cost: this.Cost,
      rentRrice: this.rentRrice
    }
    
    this.EnterpriseId = null;
    this.Name = null;
    this.Cost = null;
    this.rentRrice = null;
    this.Location = null;

    this.service.Add(workArea).subscribe(resp => {

      this.responseString = 'Index of this work area ' + resp.toString();
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

    this.workAreas = null
    this.service.GetById(this.id).subscribe(data => {
      this.workArea = data
    }, err => {

      if (err.status == 500){

      this.responseString = "Check input data\nPerhaps this employee doesn't exist";
      }
    });
  }

  GetAll() {

    this.service.GetAll().subscribe(data => {
      this.workAreas = data
    }, err => {
      
      this.responseString = "Check input data\n" + "Status code:" + err.status;
    });
  }

  Update() {

    const workArea: WorkArea = {
      enterpriseId: this.EnterpriseId,
      name: this.Name,
      cost: this.Cost,
      rentRrice: this.rentRrice,
      location: this.Location
    }
 
    this.service.Update(workArea).subscribe(resp =>{
      this.responseString = resp.toString();
    }, err => {
      
      this.responseString = "Check input data\n" + "Status code:" + err.status;
    });
  }
}
