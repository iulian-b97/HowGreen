import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from "@angular/common/http";


import { AppRoutingModule} from './app-routing.module';

import { SharedModule } from 'src/app/shared/shared.module';
import { AppComponent } from './app.component';
import { UserService } from 'src/app/services/user.service';
import { ConsumptionService } from './services/consumption.service';
import { ContactService } from './services/contact.service';
import { ProsumatorService } from './services/prosumator.service';


@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    SharedModule,
    ToastrModule.forRoot({
      progressBar: true
    }),
    BrowserAnimationsModule,
    HttpClientModule
  ],
  providers: [
    UserService,
    ConsumptionService,
    ContactService,
    ProsumatorService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
