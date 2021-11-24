import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CatogoryComponent } from './catogory.component';

describe('CatogoryComponent', () => {
  let component: CatogoryComponent;
  let fixture: ComponentFixture<CatogoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CatogoryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CatogoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
