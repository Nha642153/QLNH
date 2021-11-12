import { Component, OnInit } from '@angular/core';
import { DataService } from '../data.service';

import { ConfirmationService } from 'primeng/api';
import { MessageService } from 'primeng/api';
import { Role } from '../model/role';

@Component({
  selector: 'app-role',
  templateUrl:'./role.component.html',
  styleUrls: ['./role.component.scss'],
  styles: [`
  :host ::ng-deep .p-dialog .product-image {
      width: 150px;
      margin: 0 auto 2rem auto;
      display: block;
  }`],
})
export class RoleComponent implements OnInit {

  constructor(private dataService:DataService, private messageService: MessageService, private confirmationService: ConfirmationService) { }
  roles:Role[]=[];
  RoleDialog=false;
  role:Role=Object.assign({},this.dataService.newRole);
  submited=true;
  loading=true;

  ngOnInit(): void {
    this.loadRole();
  }
  public loadRole():void{
    this.loading=true;
    this.dataService.getRole().subscribe(data=>{
      this.roles=data;
      this.loading=false;
      console.log("roles", data);
    });
  }
  openNew():void {
   
   console.log('openNew: ');
   this.role=Object.assign({},this.dataService.newRole);   
   this.RoleDialog = true;
  }
  public editRole(roles:Role):void{
    console.log('edit Status: ', roles);
    this.role=roles;
    this.RoleDialog=true;
  }
  public deleteRole(Role:Role):void{
    console.log('delete Role: ',Role);
    this.confirmationService.confirm({
      message: 'Are you sure you want to Role' + Role.name + '?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
          Role.deleted=true;
          this.dataService.putRole(Role).subscribe(data=>{
            console.log('da cap nhat: ',data);
            this.loadRole();
            this.messageService.add({severity:'warn', summary: 'Successful', detail: 'Deleted', life: 3000});
          });
          
      }
    });
  }
  hideDialog(cancel=true,success=true):void {
    this.RoleDialog = false;

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
    console.log('saveRole: ',this.role);
    if(this.role.id===0){
        this.dataService.postRole(this.role).subscribe(
        (data)=>{
        console.log('return data: ',data);
        this.roles.push(data);
        this.hideDialog(false,true);
      },
      (error)=>{
          console.log('error');
          this.hideDialog(false,false);
      }
      );
    }else{

      this.dataService.putRole(this.role).subscribe(
        (data)=>{
          console.log('return data: ',data);
          this.loadRole();
           this.hideDialog(false,true);
        },(error)=>{
          console.log('error');
          this.hideDialog(false,false);
        }
      );
      
    }    
  }

}
