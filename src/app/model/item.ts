import { Category } from "./category";
import { CategoryType } from "./categoryType";
import { Image } from "./image";
import { User } from "./user";

export interface Item{
    id:number,
    name: string,
    description:string,
    price:string,
    created:Date,
    updated:Date,
    deleted:boolean,
    discount:number;
    category:{
        id:number,
        name: string,
        description:string,
        created:Date,
        updated:Date,
        deleted:boolean,
        categoryType:CategoryType,
    },
    itemImage:{
        id:number;
        name: string;
        data:string,
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