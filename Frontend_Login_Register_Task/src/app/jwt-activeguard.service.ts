import { JwtHelperService } from '@auth0/angular-jwt';
import { Injectable } from '@angular/core';
import { LoginService } from './login.service';
import { ActivatedRouteSnapshot, CanActivate, Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class JwtActiveguardService implements CanActivate {

  constructor(private loginservices:LoginService,private router:Router,
    private jwthelperservices:JwtHelperService) { }
   canActivate(route: ActivatedRouteSnapshot): boolean 
   {
    if(this.loginservices.isAuthenticated())
    {
      return true;
    }
    else
    {
      alert('You are not authorize to access this information')
      this.router.navigateByUrl("/login");
      return false;
    }
   }
}
