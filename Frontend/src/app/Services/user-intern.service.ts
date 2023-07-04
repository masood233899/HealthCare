import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserDTOModel } from '../Models/userDTO.model';
import { InternModel } from '../Models/intern.model';
import { Observable } from 'rxjs/internal/Observable';
import { DoctorModel } from '../Models/Doctor.model';
import { DoctorTableModel } from '../Models/DoctorTable.model';
import { Booking } from '../Models/Booking.Model';

@Injectable({
  providedIn: 'root'
})
export class UserInternService {

  id:number | undefined;
  name:any;

  constructor(private httpClient:HttpClient) {
    this.id=Number(localStorage.getItem("this.internID"))
    this.name=localStorage.getItem("name");

   }

   userlogin(user:UserDTOModel){
    return this.httpClient.post("https://localhost:7232/api/Users/LogIN/login",user);
   }

   userRegister(intern:InternModel):Observable<any>
   {
    return this.httpClient.post("https://localhost:7232/api/Users/Register",intern);
   }

  //  doctorRegister(doctor:DoctorTableModel):Observable<any>
  //  {
  //   return this.httpClient.post("https://localhost:7232/api/Doctors",doctor);

  //  }

  doctorRegister(doctor: DoctorTableModel): Observable<any> {
    const headers = new HttpHeaders({
      "accept": "text/plain",
      'Content-Type': 'application/json',
      'Authorization': 'Bearer ' + localStorage.getItem('token') // Add a space after 'Bearer'
    });
  
    const url = 'https://localhost:7232/api/Doctors';
  
    return this.httpClient.post<any>(url, doctor, { headers });
  }
  
   staffRegister(doctor:DoctorModel):Observable<any>
   {
    return this.httpClient.post("https://localhost:7232/api/Doctors/staff",doctor);

   }
   getStaffs():Observable<any>
   {
    return this.httpClient.get("https://localhost:7232/api/Doctors");

   }

   deleteStaffInList(intern:InternModel):Observable<any>
   {
    return this.httpClient.post("https://localhost:7232/api/Doctors/deleteStaffinlist",intern);
   }


   getDoctor(): Observable<any> //Pass the token by the header to authorize
    {
        const headers = new HttpHeaders({
          'Content-Type': 'application/json',
          'Authorization': 'Bearer ' + localStorage.getItem('token')
        });
    
        const url = 'https://localhost:7232/api/Doctors/getDoctor';
    
        return this.httpClient.get<any>(url, { headers });
    }

    updateUser(updatedDetail: any):Observable<any>
    {
      let url = 'https://localhost:7232/api/Users/UpdateUser/' + this.id;
      return this.httpClient.put(url, updatedDetail);
    }
    
    updateDoctor(doctorid:number,updatedDetail: any):Observable<any>
    {
      let url = 'https://localhost:7232/api/Users/UpdateUser/' + doctorid;
      return this.httpClient.put(url, updatedDetail);
    }
     
    getDoctorbyname():Observable<any>
    {
      https://localhost:7232/api/Doctors/getdotorbyname?name=Banner%40123
      return this.httpClient.get("https://localhost:7232/api/Doctors/getdotorbyname?name="+this.name);


    }
    
    getTimeslot():Observable<any>
    {
      return this.httpClient.get("https://localhost:7232/api/TimeSlots");

    }
    bookappointment(book:Booking):Observable<any>
    {
      return this.httpClient.post("https://localhost:7232/api/Bookings",book);

    }

}