import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subject, takeUntil } from 'rxjs';
import { DefaultTableService, ToDoTask } from 'src/api';
import { DisplayableTask } from '../../../../shared/models/DisplayableTask';

@Component({
  selector: 'table-view',
  templateUrl: './table-view.component.html',
  styleUrls: ['./table-view.component.scss'],
})
export class TableViewComponent implements OnInit, OnDestroy {
  private subscribe$: Subject<void> = new Subject<void>();
  columns: string[] = ['name', 'description', 'isCompleted'];
  tasks: DisplayableTask[] = [];

  constructor(private defaultTableService: DefaultTableService) {}

  ngOnInit() {
    this.defaultTableService
      .getToDoTaskGet(1)
      .pipe(takeUntil(this.subscribe$))
      .subscribe({
        next: (task: ToDoTask) => {
          const displayableTask: DisplayableTask = {
            name: task.name,
            description: task.description,
            isCompleted: task.isCompleted,
          } as DisplayableTask;

          this.tasks.push(displayableTask);
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
