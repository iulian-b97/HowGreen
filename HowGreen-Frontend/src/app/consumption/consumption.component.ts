import { Variable } from '@angular/compiler/src/render3/r3_ast';
import { Component, OnInit } from '@angular/core';
import { ConsumptionService } from '../services/consumption.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-consumption',
  templateUrl: './consumption.component.html',
  styleUrls: ['./consumption.component.css']
})
export class ConsumptionComponent implements OnInit {

  userName:any;

  constructor(public userService: UserService, public consumptionService: ConsumptionService) { }

  ngOnInit(): void {
    this.userService.getUserName().subscribe(
      (res:any) => {
        this.userName = res;
      }
    );
  }

  onSubmit() {
    this.consumptionService.addAppliance(this.userName).subscribe(
        (resp) => {
            console.log(resp);
        },
        (error) => {
            console.log(error.error);
        }
    );
  }
}
