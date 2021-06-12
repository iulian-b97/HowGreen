import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';



@Injectable({
  providedIn: 'root'
})
export class ContactService {

  constructor(private fb: FormBuilder, private http: HttpClient, private router: Router) { }

  readonly BaseURI = 'http://localhost:51546/api';

  contactModel = this.fb.group({
    ReceiverEmail :[''],
    Content :['']
  });


  sendMessage(userName: any)
  {
    var body = {
      ReceiverEmail: this.contactModel.value.ReceiverEmail,
      Content: this.contactModel.value.Content
    }

    const params = new HttpParams()
      .set('userName', userName.userName)

    this.contactModel.reset();

    return this.http.post(this.BaseURI+'/Contact/SendMessage', body, {params});
  }
}
