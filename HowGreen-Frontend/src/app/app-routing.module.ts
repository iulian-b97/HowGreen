import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ConsumptionComponent } from './consumption/consumption.component';
import { ContactComponent } from './contact/contact.component';
import { HomeComponent } from './home/home.component';
import { MediaComponent } from './media/media.component';
import { ProsumatorComponent } from './prosumator/prosumator.component';
import { LoginComponent } from './user/login/login.component';
import { RegisterComponent } from './user/register/register.component';
import { UserComponent } from './user/user.component';

const routes: Routes = [
  
  { path:'', redirectTo:'/home', pathMatch:'full' },
  { path:'home', component: HomeComponent},
  { path:'contact', component: ContactComponent},
  { path:'consumption', component: ConsumptionComponent },
  { path:'prosumator', component: ProsumatorComponent },
  { path:'media', component: MediaComponent },
  { path:'contact', component: ContactComponent },
  {
    path: 'user', component: UserComponent,
    children: [
      { path: 'register', component: RegisterComponent },
      { path: 'login', component: LoginComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
