import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'tables-list',
  templateUrl: './tables-list.component.html',
  styleUrls: ['./tables-list.component.scss'],
})
export class TablesListComponent implements OnInit {
  @Output() toDoListClickedEvent: EventEmitter<HTMLParagraphElement> =
    new EventEmitter();
  @Output() customListClickedEvent: EventEmitter<HTMLParagraphElement> =
    new EventEmitter();

  constructor() {}

  ngOnInit() {}

  onToDoListClicked() {
    this.toDoListClickedEvent.emit();
  }

  onCustomListClicked() {
    this.customListClickedEvent.emit();
  }  
}
