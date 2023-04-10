import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { ContactComponent } from './contact/contact.component';
import { EmployeeComponent } from './employee/employee.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { JwtActiveguardService } from './jwt-activeguard.service';

const routes: Routes = [
  {path:"",component:HomeComponent},
  {path:"home",component:HomeComponent,canActivate:[JwtActiveguardService]},
  {path:"about",component:AboutComponent,canActivate:[JwtActiveguardService]},
  {path:"contact",component:ContactComponent},
  {path:"employee",component:EmployeeComponent,canActivate:[JwtActiveguardService]},

  {path:"login",component:LoginComponent},
  {path:"register",component:RegisterComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
