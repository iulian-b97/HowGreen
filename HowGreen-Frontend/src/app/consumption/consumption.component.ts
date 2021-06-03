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
  allAppliances: any[];
  finalConsumption: any;

  constructor(public userService: UserService, public consumptionService: ConsumptionService) { }

  ngOnInit(): void {
    this.userService.getUserName().subscribe(
      (res:any) => {
        this.userName = res;
      }
    );
  }

  addDistrict() {
    this.consumptionService.addDistr(this.userName).subscribe(
      (resp) => {
          console.log(resp);
      },
      (error) => {
          console.log(error.error);
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

  onSubmit2() {
    this.consumptionService.getAppliances(this.userName).subscribe((resp: any) => {
      this.allAppliances = resp;
    });
  }

  addFinalConsumption()
  {
    this.consumptionService.addFinalCon(this.userName).subscribe(
      (resp) => {
          console.log(resp);
      },
      (error) => {
          console.log(error.error);
      }
    );

    this.consumptionService.getFinalCon(this.userName).subscribe((resp: any) => {
      this.finalConsumption = resp;
    });
  }

 /*onSubmit3() {
    this.consumptionService.getFinalCon(this.userName).subscribe((resp: any) => {
      this.finalConsumption = resp;
    });
  }*/

  onSubmit4() {
    this.consumptionService.addEnergyLabel(this.userName).subscribe(
      (resp) => {
          console.log(resp);
      },
      (error) => {
          console.log(error.error);
      }
    );
  }
}

