import { Injectable, OnDestroy } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { DefaultTable } from 'src/api';

@Injectable({
  providedIn: 'root'
})
export class ActiveTableService implements OnDestroy {
  public activeTable: BehaviorSubject<DefaultTable> = new BehaviorSubject<DefaultTable>({ id: 1 });

  constructor() { }

  ngOnDestroy() {
    this.activeTable.complete();
    this.activeTable.unsubscribe();
  }
}
