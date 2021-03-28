import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule, FormsModule} from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module'
import { UserService } from './shared/user.service';
import { HomeComponent } from './home/home.component';
import { ConsumptionModule } from './consumption/consumption.module';
import { UserModule } from './user/user.module';
import { ContactModule } from './contact/contact.module';
import { PaymentModule } from './payment/payment.module';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      progressBar: true
    }),
    ConsumptionModule,
    UserModule,
    ContactModule,
    PaymentModule
  ],
  providers: [UserService],
  bootstrap: [AppComponent]
})
export class AppModule { }
