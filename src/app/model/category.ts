import { Restaurant } from "./retaurant";
import { User } from "./user";


export interface Category{
  id:number,
  name: string,
  description:string,
  created:Date,
  updated:Date,
  deleted:boolean,
  categoryType:{
      id:number;
      name: string;
      description:string;
      created:Date;
      updated:Date;
      deleted:boolean;
  }
  restaurant:{
      id:number;
      name: string;
      description:string;
      phone:string;
      address:string;
      created:Date;
      updated:Date;
      deleted:boolean;
  }
  createdUser:User["createdUser"],
 updatedUser:User["updatedUser"],
}