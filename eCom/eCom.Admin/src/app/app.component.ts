import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

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
      name: [null, [Validators.required]],
    });
  }

  submit(): void {
    if (this.frmGroup.invalid) {
      return;
    }
    this.frmGroup.get('name')?.setValue('add new');
  }
}
