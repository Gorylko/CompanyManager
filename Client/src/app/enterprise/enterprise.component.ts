import { Component, OnInit } from '@angular/core';
import { Enterprise } from '../models/enterprise';

@Component({
  selector: 'app-enterprise',
  templateUrl: './enterprise.component.html',
  styleUrls: ['./enterprise.component.scss']
})

export class EnterpriseComponent implements OnInit {

  constructor(enterprise: Enterprise) { }

  

  ngOnInit() {
  }

}
