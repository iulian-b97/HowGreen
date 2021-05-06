import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RootNavComponent } from './root-nav.component';
import { SharedModule } from 'src/app/shared/shared.module';

import { AppRoutingModule } from 'src/app/app-routing.module'; 



@NgModule({
  declarations: [
    RootNavComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    AppRoutingModule
  ]
})
export class RootNavModule { }
