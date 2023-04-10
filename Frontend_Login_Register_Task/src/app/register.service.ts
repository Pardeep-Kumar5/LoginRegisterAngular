import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Register } from './register';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  constructor(private httpclient:HttpClient) { }
  Register(newregister:Register):Observable<Register>
  {
    return this.httpclient.post<Register>('https://localhost:44333/api/Register/register',newregister)
  }
}
