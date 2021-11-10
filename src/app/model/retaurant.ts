export interface Restaurant{
    id:number;
    name: string;
    description:string;
    phone:string;
    address:string;
    created:Date;
    updated:Date;
    deleted:boolean;
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
      }
}