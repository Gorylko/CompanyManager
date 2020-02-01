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

  id: number;

  purchase: Purchase;
  purchases: Purchase[];

  EnterpriseId: number;
  Name: string;
  Cost?: number;
  RentPrice?: number;
  Income?: number;  

  Add(){

    const purchase: Purchase = {
      EnterpriseId: this.EnterpriseId,
      Name: this.Name,
      Cost: this.Cost,
      RentPrice: this.RentPrice,
      Income: this.Income
    }

    this.service.Add(purchase)
                .subscribe();
  }

  Delete() {

    this.service.Delete(this.id)
                .subscribe()
  }

  GetById() {

    this.service.GetById(this.id)
                .subscribe(data => this.purchase = data);
  }

  GetAll() {

    this.service.GetAll()
                .subscribe(data => this.purchases = data);
  }

  Update() {

    const purchase: Purchase = {
      EnterpriseId: this.EnterpriseId,
      Name: this.Name,
      Cost: this.Cost,
      RentPrice: this.RentPrice,
      Income: this.Income
    }
 
    this.service.Update(purchase)
                .subscribe();
  }
}
