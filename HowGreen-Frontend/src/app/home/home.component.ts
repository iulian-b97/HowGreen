import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../shared/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styles: [
  ]
})
export class HomeComponent{
  
  constructor(private router:Router,private service:UserService) { }

  images = ['./assets/images/slide2.jpg', './assets/images/slide1.png', './assets/images/slide3.jpeg'];
}
