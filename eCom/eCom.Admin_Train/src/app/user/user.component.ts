import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { NzMessageService } from 'ng-zorro-antd/message';
import { NzModalService } from 'ng-zorro-antd/modal';
import { UserEditComponent } from './user-edit/user-edit.component';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrl: './user.component.css',
})
export class UserComponent {
  showDropdown: boolean = false;
  listOfData: any[] = [];

  constructor(
    private fb: FormBuilder,
    private msg: NzMessageService,
    private _modalService: NzModalService
  ) {}

  toggleDropdown() {
    this.showDropdown = !this.showDropdown;
  }

  showModal(id = null) {
    let modal = this._modalService.create({
      nzTitle: 'Thêm mới tài khoản',
      nzContent: UserEditComponent,
      nzNoAnimation: true,
      nzMask: false,
      nzClosable: true,
      nzFooter: null,
      nzStyle: { top: '20px' },
      nzWidth: 1000,
      nzData: {
        id: id,
      },
    });
    modal.afterClose.subscribe((res) => {
      console.log(9999);
      // if (res) {
      //   this.gridLoadData();
      // }
    });
  }
}
