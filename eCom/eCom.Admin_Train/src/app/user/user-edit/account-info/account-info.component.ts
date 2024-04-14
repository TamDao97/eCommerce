import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NzMessageService } from 'ng-zorro-antd/message';
import { NzModalService } from 'ng-zorro-antd/modal';

@Component({
  selector: 'app-account-info',
  templateUrl: './account-info.component.html',
  styleUrls: ['./account-info.component.css'],
})
export class AccountInfoComponent implements OnInit {
  frmGroup!: FormGroup;
  constructor(
    private fb: FormBuilder,
    private msg: NzMessageService,
    private _modal: NzModalService
  ) {}

  ngOnInit() {
    this.initForm();
  }

  initForm(): void {
    this.frmGroup = this.fb.group({
      email: ['', [Validators.email, Validators.required]],
      password: ['', [Validators.required]],
      passwordConfirm: ['', [Validators.required]],
      phone: [''],
      role: [],
    });
  }

  onSave(): void {
    console.log(this.frmGroup.value);
  }

  onExist(): void {
    console.log(this.frmGroup.value);
  }
}
