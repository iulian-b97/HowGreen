import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class ProsumatorService {

  constructor(private fb: FormBuilder, private http: HttpClient, private router: Router) { }

  readonly BaseURI = 'http://localhost:51546/api';

  prosumatorModel = this.fb.group({
    ReceiverEmail :[''],
    Content :['']
  });


  sendMessageProvider(userName: any)
  {
    var body = {
      ReceiverEmail: this.prosumatorModel.value.ReceiverEmail,
      Content: this.prosumatorModel.value.Content
    }

    const params = new HttpParams()
      .set('userName', userName.userName)

    this.prosumatorModel.reset();

    return this.http.post(this.BaseURI+'/Contact/SendMessageProvider', body, {params});
  }
}
