import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { RootNavComponent } from 'src/app/root-nav/root-nav.component';
import { HomeComponent } from 'src/app/home/home.component';
import { ContactComponent } from 'src/app/contact/contact.component';
import { ProsumatorComponent } from '../prosumator/prosumator.component';
import { ConsumptionComponent } from 'src/app/consumption/consumption.component';
import { UserComponent } from 'src/app/user/user.component';
import { RegisterComponent } from 'src/app/user/register/register.component';
import { LoginComponent } from 'src/app/user/login/login.component';

import {ReactiveFormsModule,FormsModule} from '@angular/forms';


@NgModule({
  declarations: [
    RootNavComponent,
    HomeComponent,
    ContactComponent,
    ConsumptionComponent,
    UserComponent,
    RegisterComponent,
    LoginComponent,
    ProsumatorComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    ReactiveFormsModule,
    FormsModule
  ],
  exports: [
    CommonModule,
    RouterModule,
    RootNavComponent,
    HomeComponent,
    ContactComponent,
    ProsumatorComponent,
    ConsumptionComponent,
    UserComponent,
    RegisterComponent,
    LoginComponent,
    ReactiveFormsModule,
    FormsModule
  ]
})
export class SharedModule { }
