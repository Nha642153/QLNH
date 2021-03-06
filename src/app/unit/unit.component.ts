import { Component, OnInit } from '@angular/core';
import { Restaurant} from '../model/retaurant';
import { ConfirmationService } from 'primeng/api';
import { MessageService } from 'primeng/api';
import { DataService } from '../data.service';
import { Status} from '../model/status';
import { UnitType } from '../model/typeunit';
import { Unit } from '../model/unit';

@Component({
  selector: 'app-unit',
  templateUrl: './unit.component.html',
  styleUrls: ['./unit.component.scss'],
  styles: [`
  :host ::ng-deep .p-dialog .product-image {
      width: 150px;
      margin: 0 auto 2rem auto;
      display: block;
  }`],
})
export class UnitComponent implements OnInit {
  units: Unit[]=[];
  displayUnit:Unit[]=[];
  UnitDialog=false;
  unit:Unit=Object.assign({},this.dataService.newUnit);
  submited=true;
  loading=true;

  selectedTypeUnit:UnitType| undefined ;
  typeUnits:UnitType[]=[];

  selectedRestaurant:Restaurant | undefined ;
  restaurants:Restaurant[]=[];

  constructor(private dataService:DataService,
          private messageService: MessageService,
          private confirmationService: ConfirmationService) { }

  ngOnInit(): void {
    this.loadUnit();
    this.loadRestaurant();
    this.loadTypeUnit();
  }
  public loadRestaurant():void{
    this.dataService.getAllRestaurant().subscribe(data=>{
      this.restaurants=data;
      console.log('Restaurant: ',data);
    });
  }
  public loadTypeUnit():void{
    this.dataService.getAllTypeUnit().subscribe(data=>{
      this.typeUnits=data;
      console.log('size-typeUnits: ',this.typeUnits);
    });
  }
  public loadUnit():void{
    this.loading=true;
    this.dataService.getAllUnit().subscribe(data=>{
      this.units=data;
      this.loading=false;
      console.log('Unit: ',this.units);
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
    this.unit=Object.assign({},this.dataService.newUnit);
    this.unit.restaurant.id=this.selectedRestaurant.id;
    if(this.selectedTypeUnit)
    this.unit.unitType.id=this.selectedTypeUnit?.id;
    this.UnitDialog = true;
    }
}

  public editUnit(units:Unit):void{
    console.log('edit Unit: ', units);
    this.unit=units;
    this.UnitDialog=true;
  }
  public deleteUnit(Unit:Unit):void{
    
    console.log('delete Unit: ',Unit);
    this.confirmationService.confirm({
      message: 'Are you sure you want to booked ' + Unit.name + '?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        if(Unit.deleted==true){
          Unit.deleted=false;
          this.dataService.putUnit(Unit).subscribe(data=>{
          console.log('da khoi ph???c: ',data);
          this.loadUnit();
          this.messageService.add({severity:'success', summary: 'Successful', detail: 'Kh??i ph???c', life: 3000});
          });
        }
        else{
          Unit.deleted=true;
          this.dataService.putUnit(Unit).subscribe(data=>{
            console.log('da x??a: ',data);
            this.loadUnit();
            this.messageService.add({severity:'warn', summary: 'Successful', detail: 'Deleted', life: 3000});
          });
          
          
        } 
        }
    });
  }
  hideDialog(cancel=true,success=true):void {
    this.UnitDialog = false;

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
        summary:'Th??nh c??ng',
        detail:'Th??m m???i/ch???nh s???a th??nh c??ng',
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
  saveUnit():void {
    console.log('saveUnit: ',this.unit);
    if(this.unit.id===0){
      this.unit.createdUser.id=this.dataService.loginUserId;
      this.unit.updatedUser.id=this.dataService.loginUserId;
      if(this.selectedTypeUnit){
         this.unit.unitType.id=this.selectedTypeUnit?.id;
      }
      this.dataService.postUnit(this.unit).subscribe(
        (data)=>{
         
          this.displayUnit=this.units.filter(
            (unit)=>unit.restaurant.id===this.selectedRestaurant?.id);
          //  this.unit.unitType?.id===this.selectedTypeUnit?.id);
        console.log('return data: ',data);
        this.units.push(data);
        this.hideDialog(false,true);
      },
      (error)=>{
          console.log('error');
          this.hideDialog(false,false);
      }
      );
    }else{
      this.unit.updatedUser.id=this.dataService.loginUserId;
      this.dataService.putUnit(this.unit).subscribe(
        (data)=>{
          console.log('return data: ',data);
          this.loadUnit();
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
    
      this.displayUnit=this.units.filter(st=>st.restaurant?.id===restaurant?.id);
    
    //console.log('on change this.displayRestaurant= ', this.displayUnit);
  
  }
  public onChangeTypeUnit(event:any):void{
    const unitType:UnitType=event;
    console.log('on change= ',unitType);
    
     // this.displayUnit=this.units.filter(st=>st.unitType?.id===typeunit?.id);
    
    //console.log('on change this.displayRestaurant= ', this.displayUnit);
  
  }

}
