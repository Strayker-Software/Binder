import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Subject, takeUntil } from 'rxjs';
import { TableDialogComponent } from 'src/pages/home/components/table-dialog/table-dialog.component';
import { DefaultTable, TablesService, ToDoTask, ToDoTasksService } from 'src/api';
import { tableDialogConfig, taskDialogConfig } from 'src/shared/consts/appConsts';
import { TaskDialogComponent } from 'src/pages/home/components/task-dialog/task-dialog.component';
import { ActiveTableService } from 'src/shared/services/activeTable.service';

@Component({
  selector: 'navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss'],
})
export class NavbarComponent {
  private subscribe$: Subject<void> = new Subject<void>();
  tableName: string = '';
  newTask: ToDoTask = {};
  currentlySelectedTableId: number = 0;
  showHideColumnButtonVisibility: boolean = false;
  resetViewButtonVisibility: boolean = false;

  constructor(private dialog: MatDialog, private tablesService: TablesService, 
    private tasksService: ToDoTasksService, private activeTableService: ActiveTableService) {
      this.activeTableService.activeTable.subscribe(selectedTable => {
        this.currentlySelectedTableId = selectedTable.id as number;
      });
  }

  openTableDialog(): void {
    tableDialogConfig.data.name = this.tableName;
    const dialogRef = this.dialog.open(TableDialogComponent, tableDialogConfig);

    dialogRef
      .afterClosed()
      .pipe(takeUntil(this.subscribe$))
      .subscribe({
        next: (result) => {
          this.tableName = result?.tableName;    
          if (this.tableName !== undefined) {
            this.addTable(this.tableName);
            window.location.reload()
          }
        },
        error: (error) => {
          console.error(error);
        }
      });
  }

  addTable(name: string) {
    this.tablesService
      .apiTablesPost(name)
      .pipe(takeUntil(this.subscribe$))
      .subscribe({
        next: (table: DefaultTable) => {
          return table;
        },
        error: (error) => {
          console.error(error);
        },
      });
  }

  openTaskDialog(): void {
    taskDialogConfig.data.name = this.tableName;
    const dialogRef = this.dialog.open(TaskDialogComponent, taskDialogConfig);

    dialogRef
      .afterClosed()
      .pipe(takeUntil(this.subscribe$))
      .subscribe({
        next: (result) => {
          result.id = this.currentlySelectedTableId;
          this.newTask = result;
          if (this.newTask !== undefined) {
            this.addTask(this.newTask);
            window.location.reload()
          }
        },
        error: (error) => {
          console.error(error);
        }
      });
  }

  addTask(task: ToDoTask) {
    this.tasksService
      .apiTasksPost(task)
      .pipe(takeUntil(this.subscribe$))
      .subscribe({
        next: (task: ToDoTask) => {
          return task;
        },
        error: (error) => {
          console.error(error);
        },
      });
  }

  ngOnDestroy() {
    this.subscribe$.unsubscribe();
  }
}
