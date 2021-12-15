import { User } from "./user";

export interface Image{
    id:number,
    name: string,
    description:string,
    data:string,
    created:Date,
    updated:Date,
    deleted:boolean,
    Item:{
        id:number,
        name: string,
        description:string,
        created:Date,
        updated:Date,
        deleted:boolean,
    },

    createdUser:User["createdUser"],
    updatedUser:User["updatedUser"],
}