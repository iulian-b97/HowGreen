import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from "@angular/forms";
import { SharedModule } from '../shared/shared.module'; 
import { ConsumptionRoutingModule } from './consumption-routing.module';
import { ApplianceRegistrationComponent } from './appliance-registration/appliance-registration.component';
import { ConsumptionComponent } from './consumption.component';



@NgModule({
  declarations: [
    ApplianceRegistrationComponent, 
    ConsumptionComponent
  ],
  imports: [
    ConsumptionRoutingModule,
    SharedModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class ConsumptionModule { }
