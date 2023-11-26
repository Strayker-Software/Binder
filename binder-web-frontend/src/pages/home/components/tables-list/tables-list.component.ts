import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subject, takeUntil } from 'rxjs';
import { TablesService, DefaultTable } from 'src/api';
import { ActiveTableService } from 'src/shared/services/activeTable.service';

@Component({
  selector: 'tables-list',
  templateUrl: './tables-list.component.html',
  styleUrls: ['./tables-list.component.scss'],
})
export class TablesListComponent implements OnInit, OnDestroy {
  private subscribe$: Subject<void> = new Subject<void>();
  tables: DefaultTable[] = [];

  constructor(private tableService: TablesService, private activeTableService: ActiveTableService) {}

  ngOnInit() {
    this.tableService
      .apiTablesGet()
      .pipe(takeUntil(this.subscribe$))
      .subscribe({
        next: (tables: DefaultTable[]) => {
          this.tables = tables;
        },
        error: (error: any) => {
          console.error(error);
        },
      });
  }

  tableElementClicked(event: MouseEvent) {
    const htmlElement: HTMLParagraphElement = event.currentTarget as HTMLParagraphElement;

    this.tables.forEach(table => {
      if (table.name === htmlElement.textContent) {
        this.activeTableService.activeTable.next(table);
        
        return;
      }
    });
  }

  ngOnDestroy() {
    this.subscribe$.unsubscribe();
  }
}
