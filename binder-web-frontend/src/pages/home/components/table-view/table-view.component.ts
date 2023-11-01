import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subject, takeUntil } from 'rxjs';
import { ToDoTask, ToDoTasksService } from 'src/api';

@Component({
  selector: 'table-view',
  templateUrl: './table-view.component.html',
  styleUrls: ['./table-view.component.scss'],
})
export class TableViewComponent implements OnInit, OnDestroy {
  private subscribe$: Subject<void> = new Subject<void>();
  columns: string[] = ['name', 'description', 'isCompleted'];
  tasks: ToDoTask[] = [];

  constructor(private toDoTasksService: ToDoTasksService) {}

  ngOnInit() {
    this.toDoTasksService
      .tasksGet(1)
      .pipe(takeUntil(this.subscribe$))
      .subscribe({
        next: (tasks: ToDoTask[]) => {
          this.tasks = tasks;
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
