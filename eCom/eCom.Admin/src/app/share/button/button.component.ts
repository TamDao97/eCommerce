import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-button',
  templateUrl: './button.component.html',
  styleUrl: './button.component.css',
})
export class ButtonComponent {
  item: any = null;
  @Input() text: string = '';
  @Input() class: string = 'btn btn-primary';
  @Output() onClick: EventEmitter<any> = new EventEmitter();
}
