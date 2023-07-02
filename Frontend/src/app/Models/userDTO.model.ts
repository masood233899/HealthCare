export class UserDTOModel {
    constructor(
      public id:number=0,
      public userName:string="",
     public password: string="",
     public token:string="",
     public role:string="",
    ){
 
     }
   }