import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subject, takeUntil } from 'rxjs';
import { TablesService, DefaultTable } from 'src/api';
import { ActiveTableService } from 'src/shared/services/activeTable.service';
import { NestedTreeControl } from '@angular/cdk/tree';
import { MatTreeNestedDataSource } from '@angular/material/tree';
import { TableNode } from 'src/api/model/tableNode';

@Component({
  selector: 'tables-list',
  templateUrl: './tables-list.component.html',
  styleUrls: ['./tables-list.component.scss'],
})
export class TablesListComponent implements OnInit, OnDestroy {
  private subscribe$: Subject<void> = new Subject<void>();
  tables: DefaultTable[] = [];
  dataSource = new MatTreeNestedDataSource<TableNode>();
  treeControl = new NestedTreeControl<TableNode>((node) => node.children);

  constructor(private tableService: TablesService, private activeTableService: ActiveTableService) {}

  ngOnInit() {
    this.tableService
      .tablesGet()
      .pipe(takeUntil(this.subscribe$))
      .subscribe({
        next: (tables: DefaultTable[]) => {
          this.tables = tables;
          this.dataSource.data = [
            {
              children: tables as TableNode[]
            }
          ];
        },
        error: (error) => {
          console.error(error);
        },
      });
  }

  hasChild(index: number, node: TableNode) {
    return !!node.children &&  node.children.length > 0;
  }

  tableElementClicked(id: number) {
    this.tables.forEach((table) => {
      if (table.id === id) {
        this.activeTableService.activeTable.next(table);

        return;
      }
    });
  }

  ngOnDestroy() {
    this.subscribe$.unsubscribe();
  }
}