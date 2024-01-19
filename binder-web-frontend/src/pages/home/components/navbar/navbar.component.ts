import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Subject, takeUntil } from 'rxjs';
import { TableDialogComponent } from 'src/pages/home/components/table-dialog/table-dialog.component';
import { DefaultTable, TablesService, TaskShow } from 'src/api';
import { dialogConfig } from 'src/shared/consts/appConsts';
import { ActiveTableService } from 'src/shared/services/activeTable.service';

@Component({
  selector: 'navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss'],
})
export class NavbarComponent {
  private subscribe$: Subject<void> = new Subject<void>();
  tableName: string = '';
  showHideColumnButtonVisibility: boolean = false;
  resetViewButtonVisibility: boolean = false;

  constructor(private dialog: MatDialog, private tableService: TablesService, private activeTableService: ActiveTableService) { }

  openDialog(): void {
    dialogConfig.data.name = this.tableName;
    const dialogRef = this.dialog.open(TableDialogComponent, dialogConfig);

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
    this.tableService
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

  showHideCompleted() {
    switch (this.activeTableService.showHideCompletedTasksIndicator.getValue()) {
      case TaskShow.NUMBER_1:
        this.activeTableService.showHideCompletedTasksIndicator.next(TaskShow.NUMBER_2);
        break;

      case TaskShow.NUMBER_2:
        this.activeTableService.showHideCompletedTasksIndicator.next(TaskShow.NUMBER_3);
        break;

      case TaskShow.NUMBER_3:
        this.activeTableService.showHideCompletedTasksIndicator.next(TaskShow.NUMBER_1);
        break;
    
      default:
        break;
    }
  }

  ngOnDestroy() {
    this.subscribe$.unsubscribe();
  }
}
