import { Component, OnInit } from '@angular/core';
import { Restaurant} from '../model/retaurant';
import { ConfirmationService } from 'primeng/api';
import { MessageService } from 'primeng/api';
import { DataService } from '../data.service';
import { Image} from '../model/image';

import { Item } from '../model/item';
import { Category } from '../model/category';
import { DomSanitizer } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import { GuestTable } from '../model/guestTable';
import { Status } from '../model/status';
import { identifierModuleUrl, ThrowStmt } from '@angular/compiler';
@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.scss'],
  styles: [`
  :host ::ng-deep .p-dialog .product-image {
      width: 150px;
      margin: 0 auto 2rem auto;
      display: block;
  }`],
})
export class OrderComponent implements OnInit {
  items: Item[]=[];
  displayItem:Item[]=[];
  ItemDialog=false;
  item:Item=Object.assign({},this.dataService.newItem);
  submited=true;
  loading=true;
  soLuong:number=1;
  Total:number=0;
  subTotal:number=0;
  selectedCategory:Category| undefined ;
  Categorys:Category[]=[];

  selectedImage:Image| undefined ;
  images:Image[]=[];
  imagePath:any;
  img:any[]=[]; 
  selectedRestaurant:Restaurant | undefined ;
  restaurants:Restaurant[]=[];
  selectedGuestTable: Status|undefined;
  status:Status[]=[];
  filterCategory: Category[] | undefined;
  selectedItem: Item[] | undefined;
  orderItem: Item[]=[];
  
  constructor(private dataService:DataService,
    private router:Router,private route: ActivatedRoute,
    private domSanitizer:DomSanitizer,
    private messageService: MessageService,
    private confirmationService: ConfirmationService) { }

  ngOnInit(): void {
    this.loadItem();
    this.loadRestaurant();
    this.loadCategory();
    this.loadStatus();
    // this.loadItemImage();
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
      this.filterCategory=data;
      this.loading=false;
      console.log('Categorys: ',data);
    });
  }
  public loadStatus():void{
    this.dataService.getAllStatus().subscribe(data=>{
      this.status=data;
      console.log('Table: ',this.status);
    });
  }
  public loadItem():void{
    this.loading=true;
    this.dataService.getAllItem().subscribe(data=>{
      this.items=data;
      this.selectedItem=this.items;
      this.items.forEach((item)=>{
        this.loadImage(item);
      });
      this.loading=false;
      console.log('Item: ',this.items);
    });
  }
  orderForTable(table:Status):void{
    this.selectedGuestTable=table;
    console.log('order this.selectTable: ',this.selectedGuestTable);
  }
  clearFilter():void{
    this.filterCategory=this.Categorys;
    this.selectedItem=this.items;
  }
  Cancel(){
    this.orderItem=this.items=[];
    this.subTotal=0;
  }
  onPrint(){
    window.print();
}

  loadImage(item:Item):void{
    this.dataService.getAllImage().subscribe(data=>{
      this.imagePath= this.domSanitizer.bypassSecurityTrustResourceUrl(
        'data:image/jpg;base64,'+item.itemImage.data);
        
      //item.itemImage.data=this.domSanitizer.bypassSecurityTrustResourceUrl('data:image/jpg;base64,'+data[0].data;
    });
  }
  selecteCategory(category:Category):void{
    console.log('selectCategory: ',category);
    this.filterCategory=this.filterCategory?.filter(
      cat=>cat.id===category.id
    );
    this.selectedItem=this.items.filter(i=>i.category.id===category.id)
    //this.selectedCategory=category;
    console.log('order this.item-selectCategory: ',this.selectedItem);
    ///
   // this.items.filter(i=>i.category.id===category.id)
    //console.log(this.items);
  }
  order(item:Item):void{
    let orderExit=false;
    var orderCount=1;
    for (let i in this.orderItem){
      if(this.orderItem[i].id===item.id){
        orderCount=this.orderItem[i].discount++
        console.log(orderCount);
        this.Total=parseInt(this.orderItem[i].price)*orderCount
        console.log('exe: ',this.Total)
        orderExit=true;
        this.subTotal+=this.Total
        console.log('tong: ',this.subTotal)
        
      }
    }
    if(!orderExit){
      this.orderItem.push(item);
      orderCount=1
      this.Total=parseInt(item.price)
      this.subTotal+=(this.Total)
    }
    
  
  
    // this.Total=0
    // this.orderItem.forEach(item=>{
    //   this.Total+=(parseInt(item.price))
    // })
    console.log('order item ',this.orderItem);
   }
  public upQuality(soLuong:Number){
   this.soLuong++
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
