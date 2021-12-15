import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoryComponent } from './category/category.component';
import { GuestableComponent } from './guestable/guestable.component';

import { HomeComponent } from './home/home.component';
import { ImageComponent } from './image/image.component';
import { ItemComponent } from './item/item.component';
import { LoginComponent } from './login/login.component';
import { MenuItemComponent } from './menu-item/menu-item.component';
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
  {path:'category', component:CategoryComponent},
  {path:'order', component:OrderComponent},
  {path:'image', component:ImageComponent},
  {path:'login', component:LoginComponent},
  {path:'item', component:ItemComponent},
  {path:'menu-item', component:MenuItemComponent},
  {path:'guestable', component:GuestableComponent},
  {path:'',component:HomeComponent},
  {path:'**',component:PageNotFoundComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
