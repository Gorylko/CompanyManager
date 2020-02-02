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

  workArea: WorkArea;
  workAreas: WorkArea[];

  EnterpriseId: number;
  Name: string;
  Cost?: number;
  rentRrice?: number;
  Location: string; 

  Add(){

    const workArea: WorkArea = {
      EnterpriseId: this.EnterpriseId,
      Name: this.Name,
      Location: this.Location,
      Cost: this.Cost,
      rentRrice: this.rentRrice
    }

    this.service.Add(workArea)
                .subscribe();
  }

  Delete() {

    this.service.Delete(this.id)
                .subscribe()
  }

  GetById() {

    this.service.GetById(this.id)
                .subscribe(data => this.workArea = data);
  }

  GetAll() {

    this.service.GetAll()
                .subscribe(data => this.workAreas = data);
  }

  Update() {

    const workArea: WorkArea = {
      EnterpriseId: this.EnterpriseId,
      Name: this.Name,
      Cost: this.Cost,
      rentRrice: this.rentRrice,
      Location: this.Location
    }
 
    this.service.Update(workArea)
                .subscribe();
  }
}
