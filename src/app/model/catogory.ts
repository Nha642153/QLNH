import { Restaurant } from "./retaurant";


export interface Catogory{
  id: number;
  name: string;
  description: string;
  created: Date;
  updated: Date;
  deleted: boolean;

  parent?: Catogory;
  children?: Catogory;
  restaurant: Restaurant;
  createdUser:{
    id:number,
    userName:string,
    description:string,
    created: Date,
    updated: Date,
    deleted:boolean,
    createdUserId:number,
    updatedUserId:number,
  },
updatedUser:{
    id:number,
    userName:string,
    description:string,
    created: Date,
    updated: Date,
    deleted:boolean,
    createdUserId:number,
    updatedUserId:number,
  },
}