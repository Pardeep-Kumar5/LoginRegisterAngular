import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, map } from 'rxjs';
import { Login } from './login';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  currentUserName:any;
  constructor(private httpclient:HttpClient,private router:Router,
    private Jwthelperservice:JwtHelperService) { }

    
  checkuser(lg:Login):Observable<Login>
  {
    debugger;
    return this.httpclient.post<Login>("https://localhost:44333/api/Register/authenticate",lg).pipe(map (u=>{
      if(u)
      {debugger;
        console.log(u);
        this.currentUserName=u.username;
        sessionStorage["currentuser"]=JSON.stringify(u);
      }
      return u;
    }))
  }


  Logout()
  {
    this.currentUserName="";
    sessionStorage.removeItem("currentuser");
    this.router.navigateByUrl("/login");
  }
  public isAuthenticated():boolean
  {
    if(this.Jwthelperservice.isTokenExpired())
    {
      return false;
    }
    else
    {
      return true;
    }
  }

}

