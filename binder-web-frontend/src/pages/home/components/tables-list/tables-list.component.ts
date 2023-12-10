import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subject, takeUntil } from 'rxjs';
import { TablesService, DefaultTable } from 'src/api';
import { ActiveTableService } from 'src/shared/services/activeTable.service';
import { FlatTreeControl } from '@angular/cdk/tree';
import { MatTreeFlatDataSource, MatTreeFlattener } from '@angular/material/tree';
import { TableNode } from 'src/api/model/tableNode';
import { TableFlatNode } from 'src/api/model/tableFlatNode';

@Component({
  selector: 'tables-list',
  templateUrl: './tables-list.component.html',
  styleUrls: ['./tables-list.component.scss'],
})
export class TablesListComponent implements OnInit, OnDestroy {
  private subscribe$: Subject<void> = new Subject<void>();
  tables: DefaultTable[] = [];
  private _transformer = (node: TableNode, level: number) => {
    return {
      expandable: !!node.children && node.children.length > 0,
      id: node.id as number,
      name: node.name as string,
      level: level,
    };
  };
  treeControl = new FlatTreeControl<TableFlatNode>(
    node => node.level,
    node => node.expandable,
  );
  treeFlattener = new MatTreeFlattener(
    this._transformer,
    node => node.level,
    node => node.expandable,
    node => node.children,
  );
  dataSource = new MatTreeFlatDataSource(this.treeControl, this.treeFlattener);

  constructor(private tableService: TablesService, private activeTableService: ActiveTableService) {}

  ngOnInit() {
    this.tableService
      .apiTablesGet()
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

  hasChild = (_: number, node: TableFlatNode) => node.expandable;
  
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