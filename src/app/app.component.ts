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
            label:'Quyền',
            icon:'pi pi-fw pi-user-edit',
            command:()=> this.router.navigate(['/role'])
    
        },
        {
            label:'Users',
            icon:'pi pi-fw pi-user',
            items:[
                {
                    label:'New',
                    icon:'pi pi-fw pi-user-plus',

                },
                {
                    label:'Delete',
                    icon:'pi pi-fw pi-user-minus',

                },
                {
                    label:'Search',
                    icon:'pi pi-fw pi-users',
                    items:[
                    {
                        label:'Filter',
                        icon:'pi pi-fw pi-filter',
                        items:[
                            {
                                label:'Print',
                                icon:'pi pi-fw pi-print'
                            }
                        ]
                    },
                    {
                        icon:'pi pi-fw pi-bars',
                        label:'List'
                    }
                    ]
                }
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
