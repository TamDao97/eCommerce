import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-text-area',
  templateUrl: './text-area.component.html',
  styleUrl: './text-area.component.css',
})
export class TextAreaComponent {
  @Input() rowHeight: number = 2;
  @Input() class: string = '';
  @Input() placeholder: string = '';
  @Input() readonly: string = '';
  @Input() disabled: string = '';
  @Output() onChange: EventEmitter<any> = new EventEmitter();
}
