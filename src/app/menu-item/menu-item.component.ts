import { Component, Input, OnInit } from '@angular/core';
import { DataService } from '../data.service';
import { Item } from '../model/item';

@Component({
  selector: 'app-menu-item',
  templateUrl: './menu-item.component.html',
  styleUrls: ['./menu-item.component.scss']
})
export class MenuItemComponent implements OnInit {
  items: Item[]=[];
  @Input('item') item:[]=[];
  constructor(private dataService:DataService) { }

  ngOnInit(): void {
    this.loadItem();
  }
  public loadItem():void{
  
    this.dataService.getAllItem().subscribe(data=>{
      this.items=data;

      console.log('Item: ',this.items);
    });
  }
  order(){

    console.log('order ');
  }
}
