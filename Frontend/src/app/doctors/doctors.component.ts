import { Component, OnInit } from '@angular/core';
import { UserInternService } from '../Services/user-intern.service';
import { DoctorModel } from '../Models/Doctor.model';
import { Booking } from '../Models/Booking.Model';

@Component({
  selector: 'app-doctors',
  templateUrl: './doctors.component.html',
  styleUrls: ['./doctors.component.css']
})
export class DoctorsComponent implements OnInit {
  showPopup = false;

  public doctor:any
  public time:any;
  public book:Booking;
  selectedOption: any;
  ans:any;
  findtimeid:any

  openPopup(obj:any) {
    this.book.doctorId=obj.id;
    this.showPopup = true;
  }

  closePopup() {
    this.showPopup = false;
  }

  constructor(private userInternService:UserInternService)
{
  this.book= new Booking();
  this.book.userId=Number(localStorage.getItem("this.internID"))

}
  ngOnInit(): void {
    this.viewDoctor();
    this.gettime();

  }
 
  viewDoctor()
  {
    
      this.userInternService.getDoctor().subscribe(data=>
        {
               this.doctor =data;
  
        });
    
  }
  gettime()
  {
    this.userInternService.getTimeslot().subscribe(data=>
      {
             this.time =data;

      });
  }

  getTimeslotid()
  {
    console.log(this.findtimeid);
    
   for (let i=0;i<this.time.length;i++)
   {
    if(this.findtimeid===this.time[0].addTimeSlot)
    {
      this.book.timeId=1;
      console.log("checkd")
      console.log(i)

    }
    else if(this.findtimeid===this.time[1].addTimeSlot)
    {
      this.book.timeId=2;    console.log("checkd")
      console.log(i)

  
    }
    else if(this.findtimeid===this.time[2].addTimeSlot)
    {
      this.book.timeId=3;    console.log(this.book.timeId)
      console.log(i)

    }
    else if(this.findtimeid===this.time[3].addTimeSlot)
    {
      this.book.timeId=4;    console.log("checkd")
      console.log(i)

    }
    
   } 
  
  }

  postDetails()
  {
    this.userInternService.bookappointment(this.book).subscribe(data=>
      {
             this.ans =data;
             if(this.ans!=null)
             {
              alert('Book Successful');
             }
             this.closePopup();

      });
  }
  
}

