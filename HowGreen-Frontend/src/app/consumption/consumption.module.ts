import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ConsumptionRoutingModule } from './consumption-routing.module';

import { ApplianceRegistrationComponent } from './appliance-registration/appliance-registration.component';
import { ConsumptionComponent } from './consumption.component';



@NgModule({
  declarations: [
    ApplianceRegistrationComponent, 
    ConsumptionComponent
  ],
  imports: [
    CommonModule,
    ConsumptionRoutingModule
  ]
})
export class ConsumptionModule { }
