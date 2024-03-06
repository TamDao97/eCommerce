import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'eCom.Admin';
  frmGroup: FormGroup;

  constructor(private fb: FormBuilder) {
    this.frmGroup = this.fb.group({
      name: [null],
      color: [null],
    });
  }

  submit(): void {
    console.log(this.frmGroup.value);
  }
}
