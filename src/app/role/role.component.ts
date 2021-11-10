import { Component, OnInit } from '@angular/core';
import { DataService } from '../data.service';
import { Role } from '../model/role';

@Component({
  selector: 'app-role',
  templateUrl: './role.component.html',
  styleUrls: ['./role.component.scss']
})
export class RoleComponent implements OnInit {

  constructor(private dataService:DataService) { }
  roles:Role[]=[];
  ngOnInit(): void {
    this.dataService.getRole().subscribe(data=>{
      this.roles=data;
      console.log("role", data);
    })
  }

}
