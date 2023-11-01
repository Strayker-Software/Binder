import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subject, takeUntil } from 'rxjs';
import { DefaultTable, DefaultTableService, ToDoTask } from 'src/api';

@Component({
  selector: 'table-view',
  templateUrl: './table-view.component.html',
  styleUrls: ['./table-view.component.scss'],
})
export class TableViewComponent implements OnInit, OnDestroy {
  private subscribe$: Subject<void> = new Subject<void>();
  columns: string[] = ['name', 'description', 'isCompleted'];
  tasks: ToDoTask[] = [];

  constructor(private defaultTableService: DefaultTableService) {}

  ngOnInit() {
    this.defaultTableService
      .tableGet(1)
      .pipe(takeUntil(this.subscribe$))
      .subscribe({
        next: (table: DefaultTable) => {
          if(table.tasks === null || table.tasks === undefined) {
            console.error("Error");

            return;
          }

          this.tasks = table.tasks as ToDoTask[];
          this.refreshTable();
        },
        error: (error: any) => {
          console.error(error);
        },
      });
  }

  refreshTable() {
    this.tasks = [...this.tasks];
  }

  ngOnDestroy() {
    this.subscribe$.unsubscribe();
  }
}
