import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {HttpClient, HttpHeaders}from '@angular/common/http'
import { Employee } from './employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private httpclient:HttpClient) { }

  GetEmployee():Observable<any>
  {
    return this.httpclient.get<any>('https://localhost:44333/api/Employee')
  }
  postEmployee(newEmployee:Employee):Observable<Employee>
  {
    return this.httpclient.post<Employee>('https://localhost:44333/api/Employee',newEmployee)
  }
  updateEmployee(editEmployee:Employee):Observable<Employee>
  {
    return this.httpclient.put<Employee>('https://localhost:44333/api/Employee',editEmployee)
  }
  DeleteEmployee(id:number):Observable<any>
  {
   
    return this.httpclient.delete<any>("https://localhost:44333/api/Employee?id="+id)
  }


}
