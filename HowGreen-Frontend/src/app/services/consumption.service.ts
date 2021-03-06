import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';



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

  inputLabelModel = this.fb.group({
    MP :[''],
    HouseType :['']
  })


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

  addAppliance(userName:any, indexConsumptionId:any)
  {
    var body = {
      ApplianceType: this.applianceModel.value.ApplianceType,
      nrWatts: this.applianceModel.value.nrWatts,
      hh: this.applianceModel.value.hh,
      mm: this.applianceModel.value.mm
    };

    const params = new HttpParams()
      .set('userName', userName.userName)
      .set('indexConsumptionId', indexConsumptionId)

    this.applianceModel.reset();

    return this.http.post(this.BaseURI+'/Consumption/AddAppliance', body, {params});
  }

  addFinalCon(userName:any, indexConsumptionId:any)
  {
    var body = {

    };

    const params = new HttpParams()
      .set('userName', userName.userName)
      .set('indexConsumptionId', indexConsumptionId)

      return this.http.post(this.BaseURI+'/Consumption/AddFinalConsumption', body, {params});
  }

  addEnergyLabel(userName:any, indexConsumptionId:any)
  {
    var body = {
      MP: this.inputLabelModel.value.MP,
      HouseType: this.inputLabelModel.value.HouseType
    }

    const params = new HttpParams()
      .set('userName', userName.userName)
      .set('indexConsumptionId', indexConsumptionId)

    this.inputLabelModel.reset();

    return this.http.post(this.BaseURI+'/Consumption/AddEnergyLabel', body, {params});
  }

  getIndexConsumption(userName:any): any
  {
    const params = new HttpParams()
      .set('userName', userName.userName)

      return this.http.get(this.BaseURI+'/Consumption/GetIndexConsumption', {params});
  }

  getDistrictByIndex(indexConsumptionId:any)
  {
    const params = new HttpParams()
    .set('indexConsumptionId', indexConsumptionId)

      return this.http.get(this.BaseURI+'/Consumption/GetDistrictByIndex', {params});
  }

  getDistricts(userName:any)
  {
    const params = new HttpParams()
      .set('userName', userName.userName)

      return this.http.get(this.BaseURI+'/Consumption/GetAllDistricts', {params});
  }

  getAppliances(userName:any, indexConsumptionId:any): any
  {
    const params = new HttpParams()
      .set('userName', userName.userName)
      .set('indexConsumptionId', indexConsumptionId)

      return this.http.get(this.BaseURI+'/Consumption/GetAllAppliances', {params});
  }

  getFinalCon(userName:any, indexConsumptionId:any): any
  {
    const params = new HttpParams()
      .set('userName', userName.userName)
      .set('indexConsumptionId', indexConsumptionId)

      return this.http.get(this.BaseURI+'/Consumption/GetFinalConsumption', {params});
  }

  getAllFinalCon(userName:any): any
  {
    const params = new HttpParams()
      .set('userName', userName.userName)

      return this.http.get(this.BaseURI+'/Consumption/GetAllFinalConsumptions', {params});
  }

  getEnergyLab(userName:any): any
  {
    const params = new HttpParams()
      .set('userName', userName.userName)

      return this.http.get(this.BaseURI+'/Consumption/GetEnergyLabel', {params});
  }
}

