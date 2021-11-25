import { Restaurant } from "./retaurant";
import { TypeUnit } from "./typeunit";
import { User } from "./user";

export interface Unit{
    id:number,
    name: string,
    description:string,
    created:Date,
    updated:Date,
    deleted:boolean,
    unitType:TypeUnit,
    restaurantDTO:Restaurant,
    createdUser:User["createdUser"],
   updatedUser:User["updatedUser"],
}