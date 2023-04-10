import { Component } from '@angular/core';
import { LoginService } from './login.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Frontend_Login_Register_Task';
  

  constructor(public loginservice:LoginService){}
  LogoutClick()
  {
    this.loginservice.Logout();
  }
  registerClick()
  {
    
  }
}
