import { Component, OnInit } from '@angular/core';
import { Restaurant} from '../model/retaurant';
import { ConfirmationService } from 'primeng/api';
import { MessageService } from 'primeng/api';
import { DataService } from '../data.service';
import { Image} from '../model/image';

import { Item } from '../model/item';
import { Category } from '../model/category';
import { DomSanitizer } from '@angular/platform-browser';
@Component({
  selector: 'app-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.scss'],
  styles: [`
  :host ::ng-deep .p-dialog .product-image {
      width: 150px;
      margin: 0 auto 2rem auto;
      display: block;
  }`],
})
export class ItemComponent implements OnInit {
  items: Item[]=[];
  displayItem:Item[]=[];
  ItemDialog=false;
  item:Item=Object.assign({},this.dataService.newItem);
  submited=true;
  loading=true;


  selectedCategory:Category| undefined ;
  Categorys:Category[]=[];
  selectedImage:Image| undefined ;
  images:Image[]=[];
  imagePath:any;
  img:any[]=[]; 
  selectedRestaurant:Restaurant | undefined ;
  restaurants:Restaurant[]=[];
  constructor(private dataService:DataService,
              private domSanitizer:DomSanitizer,
              private messageService: MessageService,
              private confirmationService: ConfirmationService) { }

  ngOnInit(): void {
    this.loadItem();
    this.loadRestaurant();
    this.loadCategory()
    this.loadItemImage();
  }
  public loadRestaurant():void{
    this.dataService.getAllRestaurant().subscribe(data=>{
      this.restaurants=data;
      console.log('Restaurant: ',data);
    });
  }
  public loadCategory():void{
    this.dataService.getAllCategory().subscribe(data=>{
      this.Categorys=data;
      console.log('Categorys: ',this.Categorys);
    });
  }
  public loadItemImage():void{
    this.dataService.getAllImage().subscribe(data=>{
      this.images=data;
      console.log('Image: ',this.images);
    
     
        // this.imagePath= this.domSanitizer.bypassSecurityTrustResourceUrl(
        //  'data:image/jpg;base64,'+this.images[2].data
        
      //); 
     }); 
     
    
  }

  public loadItem():void{
    this.loading=true;
    this.dataService.getAllItem().subscribe(data=>{
      this.items=data;
      this.loading=false;
      console.log('Item: ',this.items);
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
    this.item=Object.assign({},this.dataService.newItem);
    this.item.restaurant.id=this.selectedRestaurant.id;
    if(this.selectedCategory)
    this.item.category.id=this.selectedCategory?.id;
    if(this.selectedImage)
    this.item.itemImage.id=this.selectedImage?.id;
    this.ItemDialog = true;
    }
}

  public editItem(items:Item):void{
    console.log('edit Item: ', items);
    this.item=items;
    this.ItemDialog=true;
  }
  public deleteItem(Item:Item):void{
    
    console.log('delete Item: ',Item);
    this.confirmationService.confirm({
      message: 'Are you sure you want to booked ' + Item.name + '?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
          Item.deleted=true;
          this.dataService.putItem(Item).subscribe(data=>{
            console.log('da xóa: ',data);
            this.loadItem();
            this.messageService.add({severity:'warn', summary: 'Successful', detail: 'Deleted', life: 3000});
          }); 
        }
    });
  }
  hideDialog(cancel=true,success=true):void {
    this.ItemDialog = false;

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
  saveItem():void {
    console.log('saveItem: ',this.item);
    if(this.item.id===0){
      this.item.createdUser.id=this.dataService.loginUserId;
      this.item.updatedUser.id=this.dataService.loginUserId;
      if(this.selectedCategory){
         this.item.category.id=this.selectedCategory?.id;
      }
      if(this.selectedImage){
        this.item.itemImage.id=this.selectedImage?.id;
     }
      this.dataService.postItem(this.item).subscribe(
        (data)=>{
         
          this.displayItem=this.items.filter(
            (item)=>item.restaurant.id===this.selectedRestaurant?.id);
          //  this.Item.Category?.id===this.selectedCategory?.id);
        console.log('return data: ',data);
        this.items.push(data);
        this.hideDialog(false,true);
      },
      (error)=>{
          console.log('error');
          this.hideDialog(false,false);
      }
      );
    }else{
      this.item.updatedUser.id=this.dataService.loginUserId;
      this.dataService.putItem(this.item).subscribe(
        (data)=>{
          console.log('return data: ',data);
          this.loadItem();
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
    console.log('on change Restaurent= ',restaurant);
    
      this.displayItem=this.items.filter(st=>st.restaurant?.id===restaurant?.id);
    
    //console.log('on change this.displayRestaurant= ', this.displayItem);
  
  }
  public onChangeCategory(event:any):void{
    const Category:Category=event;
    console.log('on change Category= ',Category);
    
     // this.displayItem=this.Items.filter(st=>st.Category?.id===Category?.id);
    
    //console.log('on change this.displayRestaurant= ', this.displayItem);
  }
  public onChangeImage(event:any):void{
    const Image:Image=event;
    console.log('on change Image= ',Image);  
    this.displayItem=this.items.filter(o=>o.itemImage?.id===Image?.id);
    // this.imagePath= this.domSanitizer.bypassSecurityTrustResourceUrl(
    //   'data:image/jpg;base64,'+this.images)
    this.imagePath= this.domSanitizer.bypassSecurityTrustResourceUrl(
        'data:image/jpg;base64,'+Image.data);
    
  }
}
