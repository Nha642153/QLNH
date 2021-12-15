import { Component, OnInit } from '@angular/core';
import { ConfirmationService } from 'primeng/api';
import { MessageService } from 'primeng/api';
import { DataService } from '../data.service';
import { User} from '../model/user';
import * as FileSaver from 'file-saver'

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss'],
  styles: [`
  :host ::ng-deep .p-dialog .product-image {
      width: 150px;
      margin: 0 auto 2rem auto;
      display: block;
  }`],
})
export class UserComponent implements OnInit {
  users: User[]=[];
  
  UserDialog=false;
  user:User=Object.assign({},this.dataService.newUser);
  submited=true;
  loading=true;
 

  constructor(private dataService:DataService, private messageService: MessageService, private confirmationService: ConfirmationService) { }
  ngOnInit(): void {
    this.loadUser();
  }
  public loadUser():void{
    this.loading=true;
    this.dataService.getAllUser().subscribe(data=>{
      this.users=data;
      this.loading=false;
      console.log('Users: ',data);
    });
  }
  openNew():void {
   console.log('openNew: ');
   this.user=Object.assign({},this.dataService.newUser);
   this.UserDialog = true;
    }


  public editUser(users: User):void{
    console.log('edit User: ', users);
    this.user=users;
    this.UserDialog=true;
  }
  public deleteUser(User:User):void{
    console.log('delete User: ',User);
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete ' + User.userName + '?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
          User.deleted=true;
          this.dataService.putUser(User).subscribe(data=>{
            console.log('da cap nhat: ',data);
            this.loadUser();
            this.messageService.add({severity:'warn', summary: 'Successful', detail: 'Deleted', life: 3000});
          });
          
      }
    });
  }
  hideDialog(cancel=true,success=true):void {
    this.UserDialog = false;

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
  saveUser():void {
    console.log('saveUser: ',this.users);
    if(this.user.id===0){
     // this.user.createdUser.createdUserId=this.dataService.loginUserId;
     //  this.user.updatedUser.updatedUserId=this.dataService.loginUserId;
      this.dataService.postUser(this.user).subscribe(
        (data)=>{
        console.log('return data: ',data);
        this.users.push(data);
        this.hideDialog(false,true);
      },
      (error)=>{
          console.log('error');
          this.hideDialog(false,false);
      }
      );
    }else{
     // this.user.updatedUser.updatedUserId=this.dataService.loginUserId;
      this.dataService.putUser(this.user).subscribe(
        (data)=>{
          console.log('return data: ',data);
          this.loadUser();
           this.hideDialog(false,true);
        },(error)=>{
          console.log('error');
          this.hideDialog(false,false);
        }
      );
    }
  }
  exportExcel() {
    import("xlsx").then(xlsx => {
      const worksheet = xlsx.utils.json_to_sheet(this.users);
      const workbook = { Sheets: { data: worksheet }, SheetNames: ["data"] };
      const excelBuffer: any = xlsx.write(workbook, {
        bookType: "xlsx",
        type: "array"
      });
      this.saveAsExcelFile(excelBuffer, "Nhan vien");
    });
  }

  saveAsExcelFile(buffer: any, fileName: string): void {

      let EXCEL_TYPE =
        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8";
      let EXCEL_EXTENSION = ".xlsx";
      const data: Blob = new Blob([buffer], {
        type: EXCEL_TYPE
      });
      FileSaver.saveAs(
        data,
        "Export_"+ fileName  + new Date().getDate()+"_"+ new Date().getMonth()+"_"+ new Date().getFullYear() + EXCEL_EXTENSION
      );
    
  }
}
  
     
  

