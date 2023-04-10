import { Component } from '@angular/core';
import { Employee } from '../employee';
import { EmployeeService } from '../employee.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.scss']
})
export class EmployeeComponent {
  EmployeeList:Employee[]=[];
  NewEmployee:Employee=new Employee();
  EditEmployee:Employee=new Employee();
  constructor(private employeeservice:EmployeeService){}
  ngOnInit()
  {
    this.Getall();
  }
  Getall()
  {
    this.employeeservice.GetEmployee().subscribe(
      (Response)=>{
        this.EmployeeList=Response;
        console.log(this.EmployeeList);
      },
      (error)=>{
        console.log(error);
      }
    );
  }
  
  SaveEmployee(){
    
    this.employeeservice.postEmployee(this.NewEmployee).subscribe(
      (response)=>{
this.Getall();
this.NewEmployee.name="";
this.NewEmployee.address="";
this.NewEmployee.phoneNumber="";

      }
    )
  }
  
  EditClick(employee:Employee)
  {
    //alert(Student.name)
    this.EditEmployee=employee;
  }
  UpdateClick()
  {
    alert(this.EditEmployee.name)
    this.employeeservice.updateEmployee(this.EditEmployee).subscribe(
      (response)=>{
        this.Getall();
      },
      (error)=>{
        console.log(error);
      }
    )
  }
  deleteclick(id:number)
  {
    Swal.fire({  
      title: 'Are you sure want to remove?',  
      text: 'You will not be able to recover this file!',  
      icon: 'warning',  
      showCancelButton: true,  
      confirmButtonText: 'Yes, delete it!',  
      cancelButtonText: 'No, keep it'  
    }).then((result) => {  
      if (result.value) {  
        this.employeeservice.DeleteEmployee(id).subscribe(
      
          (response)=>{
            
         
          this.Getall();
        }
        )
        Swal.fire(  
          'Deleted!',  
          'Your imaginary file has been deleted.',  
          'success'  
        )  
      } else if (result.dismiss === Swal.DismissReason.cancel) {  
        Swal.fire(  
          'Cancelled',  
          'Your imaginary file is safe :)',  
          'error'  
        )  
      }  
    })  
   
  }

}
