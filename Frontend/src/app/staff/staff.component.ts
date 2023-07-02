import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { DoctorModel } from '../Models/Doctor.model';
import { InternModel } from '../Models/intern.model';
import { UserDTOModel } from '../Models/userDTO.model';
import { UserInternService } from '../Services/user-intern.service';

@Component({
  selector: 'app-staff',
  templateUrl: './staff.component.html',
  styleUrls: ['./staff.component.css']
})
export class StaffComponent {

  intern:InternModel;
  userdto:UserDTOModel;
  doctor:DoctorModel;
  id:number;


  constructor(private userInternService:UserInternService,//Injections
              private router:Router
              )
  {
    this.intern = new InternModel();
    this.userdto=new UserDTOModel();
    // this.response=new DoctorModel();
    this.doctor=new DoctorModel();
    this.id=0;
    // this.show="";
  }


  onSubmit() {
    // Handle form submission logic here
    console.log(this.doctor);
    this.intern.name=this.doctor.name;
    this.intern.role=this.doctor.role;
    this.intern.gender=this.doctor.gender;
    this.intern.email=this.doctor.email;
    this.intern.userName=this.doctor.userName;
    this.intern.userPassword=this.intern.userPassword;
    this.userInternService.updateDoctor(this.id,this.doctor).subscribe(data=>
      {
        alert('Resuest Sent Successful');

      })
      this.userInternService.updateUser(this.intern).subscribe(data=>
        {
          alert('Resuest Sent Successful');

        })

  }

}
