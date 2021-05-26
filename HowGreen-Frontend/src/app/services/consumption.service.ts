import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpParams } from '@angular/common/http';



@Injectable({
  providedIn: 'root'
})
export class ConsumptionService {

  constructor(private fb: FormBuilder, private http: HttpClient, private router: Router) { }

  readonly BaseURI = 'http://localhost:51546/api';

  districtModel = this.fb.group({
    District :['']
  });

  applianceModel = this.fb.group({
    ApplianceType :[''],
    nrWatts :[''],
    hh :[''],
    mm :['']
  });


  addDistr(userName:any)
  {
    var body = {
      District: this.districtModel.value.District
    }

    const params = new HttpParams()
      .set('userName', userName.userName)

    this.districtModel.reset();

    return this.http.post(this.BaseURI+'/Consumption/AddIndexConsumption', body, {params});
  }

  addAppliance(userName:any)
  {
    var body = {
      ApplianceType: this.applianceModel.value.ApplianceType,
      nrWatts: this.applianceModel.value.nrWatts,
      hh: this.applianceModel.value.hh,
      mm: this.applianceModel.value.mm
    };

    const params = new HttpParams()
      .set('userName', userName.userName)

    this.applianceModel.reset();

    return this.http.post(this.BaseURI+'/Consumption/AddAppliance', body, {params});
  }
}

