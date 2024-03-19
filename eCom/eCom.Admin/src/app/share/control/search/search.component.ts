import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css'],
})
export class SearchComponent implements OnInit {
  @Input() placeholder = 'Từ khóa tìm kiếm';
  @Output() onChange: EventEmitter<any> = new EventEmitter<any>();

  keyWord: string = '';
  constructor() {}

  ngOnInit() {}
}
