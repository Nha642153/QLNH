import { Component, OnInit } from '@angular/core';
import {Restaurant} from '../model/retaurant';
import { ConfirmationService } from 'primeng/api';
import { MessageService } from 'primeng/api';
import { DataService } from '../data.service';

@Component({
  selector: 'app-restaurant',
  templateUrl: './restaurant.component.html',
  styleUrls: ['./restaurant.component.scss'],
  styles: [`
  :host ::ng-deep .p-dialog .product-image {
      width: 150px;
      margin: 0 auto 2rem auto;
      display: block;
  }`],
  providers: [MessageService,ConfirmationService]
})
export class RestaurantComponent implements OnInit {
  restaurantDialog=false;

  restaurants: Restaurant[]=[];

  newRestaurant: Restaurant={
    id:0,
    name: '',
    description:'',
    phone:'',
    address:'',
    created:new Date(),
    updated:new Date(),
    deleted:false,
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

  restaurant:Restaurant=Object.assign({},this.newRestaurant);
  public submited=true;
  public loading=true;
  constructor(private dataService:DataService, private messageService: MessageService, private confirmationService: ConfirmationService) { }

  ngOnInit(): void {
    this.loadRestaurant();
  }
  public loadRestaurant():void{
    this.loading=true;
    this.dataService.getAllRestaurant().subscribe(data=>{
      this.restaurants=data;
      this.loading=false;
      console.log('Restaurant: ',data);
    });
  }
  openNew():void {
   console.log('openNew: ');
   this.restaurant=Object.assign({},this.newRestaurant);
    this.restaurantDialog = true;
}

  public editRestaurant(restaurants:Restaurant):void{
    console.log('edit restaurant: ', restaurants);
    this.restaurant=restaurants;
    this.restaurantDialog=true;
  }
  public deleteRestaurant(restaurant:Restaurant):void{
    console.log('delete restaurant: ',restaurant);
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete ' + restaurant.name + '?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
          restaurant.deleted=true;
          this.dataService.putRestaurant(restaurant).subscribe(data=>{
            console.log('da xoa: ',data);
            this.loadRestaurant();
            this.messageService.add({severity:'warn', summary: 'Successful', detail: 'Deleted', life: 3000});
          });
          
      }
    });
  }
  hideDialog(cancel=true,success=true):void {
    this.restaurantDialog = false;

    if(cancel){
      this.messageService.add({
        severity:'info',
        summary:'Huy',
        detail:'Khong muon them nua',
        life:3000,
      });
    }else if(success){
      this.messageService.add({
        severity:'success',
        summary:'Thành công',
        detail:'Thêm mới/chỉnh sửa thành công',
        life:3000,
      });
    }else{
      this.messageService.add({
        severity:'error',
        summary:'Loi',
        detail:'Them bi loi',
        life:3000,
      });
    }
  }
  saveRestaurant():void {
    console.log('saveRestaurant: ',this.restaurant);
    if(this.restaurant.id===0){
      this.restaurant.createdUser.id=this.dataService.loginUserId;
      this.restaurant.updatedUser.id=this.dataService.loginUserId;
      this.dataService.postRestaurant(this.restaurant).subscribe(
        (data)=>{
        console.log('return data: ',data);
        this.restaurants.push(data);
        this.hideDialog(false,true);
      },
      (error)=>{
          console.log('error');
          this.hideDialog(false,false);
      }
      );
    }else{
      this.restaurant.updatedUser.id=this.dataService.loginUserId;
      this.dataService.putRestaurant(this.restaurant).subscribe(
        (data)=>{
          console.log('return data: ',data);
           this.hideDialog(false,true);
        },(error)=>{
          console.log('error');
          this.hideDialog(false,false);
        }
      );
      
    }

    
  }
}
 


