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

  Name: string;
  Description: string;

  ngOnInit() {
  }

  log(){

    const enterprise: Enterprise = {
      Name: this.Name,
      Description: this.Description
    }

    this.service.Add(enterprise);
  }
}
