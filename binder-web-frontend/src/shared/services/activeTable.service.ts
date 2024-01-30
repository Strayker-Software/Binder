import { Injectable, OnDestroy } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { DefaultTableDTO, TaskShow } from 'src/api';

@Injectable({
  providedIn: 'root',
})
export class ActiveTableService implements OnDestroy {
  public activeTable: BehaviorSubject<DefaultTableDTO> =
    new BehaviorSubject<DefaultTableDTO>({ id: 1 });
  public showHideCompletedTasksIndicator: BehaviorSubject<TaskShow> =
    new BehaviorSubject<TaskShow>(TaskShow.NUMBER_3);

  constructor() {}

  ngOnDestroy() {
    this.activeTable.complete();
    this.activeTable.unsubscribe();
    this.showHideCompletedTasksIndicator.complete();
    this.showHideCompletedTasksIndicator.unsubscribe();
  }
}
