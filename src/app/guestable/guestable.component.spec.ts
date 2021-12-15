import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GuestableComponent } from './guestable.component';

describe('GuestableComponent', () => {
  let component: GuestableComponent;
  let fixture: ComponentFixture<GuestableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GuestableComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GuestableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
