import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CatogoryComponent } from './catogory/catogory.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { OrderComponent } from './order/order.component';

import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { RestaurantComponent } from './restaurant/restaurant.component';
import { RoleComponent } from './role/role.component';
import {StatusComponent} from './status/status.component';
import { UnitComponent } from './unit/unit.component';
import { UserComponent } from './user/user.component';


const routes: Routes = [
  
  {path: 'restaurant',component:RestaurantComponent},
  {path:'role',component:RoleComponent},
  {path:'status',component:StatusComponent},
  {path:'user', component:UserComponent},
  {path:'unit', component:UnitComponent},
  {path:'catogory', component:CatogoryComponent},
  {path:'order', component:OrderComponent},
  {path:'login', component:LoginComponent},
  {path:'',component:HomeComponent},
  {path:'**',component:PageNotFoundComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
