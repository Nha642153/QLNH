import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';

import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { RestaurantComponent } from './restaurant/restaurant.component';
import { RoleComponent } from './role/role.component';
import {StatusComponent} from './status/status.component';


const routes: Routes = [
  
  {path: 'restaurant',component:RestaurantComponent},
  {path:'role',component:RoleComponent},
  {path:'status',component:StatusComponent},
  {path:'',component:HomeComponent},
  {path:'**',component:PageNotFoundComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
