import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class JwtintersepterService implements HttpInterceptor{

  constructor() { }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    var CurrentUser={token:""};
    var CurrentUserSession=sessionStorage.getItem("currentuser");
    if(CurrentUserSession!=null)
    {
      CurrentUser=JSON.parse(CurrentUserSession);
    }
    req=req.clone({
      setHeaders:{
        Authorization:"Bearer "+CurrentUser.token
      }
    })
    return next.handle(req);
  }
}
