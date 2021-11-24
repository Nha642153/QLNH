import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs';
import { Restaurant } from './model/retaurant';
import { Role } from './model/role';
import { Status } from './model/status';
import { User } from './model/user';
import { Unit } from './model/unit';
import { TypeUnit } from './model/typeunit';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  
  private REST_APIs=environment.api;
  private httpOptions={
    headers:new HttpHeaders({
      'Content-Type':'application/json',
    }),
  };
  public loginUserId=2;
  public newRestaurant:Restaurant={
    id:0,
    name:'',
    description:'',
    phone:'',
    address:'',
    created:new Date(),
    updated:new Date(),
    deleted:false,
    createdUser:{
      id:this.loginUserId,
      userName:'',
      description:'',
      created:new Date(),
      updated:new Date(),
      deleted:false,
      createdUserId:0,
      updatedUserId:0,
    },
    updatedUser:{
      id:this.loginUserId,
      userName:'',
      description:'',
      created:new Date(),
      updated:new Date(),
      deleted:false,
      createdUserId:0,
      updatedUserId:0,
    }
  };
  public newStatus:Status={
    id:0,
    name: '',
    description:'',
    phone:'',
    address:'',
    created:new Date(),
    updated:new Date(),
    deleted:false,
    restaurantDTO:{
      id:0,
      name:'',
      description:'',
      phone:'',
      address:'',
      created:new Date(),
      updated:new Date(),
      deleted:false,
    },
    createdUser:{
      id:0,
      userName:'',
      description:'',
      created:new Date(),
      updated:new Date(),
      deleted:false,
      createdUserId:0,
      updatedUserId:0,
    },
    updatedUser:{
      id:1,
      userName:'',
      description:'',
      created:new Date(),
      updated:new Date(),
      deleted:false,
      createdUserId:0,
      updatedUserId:0,
    }
  };
  public newUnit:Unit={
    id:0,
    name: '',
    description:'',
    created:new Date(),
    updated:new Date(),
    deleted:false,
    unitType:{
      id:0,
      name:'',
      description:'',
      created:new Date,
      updated:new Date,
      deleted:false,
  },
    restaurantDTO:{
      id:0,
      name:'',
      description:'',
      phone:'',
      address:'',
      created:new Date(),
      updated:new Date(),
      deleted:false,
    },
    createdUser:{
      id:0,
      userName:'',
      description:'',
      created:new Date(),
      updated:new Date(),
      deleted:false,
      createdUserId:0,
      updatedUserId:0,
    },
    updatedUser:{
      id:1,
      userName:'',
      description:'',
      created:new Date(),
      updated:new Date(),
      deleted:false,
      createdUserId:0,
      updatedUserId:0,
    }
  };
  public newUser:User={
    id:0,
    userName: '',
    description:'',
    phone:'',
    address:'',
    created:new Date(),
    updated:new Date(),
    deleted:false,
    role:{
      id:0,
      name: '',
      descripion:'',
      created:new Date(),
      updated:new Date(),
      deleted:false
    },
    createdUser:{
      id:0,
      userName:'',
      description:'',
      created:new Date(),
      updated:new Date(),
      deleted:false,
      createdUserId:0,
      updatedUserId:0,
    },
    updatedUser:{
      id:1,
      userName:'',
      description:'',
      created:new Date(),
      updated:new Date(),
      deleted:false,
      createdUserId:0,
      updatedUserId:0,
    }
  };
  public newRole:Role={
    id:0,
    name:'',
    description:'',
    created:new Date(),
    updated:new Date(),
    deleted:false,
    
  };
  public newTypeUnit:TypeUnit={
    id:0,
    name:'',
    description:'',
    created:new Date(),
    updated:new Date(),
    deleted:false,
  };
  constructor(private httpClient:HttpClient) { }
  public getAllRestaurant():Observable<Restaurant[]>{
    const url=`${this.REST_APIs}/restaurant`;
    return this.httpClient.get<Restaurant[]>(url,this.httpOptions);
  }
  public postRestaurant(payload:Restaurant):Observable<Restaurant>{
    const url=`${this.REST_APIs}/restaurant`;
    return this.httpClient.post<Restaurant>(url, payload,this.httpOptions);
  }
  public putRestaurant(payload:Restaurant):Observable<Restaurant>{
    const url=`${this.REST_APIs}/restaurant`;
    return this.httpClient.put<Restaurant>(url, payload,this.httpOptions);
  }
  public getRole():Observable<Role[]>{
    const url=`${this.REST_APIs}/role`;
    return this.httpClient.get<Role[]>(url,this.httpOptions);
  }
  public postRole(payload:Role):Observable<Role>{
    const url=`${this.REST_APIs}/role`;
    return this.httpClient.post<Role>(url, payload,this.httpOptions);
  }
  public putRole(payload:Role):Observable<Role>{
  const url=`${this.REST_APIs}/role`;
  return this.httpClient.put<Role>(url, payload,this.httpOptions);
  }
  public getAllStatus():Observable<Status[]>{
    const url=`${this.REST_APIs}/status`;
    return this.httpClient.get<Status[]>(url,this.httpOptions);
  }
  public postStatus(payload:Status):Observable<Status>{
    const url=`${this.REST_APIs}/status`;
    return this.httpClient.post<Status>(url, payload,this.httpOptions);
  }
  public putStatus(payload:Status):Observable<Status>{
    const url=`${this.REST_APIs}/status`;
    return this.httpClient.put<Status>(url, payload,this.httpOptions);
  }
  public getAllUser():Observable<User[]>{
    const url=`${this.REST_APIs}/user`;
    return this.httpClient.get<User[]>(url,this.httpOptions);
  }
  public postUser(payload:User):Observable<User>{
    const url=`${this.REST_APIs}/user`;
    return this.httpClient.post<User>(url, payload,this.httpOptions);
  }
  public putUser(payload:User):Observable<User>{
    const url=`${this.REST_APIs}/user`;
    return this.httpClient.put<User>(url, payload,this.httpOptions);
  }
  public getAllUnit():Observable<Unit[]>{
    const url=`${this.REST_APIs}/Unit`;
    return this.httpClient.get<Unit[]>(url,this.httpOptions);
  }
  public postUnit(payload:Unit):Observable<Unit>{
    const url=`${this.REST_APIs}/Unit`;
    return this.httpClient.post<Unit>(url, payload,this.httpOptions);
  }
  public putUnit(payload:Unit):Observable<Unit>{
    const url=`${this.REST_APIs}/Unit`;
    return this.httpClient.put<Unit>(url, payload,this.httpOptions);
  }
  public getAllTypeUnit():Observable<TypeUnit[]>{
    const url=`${this.REST_APIs}/UnitType`;
    return this.httpClient.get<TypeUnit[]>(url,this.httpOptions);
  }
}
