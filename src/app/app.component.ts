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
            label:'🏘Nhà hàng',
            command:()=> this.router.navigate(['/restaurant'])       
        },
        {
            label:'👮🏻‍♂️Users',
            items:[
                {
                    label:'👨🏻‍💼Chức vụ', 
                    command:()=> this.router.navigate(['/user'])
                },
                {
                    label:'👨🏻‍⚖️Quyền',           
                    command:()=> this.router.navigate(['/role'])
                },
                
            ]
        },
        {
            label:'🚦Trình trạng',
           command:()=>this.router.navigate(['/status'])
        },
        {
            label:'🍽Đơn vị',
           
            command:()=>this.router.navigate(['/unit'])
        },
        {
            label:'🍖Món ăn',
            command:()=>this.router.navigate(['/catogory'])
        },
        {
            label:'🖥🥩Đặt món',
            command:()=>this.router.navigate(['/order'])
        },
        {
            label:'🔐/🔑Login/Logout',
            command:()=>this.router.navigate(['/login'])
        }
    ];
}
}
