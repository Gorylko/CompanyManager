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

  id: number;

  Name: string;
  Description: string;

  ngOnInit() {
  }

  Add(){
    const enterprise: Enterprise = {
      name: this.Name,
      description: this.Description
    }

    this.service.Add(enterprise)
                .subscribe();
  }

  GetById() {
    this.service.GetById(this.id)
                .subscribe(data => this.getEnterprise = data);
  }

  Delete() {
    console.log('hi btw')
    this.service.Delete(this.id)
                .subscribe();
  }

  Update() { 
    const enterprise: Enterprise = {
      name: this.Name,
      description: this.Description
    }

    this.service.Update(enterprise)
                .subscribe();
  }

  GetAll() { 
    this.service.GetAll()
                .subscribe(data => this.enterprises = data);
  }
}
