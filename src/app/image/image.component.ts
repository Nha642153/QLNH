import { HttpEvent, HttpEventType } from '@angular/common/http';
import { LeadingComment, ThrowStmt } from '@angular/compiler';
import { Component, Input, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';

import { ConfirmationService, MessageService } from 'primeng/api';
import { DataService } from '../data.service';
import { Image } from '../model/image';
import { Item } from '../model/item';

@Component({
  selector: 'app-image',
  templateUrl: './image.component.html',
  styleUrls: ['./image.component.scss']
})
export class ImageComponent implements OnInit {

  public uploadedFiles:any[]=[];
  private reader:FileReader|undefined;
  private fileBuffer:any;
  public imagePath:any;
  progressPercent=0;
  loading=true;
  img:any[]=[]; 

 //image:Image=Object.assign({},this.dataService.newImage);


  constructor(
    private domSanitizer:DomSanitizer,
    private route:ActivatedRoute,
    private router:Router,
    private dataService:DataService,
    private messageSevice:MessageService,
    private confirmationService:ConfirmationService
  ) { }

  ngOnInit(): void {
    this.reader=new FileReader();
    this.reader.onload=()=>{
      this.fileBuffer=this.reader?.result;
    };
    this.loadImage();
  }
  private loadImage():void{ 
    this.dataService.getAllImage().subscribe(data=>{
    console.log('Image: ',data);
    this.loading=false;
  //   this.imagePath= data.forEach(image=>{
  //     this.img.push({
  //       name:image?.name||'No Name',
  //       data:'data:image/jpg;base64,'+image.data,
  //   });

  // });
  // this.loading=false;
    
  data.forEach((image)=>{
     this.img.push(
      this.domSanitizer.bypassSecurityTrustResourceUrl(
      'data:image/jpg;base64,'+image.data
     )
   ); 
  }); 
  
  console.log('images ',this.imagePath);
  });
}


  public async  onUpload(event:any){
    console.log('onUpload: ',event);
    for(let file of event.files){
      await this.processFile(file);
    }

  }
  public onSelect(event:any){
    console.log('onSelect ', event);
    this.uploadedFiles.push(event.file);
  }
  public readFileAsync(file:File){
    return new Promise((resolve,rejects)=>{
      let reader=new FileReader();
      reader.onload=()=>{
        resolve(reader.result);
      };
      reader.onerror=rejects;
      reader.readAsArrayBuffer(file);
    })
  }
  public arrayBufferToString(arrayBuffer:any,decoderType='utf-8'){
    let decoder=new TextDecoder(decoderType);
    return decoder.decode(arrayBuffer);
  }
  public arrayBufferToBase64(buffer:ArrayBuffer):string{
    var binary='';
    var bytes=new Uint8Array(buffer);
    var len=bytes.byteLength;
    for(var i=0; i<len;i++){
      binary+= String.fromCharCode(bytes[i]);
    }
    return window.btoa(binary);
  }
  public async processFile(file:File){
    
    try{
      let arrayBuffer=await this.readFileAsync(file);
      console.log('file: ',file);
      const dataBase64=this.arrayBufferToBase64(arrayBuffer as ArrayBuffer);
      let image=this.dataService.newImage;
      image.createdUser.id=this.dataService.loginUserId;
      image.updatedUser.id=this.dataService.loginUserId;
    
      image.name=file.name;
      image.data=dataBase64;

      // this.imagePath=this.domSanitizer.bypassSecurityTrustResourceUrl(
      //   'data:image/jpg;base64,'+dataBase64
      // );
      //let image=this.dataService.newImage;
      //image.data=dataBase64;
      this.dataService.postImage(image).subscribe((event:HttpEvent<any>)=>{
        console.log('postImage=', event);
        switch(event.type){
          case HttpEventType.Sent:
            // console.log('Request has been!');
            break;
          case HttpEventType.ResponseHeader:
              // console.log('Reponse header hass been received!');
              break;
          case HttpEventType.UploadProgress:
            this.progressPercent=Math.round(
              (event.loaded/(event?.total||1))*100
            );
            console.log(`Upload! $(this.progressPercent)%`);
            break;
         
          case HttpEventType.Response:
            // console.log('User success created', event.body);
            setTimeout(()=>{
            this.img.push({
              name:image?.name||'No Name',
              data:'data:image/jpg;base64,'+image.data,
            });
            this.img=[...this.img];
            console.log('this.images= ',this.img,[...this.img]);
            },1500);
          }
      });
    }
    catch(error){

    }
   
    
  }
  
  

}
