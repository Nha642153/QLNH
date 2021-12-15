import { Component, OnInit } from '@angular/core';
import { Restaurant} from '../model/retaurant';
import { ConfirmationService } from 'primeng/api';
import { MessageService } from 'primeng/api';
import { DataService } from '../data.service';
import { Status} from '../model/status';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-status',
  templateUrl: './status.component.html',
  styleUrls: ['./status.component.scss'],
  styles: [`
  :host ::ng-deep .p-dialog .product-image {
      width: 150px;
      margin: 0 auto 2rem auto;
      display: block;
  }`],
})
export class StatusComponent implements OnInit {
  statuss: Status[]=[];
  displayStatus:Status[]=[];
  StatusDialog=false;
  status:Status=Object.assign({},this.dataService.newStatus);
  submited=true;
  loading=true;
  selectedRestaurant:Restaurant | undefined ;
  restaurants:Restaurant[]=[];

  
 
  constructor(private dataService:DataService,
            private router:Router,private route: ActivatedRoute,
            private messageService: MessageService,
            private confirmationService: ConfirmationService) { }

  ngOnInit(): void {
    this.loadStatus();
    this.loadRestaurant();
  }
  public loadRestaurant():void{
    this.dataService.getAllRestaurant().subscribe(data=>{
      this.restaurants=data;
      console.log('Restaurant: ',data);
    });
  }
  public loadStatus():void{
    this.loading=true;
    this.dataService.getAllStatus().subscribe(data=>{
      this.statuss=data;
      this.loading=false;
      console.log('Status: ',data);
    });
  }
  openNew():void {
    if(!this.selectedRestaurant){
        this.messageService.add({
        severity:'error',
        summary:'Loi',
        detail:'Chua chon nha hang',
        life:3000,
      }); return;
    }else{
   console.log('openNew: ');
   this.status=Object.assign({},this.dataService.newStatus);
    this.status.restaurantDTO.id=this.selectedRestaurant.id;
    
   this.StatusDialog = true;
    }
}

  public editStatus(statuss:Status):void{
    console.log('edit Status: ', statuss);
    this.status=statuss;
    this.StatusDialog=true;
  }
  public orderStatus(Status:Status):void{
    this.router.navigate(['/order']);
    Status.deleted=true;
    this.dataService.putStatus(Status).subscribe(data=>{
      console.log('da cap nhat: ',data);
      this.loadStatus();
      this.messageService.add({severity:'warn', summary: 'Successful', detail: 'Trạng thái'+' '+data.name, life: 3000});
    });
  }
  public deleteStatus(Status:Status):void{
    
    console.log('delete Status: ',Status);
    this.confirmationService.confirm({
      message: Status.name +' ĐANG BẬN '+ '?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        
          Status.deleted=true;
          this.dataService.putStatus(Status).subscribe(data=>{
            console.log('da cap nhat: ',data);
            this.loadStatus();
            this.messageService.add({severity:'warn', summary: 'Successful', detail: 'Trạng thái', life: 3000});
          });
        
      //  else{
      //     Status.deleted=false
      //     this.dataService.putStatus(Status).subscribe(data=>{
      //       console.log('da cap nhat: ',data);
      //       this.loadStatus();
      //       //this.messageService.add({severity:'warn', summary: 'Successful', detail: 'Deleted', life: 3000});
      //     });
      //   }
       
      }
    });
  }
  hideDialog(cancel=true,success=true):void {
    this.StatusDialog = false;

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
  saveStatus():void {
    console.log('saveStatus: ',this.status);
    if(this.status.id===0){
      this.status.createdUser.id=this.dataService.loginUserId;
      this.status.updatedUser.id=this.dataService.loginUserId;
      this.dataService.postStatus(this.status).subscribe(
        (data)=>{
        console.log('return data: ',data);
        this.displayStatus=this.statuss.filter(
          (status)=>status.restaurantDTO.id===this.selectedRestaurant?.id);
        this.statuss.push(data);
        this.hideDialog(false,true);
      },
      (error)=>{
          console.log('error');
          this.hideDialog(false,false);
      }
      );
    }else{
      this.status.updatedUser.id=this.dataService.loginUserId;
      this.dataService.putStatus(this.status).subscribe(
        (data)=>{
          console.log('return data: ',data);
          this.loadStatus();
           this.hideDialog(false,true);
        },(error)=>{
          console.log('error');
          this.hideDialog(false,false);
        }
      );
      
    }    
  }
  public onRestaurantChange(event:any):void{
    const restaurant:Restaurant=event;
    console.log('on change= ',restaurant);
    
      this.displayStatus=this.statuss.filter(st=>st.restaurantDTO?.id===restaurant?.id);
    
    console.log('on change this.displayRestaurant= ', this.displayStatus);
  
  }
}
