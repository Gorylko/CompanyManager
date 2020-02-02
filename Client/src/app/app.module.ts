import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule }   from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EnterpriseComponent } from './enterprise/enterprise.component';
import { EmployeeComponent } from './employee/employee.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { EnterpriseService } from './services/enterprise.service';
import { PurchaseComponent } from './purchase/purchase.component';
import { WorkAreaComponent } from './work-area/work-area.component';
import { UserComponent } from './user/user.component';

@NgModule({
  declarations: [
    AppComponent,
    EnterpriseComponent,
    EmployeeComponent,
    PurchaseComponent,
    WorkAreaComponent,
    UserComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule, 
    FormsModule,
    BrowserAnimationsModule,    
    MatInputModule, 
    MatButtonModule
  ],
  providers: [EnterpriseService],
  bootstrap: [AppComponent],
  exports: []
})
export class AppModule { }
