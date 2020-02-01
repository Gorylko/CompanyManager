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

  GetById(id: number) {
    this.service.GetById(this.id)
                .subscribe(data => this.getEnterprise = data);
  }
}
