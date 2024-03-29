import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Subject, takeUntil } from 'rxjs';
import { TableDialogComponent } from 'src/pages/home/components/table-dialog/table-dialog.component';
import {
  DefaultTableDTO,
  TablesService,
  ToDoTaskDTO,
  ToDoTasksService,
  TaskShow,
} from 'src/api';
import {
  tableDialogConfig,
  taskDialogConfig,
} from 'src/shared/consts/appConsts';
import { TaskDialogComponent } from 'src/pages/home/components/task-dialog/task-dialog.component';
import { ActiveTableService } from 'src/shared/services/activeTable.service';
import { ShowHideCompletedButtonLabels } from 'src/shared/consts/showHideCompletedButtonLabels.enum';

@Component({
  selector: 'navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss'],
})
export class NavbarComponent {
  private subscribe$: Subject<void> = new Subject<void>();
  tableName: string = '';
  newTask: ToDoTaskDTO = {};
  currentlySelectedTableId: number = 0;
  showHideColumnButtonVisibility: boolean = false;
  showHideCompletedButtonLabel: string = ShowHideCompletedButtonLabels.ShowAll;
  resetViewButtonVisibility: boolean = false;

  constructor(
    private dialog: MatDialog,
    private tablesService: TablesService,
    private tasksService: ToDoTasksService,
    private activeTableService: ActiveTableService
  ) {
    this.activeTableService.activeTable.subscribe((selectedTable) => {
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
            window.location.reload();
          }
        },
        error: (error) => {
          console.error(error);
        },
      });
  }

  addTable(name: string) {
    this.tablesService
      .apiTablesPost(name)
      .pipe(takeUntil(this.subscribe$))
      .subscribe({
        next: (table: DefaultTableDTO) => {
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
            window.location.reload();
          }
        },
        error: (error) => {
          console.error(error);
        },
      });
  }

  addTask(task: ToDoTaskDTO) {
    this.tasksService
      .apiTasksPost(task)
      .pipe(takeUntil(this.subscribe$))
      .subscribe({
        next: (task: ToDoTaskDTO) => {
          return task;
        },
        error: (error) => {
          console.error(error);
        },
      });
  }

  showHideCompleted() {
    switch (
      this.activeTableService.showHideCompletedTasksIndicator.getValue()
    ) {
      case TaskShow.NUMBER_1:
        this.showHideCompletedButtonLabel =
          ShowHideCompletedButtonLabels.HideCompleted;
        this.activeTableService.showHideCompletedTasksIndicator.next(
          TaskShow.NUMBER_2
        );
        break;

      case TaskShow.NUMBER_2:
        this.showHideCompletedButtonLabel =
          ShowHideCompletedButtonLabels.ShowAll;
        this.activeTableService.showHideCompletedTasksIndicator.next(
          TaskShow.NUMBER_3
        );
        break;

      case TaskShow.NUMBER_3:
        this.showHideCompletedButtonLabel =
          ShowHideCompletedButtonLabels.ShowCompleted;
        this.activeTableService.showHideCompletedTasksIndicator.next(
          TaskShow.NUMBER_1
        );
        break;

      default:
        break;
    }
  }

  ngOnDestroy() {
    this.subscribe$.unsubscribe();
  }
}
