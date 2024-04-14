import { Component } from '@angular/core';
import { Observable, Observer } from 'rxjs';
import { NzMessageService } from 'ng-zorro-antd/message';
import { NzUploadFile } from 'ng-zorro-antd/upload';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})

export class DashboardComponent {

  // dropdown
  showDropdown: boolean = false;

  toggleDropdown() {
    this.showDropdown = !this.showDropdown;
  }
  // dropdown
  listOfData: Person[] = [
    {
      key: '1',
      name: 'John Brown',
      id: 'Lễ Tân',
      sdt: 1,
      role: 'Lễ Tân',
      trangthai: 'Hoạt Động',
      date: new Date('2023-03-30')
    },

    {
      key: '2',
      name: 'Jim Green',
      id: 'Lễ Tân',
      sdt: 1,
      role: 'Lễ Tân',
      trangthai: 'Hoạt Động',
      date: new Date('2023-03-30')
    },
    {
      key: '3',
      name: 'Joe Black',
      id: 'Lễ Tân',
      sdt: 1,
      role: 'Lễ Tân',
      trangthai: 'Hoạt Động',
      date: new Date('2023-03-30')
    }
  ];


  isVisible = false;

  // modal
  showModal(): void {
    this.isVisible = true;
  }

  handleOk(): void {
    console.log('Button ok clicked!');
    this.isVisible = false;
  }

  handleCancel(): void {
    console.log('Button cancel clicked!');
    this.isVisible = false;
  }
  // modal

  
  // upload
  constructor(private msg: NzMessageService) { }
  loading = false;
  avatarUrl?: string;
  
  beforeUpload = (file: NzUploadFile, _fileList: NzUploadFile[]): Observable<boolean> =>
    new Observable((observer: Observer<boolean>) => {
      const isJpgOrPng = file.type === 'image/jpeg' || file.type === 'image/png';
      if (!isJpgOrPng) {
        this.msg.error('You can only upload JPG file!');
        observer.complete();
        return;
      }
      const isLt2M = file.size! / 1024 / 1024 < 2;
      if (!isLt2M) {
        this.msg.error('Image must smaller than 2MB!');
        observer.complete();
        return;
      }
      observer.next(isJpgOrPng && isLt2M);
      observer.complete();
    });

  private getBase64(img: File, callback: (img: string) => void): void {
    const reader = new FileReader();
    reader.addEventListener('load', () => callback(reader.result!.toString()));
    reader.readAsDataURL(img);
  }

  handleChange(info: { file: NzUploadFile }): void {
    switch (info.file.status) {
      case 'uploading':
        this.loading = true;
        break;
      case 'done':
        // Get this url from response in real world.
        this.getBase64(info.file!.originFileObj!, (img: string) => {
          this.loading = false;
          this.avatarUrl = img;
        });
        break;
      case 'error':
        this.msg.error('Network error');
        this.loading = false;
        break;
    }
  }
  // upload


}

interface Person {
  key: string;
  name: string;
  id: string;
  sdt: number;
  role: string;
  trangthai: string;
  date: Date;
}