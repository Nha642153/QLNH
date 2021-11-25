import { Component, OnInit } from '@angular/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { DataService } from '../data.service';
import { Catogory } from '../model/catogory';
import { Restaurant } from '../model/retaurant';

@Component({
  selector: 'app-catogory',
  templateUrl: './catogory.component.html',
  styleUrls: ['./catogory.component.scss'],
  styles: [`
  :host ::ng-deep .p-dialog .product-image {
      width: 150px;
      margin: 0 auto 2rem auto;
      display: block;
  }`],
})
export class CatogoryComponent implements OnInit {

  catogorys: Catogory[]=[];
  parents: Catogory[]=[];
  showParents: Catogory[]=[];
  displayCatogory:Catogory[]=[];
  CatogoryDialog=false;
  catogory:Catogory=Object.assign({},this.dataService.newCatogory);
  submited=true;
  loading=true;
  selectedParent:Catogory|undefined;
  selectedRestaurant:Restaurant | undefined ;
  restaurants:Restaurant[]=[];


  constructor(private dataService:DataService,
    private messageService: MessageService,
    private confirmationService: ConfirmationService) { }

  ngOnInit(): void {
    this.loadCatogory();
    this.loadRestaurant();
  }
  public loadRestaurant():void{
    this.dataService.getAllRestaurant().subscribe(data=>{
      this.restaurants=data;
      console.log('Restaurant: ',data);
    });
  }
  public loadCatogory():void{
    this.loading=true;
    this.dataService.getAllCatogory().subscribe(data=>{
      this.catogorys=data;
      this.parents=data;
      this.loading=false;
      console.log('Catogory: ',data);
      this.displayCatogory=this.catogorys.filter(
        (catogory)=>catogory.restaurant.id===this.selectedRestaurant?.id
      );
      
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
   this.catogory=Object.assign({},this.dataService.newCatogory);
    this.catogory.restaurant.id=this.selectedRestaurant.id;
    
   this.CatogoryDialog = true;
    }
}

  public editCatogory(catogory:Catogory):void{
    console.log('edit Catogory: ', catogory);
    this.catogory=catogory;
    this.selectedParent=this.catogory.parent;
    this.parents=this.catogorys.filter(
      (catogory)=>catogory.id!==this.catogory.id
    );
    console.log('parents: ', this.parents);
    this.CatogoryDialog=true;
  }
  public deleteCatogory(Catogory:Catogory):void{
    
    console.log('delete Catogory: ',Catogory);
    this.confirmationService.confirm({
      message: 'Are you sure you want to booked ' + Catogory.name + '?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
          Catogory.deleted=true;
          this.dataService.putCatogory(Catogory).subscribe(data=>{
            console.log('da xóa: ',data);
            this.loadCatogory();
            this.messageService.add({severity:'warn', summary: 'Successful', detail: 'Deleted', life: 3000});
          });
        }
    });
  }
  hideDialog(cancel=true,success=true):void {
    this.CatogoryDialog = false;

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
  saveCatogory():void {
    
    console.log('saveCatogory: ',this.catogory);
    if(this.catogory.id===0){
      //# tạo mới
      this.catogory.createdUser.id=this.dataService.loginUserId;
      this.catogory.updatedUser.id=this.dataService.loginUserId;
      this.catogory.parent=this.selectedParent;
      this.dataService.postCatogory(this.catogory).subscribe(
        (data)=>{
           this.displayCatogory=this.catogorys.filter(
            (catogory)=>catogory.restaurant.id===this.selectedRestaurant?.id,
                           //this.catogory.parent?.id===this.selectedParent?.id
          );
         console.log('return data: ',data);
          this.catogorys.push(data);
          this.hideDialog(false,true);
      },
      (error)=>{
          console.log('Lỗi khi thêm');
          this.hideDialog(false,false);
      }
      );
      
    }else{
      //#update
      this.catogory.updatedUser.id=this.dataService.loginUserId;
      this.dataService.putCatogory(this.catogory).subscribe(
        (data)=>{
          console.log('return data: ',data);
          this.loadCatogory();
           this.hideDialog(false,true);
        },(error)=>{
          console.log('Lỗi update');
          this.hideDialog(false,false);
        }
      );
      
    }    
  }
  public onRestaurantChange(event:any):void{
    const restaurant:Restaurant=event;
    console.log('on change Restaurant= ',restaurant);
      this.displayCatogory=this.catogorys.filter(st=>st.restaurant?.id===restaurant?.id);
   // console.log('on change this.Catogory= ', this.displayCatogory);
  }
  public onParentChange(event:any):void{
    const parent:Catogory=event;
    console.log('on change Parent= ',parent);
      this.showParents=this.catogorys.filter(st=>st.parent?.id===parent?.id);
    //console.log('on change this.Parent= ', this.showParents);
  }
}
