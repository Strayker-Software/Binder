import { Injectable, OnDestroy } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { DefaultTableDTO } from 'src/api';

@Injectable({
  providedIn: 'root'
})
export class ActiveTableService implements OnDestroy {
  public activeTable: BehaviorSubject<DefaultTableDTO> = new BehaviorSubject<DefaultTableDTO>({ id: 1 });

  constructor() { }

  ngOnDestroy() {
    this.activeTable.complete();
    this.activeTable.unsubscribe();
  }
}
