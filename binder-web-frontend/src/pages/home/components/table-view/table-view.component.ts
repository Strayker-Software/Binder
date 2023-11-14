import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subject, takeUntil } from 'rxjs';
import { DefaultTable, ToDoTask, ToDoTasksService } from 'src/api';
import { ActiveTableService } from 'src/shared/services/activeTable.service';

@Component({
  selector: 'table-view',
  templateUrl: './table-view.component.html',
  styleUrls: ['./table-view.component.scss'],
})
export class TableViewComponent implements OnInit, OnDestroy {
  private subscribe$: Subject<void> = new Subject<void>();
  columns: string[] = ['name', 'description', 'isCompleted'];
  tasks: ToDoTask[] = [];
  currentlySelectedTable: DefaultTable = {};

  constructor(private toDoTasksService: ToDoTasksService, private activeTableService: ActiveTableService) {
    this.activeTableService.activeTable.subscribe(selectedTable => {
      this.currentlySelectedTable = selectedTable;
      this.getTasks();
      this.refreshTable();
    });
  }

  ngOnInit() { }

  getTasks() {
    this.toDoTasksService
      .tasksGet(this.currentlySelectedTable.id)
      .pipe(takeUntil(this.subscribe$))
      .subscribe({
        next: (tasks: ToDoTask[] | any) => {
          if (!Array.isArray(tasks)) {          
            tasks as any;            
            throw Error(tasks.title);
          } else {
            this.tasks = tasks;                    
          }
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
