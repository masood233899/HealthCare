import { UserModel } from "./user.model";

export class Booking
{
    constructor(
        public id:number=0,
         public name:string="",
         public date:string="",
         public userId:number=0,
         public doctorId:number=0,
         public timeId:number=0,


       ){

        }
  
}