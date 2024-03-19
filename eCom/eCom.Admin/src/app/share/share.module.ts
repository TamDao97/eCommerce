import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NzInputModule } from 'ng-zorro-antd/input';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NzGridModule } from 'ng-zorro-antd/grid';
import { SearchComponent } from './control/search/search.component';
import { NzIconModule } from 'ng-zorro-antd/icon';

@NgModule({
  declarations: [SearchComponent],
  imports: [FormsModule, NzIconModule, NzInputModule],
  exports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    NzIconModule,
    NzInputModule,
    NzGridModule,
    SearchComponent,
  ],
})
export class ShareModule {}
