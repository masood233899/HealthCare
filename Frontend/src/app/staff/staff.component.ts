import { Component, OnInit } from '@angular/core';
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
export class StaffComponent implements OnInit {

  public doctor:any

  

  constructor(private userInternService:UserInternService,//Injections
              private router:Router
              )
  {
    
  }
  ngOnInit(): void {
  this.profile();
  }

  profile()
  {
    this.userInternService.getDoctorbyname().subscribe(data=>
      {
             this.doctor =data;

      });
  
  }


}
