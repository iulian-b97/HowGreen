import { Component, OnInit } from '@angular/core';
import { ProsumatorService } from '../services/prosumator.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-prosumator',
  templateUrl: './prosumator.component.html',
  styleUrls: ['./prosumator.component.css']
})
export class ProsumatorComponent implements OnInit {

  userName:any;

  constructor(public prosumatorService: ProsumatorService, public userService: UserService) { }

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
    this.prosumatorService.sendMessageProvider(this.userName).subscribe(
      (res: any) => {
        console.log(res);
      },
      (error) => {
        console.log(error.error);
    }
    );
  }
}
