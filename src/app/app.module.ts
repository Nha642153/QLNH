import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from "@angular/router";
import { HttpClientModule } from '@angular/common/http';




import {ButtonModule} from 'primeng/button';
import {CardModule} from 'primeng/card';
import {SplitterModule} from 'primeng/splitter';
import { MenubarModule } from 'primeng/menubar';
import { InputTextareaModule} from 'primeng/inputtextarea';
import { MessagesModule } from 'primeng/messages';
import { MessageModule } from 'primeng/message';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';
import { ConfirmationService } from 'primeng/api';
import { TableModule } from 'primeng/table';
import {CalendarModule} from 'primeng/calendar';
import {SliderModule} from 'primeng/slider';
import {MultiSelectModule} from 'primeng/multiselect';
import {ContextMenuModule} from 'primeng/contextmenu';
import {DialogModule} from 'primeng/dialog';

import {ProgressBarModule} from 'primeng/progressbar';
import {InputTextModule} from 'primeng/inputtext';
import {ToolbarModule} from 'primeng/toolbar';
import {RadioButtonModule} from 'primeng/radiobutton';
import {InputNumberModule} from 'primeng/inputnumber';
import {DropdownModule} from 'primeng/dropdown';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { PageNotFoundComponent } from './page-not-found/page-not-found.component';

import { RestaurantComponent } from './restaurant/restaurant.component';
import { RoleComponent } from './role/role.component';
import { HomeComponent } from './home/home.component';

import { FormsModule } from '@angular/forms';
import { StatusComponent } from './status/status.component';

@NgModule({
  declarations: [
    AppComponent,

    PageNotFoundComponent,

    RestaurantComponent,
     RoleComponent,
     HomeComponent,
     StatusComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    RouterModule,
    HttpClientModule,

    ButtonModule,
    CardModule,
    SplitterModule,
    MenubarModule,
    InputTextareaModule,
    MessageModule,MessagesModule,
    ConfirmDialogModule,
    ToastModule,
    CalendarModule,
    SliderModule,
    ContextMenuModule,
    DialogModule,
    DropdownModule,
    ProgressBarModule,
    InputTextareaModule,
    InputTextModule,
    ToolbarModule,
    RadioButtonModule,
    InputNumberModule,
    TableModule,
  
    MultiSelectModule,

    FormsModule,
  ],
  providers: [ MessageService,ConfirmationService,],
  bootstrap: [AppComponent]
})
export class AppModule { }
