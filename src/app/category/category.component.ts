import { Component, OnInit } from '@angular/core';
import { Restaurant} from '../model/retaurant';
import { ConfirmationService } from 'primeng/api';
import { MessageService } from 'primeng/api';
import { DataService } from '../data.service';
import { Status} from '../model/status';
import { CategoryType } from '../model/categoryType';
import { Category } from '../model/category';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.scss'],
  styles: [`
  :host ::ng-deep .p-dialog .product-image {
      width: 150px;
      margin: 0 auto 2rem auto;
      display: block;
  }`],
})
export class CategoryComponent implements OnInit {
  categorys: Category[]=[];
  displayCategory:Category[]=[];
  CategoryDialog=false;
  category:Category=Object.assign({},this.dataService.newCategory);
  submited=true;
  loading=true;

  selectedTypeCategory:CategoryType| undefined ;
  typeCategorys:CategoryType[]=[];

  selectedRestaurant:Restaurant | undefined ;
  restaurants:Restaurant[]=[];

  constructor(private dataService:DataService,
          private messageService: MessageService,
          private confirmationService: ConfirmationService) { }

  ngOnInit(): void {
    this.loadCategory();
    this.loadRestaurant();
    this.loadTypeCategory();
  }
  public loadRestaurant():void{
    this.dataService.getAllRestaurant().subscribe(data=>{
      this.restaurants=data;
      console.log('Restaurant: ',data);
    });
  }
  public loadTypeCategory():void{
    this.dataService.getAllTypeCategory().subscribe(data=>{
      this.typeCategorys=data;
      console.log('size-typeCategorys: ',this.typeCategorys);
    });
  }
  public loadCategory():void{
    this.loading=true;
    this.dataService.getAllCategory().subscribe(data=>{
      this.categorys=data;
      this.loading=false;
      console.log('Category: ',this.categorys);
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
    this.category=Object.assign({},this.dataService.newCategory);
    this.category.restaurant.id=this.selectedRestaurant.id;
    if(this.selectedTypeCategory)
    this.category.categoryType.id=this.selectedTypeCategory?.id;
    this.CategoryDialog = true;
    }
}

  public editCategory(categorys:Category):void{
    console.log('edit Category: ', categorys);
    this.category=categorys;
    this.CategoryDialog=true;
  }
  public deleteCategory(Category:Category):void{
    
    console.log('delete Category: ',Category);
    this.confirmationService.confirm({
      message: 'Are you sure you want to booked ' + Category.name + '?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        if(Category.deleted==true){
          Category.deleted=false;
          this.dataService.putCategory(Category).subscribe(data=>{
          console.log('da khoi phục: ',data);
          this.loadCategory();
          this.messageService.add({severity:'success', summary: 'Successful', detail: 'Khôi phục', life: 3000});
          });
        }
        else{
          Category.deleted=true;
          this.dataService.putCategory(Category).subscribe(data=>{
            console.log('da xóa: ',data);
            this.loadCategory();
            this.messageService.add({severity:'warn', summary: 'Successful', detail: 'Deleted', life: 3000});
          });
          
          
        } 
        }
    });
  }
  hideDialog(cancel=true,success=true):void {
    this.CategoryDialog = false;

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
  saveCategory():void {
    console.log('saveCategory: ',this.category);
    if(this.category.id===0){
      this.category.createdUser.id=this.dataService.loginUserId;
      this.category.updatedUser.id=this.dataService.loginUserId;
      if(this.selectedTypeCategory){
         this.category.categoryType.id=this.selectedTypeCategory?.id;
      }
      this.dataService.postCategory(this.category).subscribe(
        (data)=>{
         
          this.displayCategory=this.categorys.filter(
            (category)=>category.restaurant.id===this.selectedRestaurant?.id);
          //  this.Category.CategoryType?.id===this.selectedTypeCategory?.id);
        console.log('return data: ',data);
        this.categorys.push(data);
        this.hideDialog(false,true);
      },
      (error)=>{
          console.log('error');
          this.hideDialog(false,false);
      }
      );
    }else{
      this.category.updatedUser.id=this.dataService.loginUserId;
      this.dataService.putCategory(this.category).subscribe(
        (data)=>{
          console.log('return data: ',data);
          this.loadCategory();
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
    
      this.displayCategory=this.categorys.filter(st=>st.restaurant?.id===restaurant?.id);
    
    //console.log('on change this.displayRestaurant= ', this.displayCategory);
  
  }
  public onChangeTypeCategory(event:any):void{
    const categoryType:CategoryType=event;
    console.log('on change= ',categoryType);
    
     // this.displayCategory=this.Categorys.filter(st=>st.CategoryType?.id===typeCategory?.id);
    
    //console.log('on change this.displayRestaurant= ', this.displayCategory);
  
  }

}
