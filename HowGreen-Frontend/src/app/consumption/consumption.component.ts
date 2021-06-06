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
  indexConsumption:any;
  indexConsumptionId:string;
  allAppliances: any[];
  finalConsumption: any;
  energyLabel: any;

  isFinalCon: boolean = false;

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
          this.indexConsumption = resp;
          //console.log(this.indexConsumptionId);
          //console.log(Object.keys(this.indexConsumption));
          var x =  Object.values(this.indexConsumption)[1];
          //this.indexConsumptionId = Object.values(this.indexConsumptionId)[1].toString.call([]);
          //console.log(y);
          this.indexConsumptionId = x.toString();
          console.log(typeof this.indexConsumptionId);
      },
      (error) => {
          console.log(error.error);
      }
    );

    /*this.consumptionService.getIndexConsumption(this.userName).subscribe(
      (res:any) => {
        this.indexConsumption = res;
        console.warn(res);
      }
    );*/
  }

  onSubmit() {
    this.consumptionService.addAppliance(this.userName, this.indexConsumptionId).subscribe(
        (resp: any) => {
            console.log(resp);
            //this.allAppliances = resp;
            //console.log(this.allAppliances);
        },
        (error) => {
            console.log(error.error);
        }
    );

    this.consumptionService.getAppliances(this.userName, this.indexConsumptionId).subscribe((resp: any) => 
    {
      this.allAppliances = resp; 
      console.log(resp)
    });
  }

  /*onSubmit2() {
    this.consumptionService.getAppliances(this.userName).subscribe((resp: any) => {
      this.allAppliances = resp;
    });
  }*/

  addFinalConsumption()
  {
    this.consumptionService.addFinalCon(this.userName, this.indexConsumptionId).subscribe(
      (resp) => {
          console.log(resp);
          this.isFinalCon = true;
          this.finalConsumption = resp;
      },
      (error) => {
          console.log(error.error);
      }
    );

    /*this.consumptionService.getFinalCon(this.userName, this.indexConsumptionId).subscribe((resp: any) => {
      this.finalConsumption = resp;
      console.log(resp);
    });*/
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

    this.consumptionService.getEnergyLab(this.userName).subscribe((resp: any) => {
      this.energyLabel = resp;
    });
  }
}

