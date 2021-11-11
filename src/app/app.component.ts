import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  constructor(private route:ActivatedRoute,private router:Router){}
  title = 'QuanlyNhaHangNgoiHouse';
  items: MenuItem[]=[];
  

  ngOnInit() {
    this.items = [
        {
            label:'Nhà hàng',
            icon:'pi pi-fw pi-home',
            command:()=> this.router.navigate(['/restaurant'])       
        },
        {
            label:'Users',
            icon:'pi pi-fw pi-user',
            items:[
                {
                    label:'Chức vụ',
                    icon:'pi pi-fw pi-user-plus',
                    command:()=> this.router.navigate(['/user'])
                },
                {
                    label:'Quyền',
                    icon:'pi pi-fw pi-user-edit',
                    command:()=> this.router.navigate(['/role'])
                },
                
            ]
        },
        {
            label:'Trình trạng',
            icon:'pi pi-fw pi-flag',
           command:()=>this.router.navigate(['/status'])
        },
        {
            label:'Đơn vị',
            icon:'pi pi-fw pi-fi'
        }
    ];
}
}
