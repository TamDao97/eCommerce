import { Component, Input, forwardRef } from '@angular/core';
import {
  ControlValueAccessor,
  FormBuilder,
  FormGroup,
  NG_VALUE_ACCESSOR,
} from '@angular/forms';

@Component({
  selector: 'app-input',
  templateUrl: './input.component.html',
  styleUrl: './input.component.css',
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => InputComponent),
      multi: true,
    },
  ],
})
export class InputComponent implements ControlValueAccessor {
  @Input() class: string = 'form-control';
  @Input() placeholder: string = '';
  @Input() readonly: string = '';
  @Input() disabled: string = '';

  frmGroup!: FormGroup;
  onChange: (value: string) => void;
  onTouched: () => void;

  constructor(private fb: FormBuilder) {
    this.frmGroup = this.fb.group({});
  }

  writeValue(obj: any): void {
    console.log(obj);
  }
  registerOnChange(fn: any): void {
    this.onChange = fn;
  }
  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }
  setDisabledState?(isDisabled: boolean): void {
    console.log(isDisabled);
  }
}
