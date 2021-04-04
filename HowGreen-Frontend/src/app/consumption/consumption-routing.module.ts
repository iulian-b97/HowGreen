import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ConsumptionComponent } from './consumption.component' ;
import { ApplianceRegistrationComponent } from './appliance-registration/appliance-registration.component';

const routes: Routes = [
  {
    path: 'consumption', component: ConsumptionComponent,
    children: [
      { path: 'appliance-registration', component: ApplianceRegistrationComponent }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ConsumptionRoutingModule { }
