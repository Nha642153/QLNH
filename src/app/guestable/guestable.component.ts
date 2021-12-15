import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-guestable',
  templateUrl: './guestable.component.html',
  styleUrls: ['./guestable.component.scss']
})
export class GuestableComponent implements OnInit {

  constructor() { }

  @Input('name') name:string='';
  ngOnInit(): void {
  }

}
