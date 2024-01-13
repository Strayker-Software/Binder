import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Subject, takeUntil } from 'rxjs';
import { TableDialogComponent } from 'src/pages/home/components/table-dialog/table-dialog.component';
import { DefaultTable, TablesService } from 'src/api';
import { dialogConfig } from 'src/shared/consts/appConsts';

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

  constructor(private dialog: MatDialog, private tableService: TablesService) { }

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

  ngOnDestroy() {
    this.subscribe$.unsubscribe();
  }
}
