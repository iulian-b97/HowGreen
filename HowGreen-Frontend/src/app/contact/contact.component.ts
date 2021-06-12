import { Component, OnInit } from '@angular/core';
import { ContactService } from '../services/contact.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit {

  userName:any;

  constructor(public contactService: ContactService, public userService: UserService) { }

  ngOnInit(): void 
  {
    this.userService.getUserName().subscribe(
      (res: any) => {
        this.userName = res;
      }
    );
  }

  onSubmit()
  {
    this.contactService.sendMessage(this.userName).subscribe(
      (res: any) => {
        console.log(res);
      },
      (error) => {
        console.log(error.error);
    }
    );
  }
}
