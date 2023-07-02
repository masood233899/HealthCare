import { Component, OnInit } from '@angular/core';
import { UserInternService } from '../Services/user-intern.service';
import { DoctorModel } from '../Models/Doctor.model';

@Component({
  selector: 'app-doctors',
  templateUrl: './doctors.component.html',
  styleUrls: ['./doctors.component.css']
})
export class DoctorsComponent implements OnInit {

  public doctor:any

  constructor(private userInternService:UserInternService
  )
{
}
  ngOnInit(): void {
    this.viewDoctor();
  }
 
  viewDoctor()
  {
    
      this.userInternService.getDoctor().subscribe(data=>
        {
               this.doctor =data;
  
        });
    
  }
  
}

