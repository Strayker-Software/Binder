import { Component, EventEmitter, OnDestroy, OnInit, Output } from '@angular/core';
import { Subject, takeUntil } from 'rxjs';
import { TablesService, DefaultTable } from 'src/api';

@Component({
  selector: 'tables-list',
  templateUrl: './tables-list.component.html',
  styleUrls: ['./tables-list.component.scss'],
})
export class TablesListComponent implements OnInit, OnDestroy {
  private subscribe$: Subject<void> = new Subject<void>();
  @Output() toDoListClickedEvent: EventEmitter<HTMLParagraphElement> =
    new EventEmitter();
  @Output() customListClickedEvent: EventEmitter<HTMLParagraphElement> =
    new EventEmitter();
  tables: DefaultTable[] = [];

  constructor(private tableService: TablesService) {}

  ngOnInit() {
    this.tableService
      .tablesGet()
      .pipe(takeUntil(this.subscribe$))
      .subscribe({
        next: (tables: DefaultTable[]) => {
          this.tables = tables;
        },
        error: (error: any) => {
          console.error(error);
        },
      });
  }

  onToDoListClicked() {
    this.toDoListClickedEvent.emit();
  }

  onCustomListClicked() {
    this.customListClickedEvent.emit();
  }

  ngOnDestroy() {
    this.subscribe$.unsubscribe();
  }
}
