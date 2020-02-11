import { Component, OnInit } from '@angular/core';
import { PurchaseService } from '../services/purchase.service';
import { Purchase } from '../models/purchase';

@Component({
  selector: 'app-purchase',
  templateUrl: './purchase.component.html',
  styleUrls: ['./purchase.component.scss']
})
export class PurchaseComponent implements OnInit {

  constructor(private service: PurchaseService) { }

  ngOnInit() {
  }

  responseString: string = null;  
  id: number;

  purchase: Purchase;
  purchases: Purchase[];

  EnterpriseId: number;
  Name: string;
  Cost: number;
  RentPrice: number;
  Income: number;  

  CheckGet(){

    if (this.id == null) {
      this.GetAll();
    }
    else {
      this.GetById();
    }
  }

  Add(){

    const purchase: Purchase = {
      enterpriseId: this.EnterpriseId,
      name: this.Name,
      cost: this.Cost,
      rentPrice: this.RentPrice,
      income: this.Income
    }

    this.EnterpriseId = null;
    this.Name = null;
    this.Cost = null;
    this.RentPrice  = null;
    this.Income = null;
 
    this.service.Add(purchase).subscribe(resp => {

      this.responseString = 'Index of this purchase ' + resp.toString();
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

    this.service.GetById(this.id).subscribe(data => {
      
      this.purchases = [data]
    }, err => {

      if (err.status == 500){

      this.responseString = "Check input data\nPerhaps this purchase doesn't exist";
      }
    });
  }

  GetAll() {

    this.service.GetAll().subscribe(data => {

      this.purchases = data;
    }, err => {
      
      this.responseString = "Check input data\n" + "Status code:" + err.status;
    });
  }

  Update() {

    const purchase: Purchase = {
      enterpriseId: this.EnterpriseId,
      name: this.Name,
      cost: this.Cost,
      rentPrice: this.RentPrice,
      income: this.Income
    }
 
    this.service.Update(purchase).subscribe(resp =>{
      this.responseString = resp.toString();
    }, err => {
      
      this.responseString = "Check input data\n" + "Status code:" + err.status;
    });
  }
}
