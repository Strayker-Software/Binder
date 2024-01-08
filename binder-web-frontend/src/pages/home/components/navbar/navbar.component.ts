import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Subject, takeUntil } from 'rxjs';
import { TableDialogComponent } from '../table-dialog/table-dialog.component';
import { DefaultTable, TablesService } from 'src/api';

@Component({
  selector: 'navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss'],
})
export class NavbarComponent {
  private subscribe$: Subject<void> = new Subject<void>();
  tableName: string = '';

  constructor(private dialog: MatDialog, private tableService: TablesService) { }

  openDialog(): void {
    let dialogRef = this.dialog.open(TableDialogComponent, {
      width: '18rem',
      height: '16rem',
      data: { name: this.tableName },
      position: { top: '0px', left:'0px' }
    });

    dialogRef.afterClosed().subscribe((result) => {
      this.tableName = result?.tableName;
    
      if (this.tableName !== undefined)
      {
        this.addTable(this.tableName);
        window.location.reload()
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
