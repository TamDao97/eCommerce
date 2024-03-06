import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ButtonComponent } from './button/button.component';
import { InputComponent } from './input/input.component';
import { SelectComponent } from './select/select.component';
import { GridComponent } from './grid/grid.component';
import { TextAreaComponent } from './text-area/text-area.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    ButtonComponent,
    InputComponent,
    SelectComponent,
    GridComponent,
    TextAreaComponent,
  ],
  imports: [CommonModule, ReactiveFormsModule, FormsModule],
  exports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    ButtonComponent,
    InputComponent,
    SelectComponent,
    GridComponent,
    TextAreaComponent,
  ],
})
export class ShareModule {}
