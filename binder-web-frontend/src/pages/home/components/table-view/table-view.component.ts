import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subject, takeUntil } from 'rxjs';
import { ToDoTasksService } from 'src/api/api/toDoTasks.service';
import { DefaultTableDTO, ToDoTaskDTO } from 'src/api/model/models';
import { ActiveTableService } from 'src/shared/services/activeTable.service';

@Component({
  selector: 'table-view',
  templateUrl: './table-view.component.html',
  styleUrls: ['./table-view.component.scss'],
})
export class TableViewComponent implements OnInit, OnDestroy {
  private subscribe$: Subject<void> = new Subject<void>();
  columns: string[] = ['name', 'description', 'isCompleted'];
  tasks: ToDoTaskDTO[] = [];
  currentlySelectedTable: DefaultTableDTO = {};

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
      .apiTasksGet(this.currentlySelectedTable.id)
      .pipe(takeUntil(this.subscribe$))
      .subscribe({
        next: (tasks: ToDoTaskDTO[]) => {
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
