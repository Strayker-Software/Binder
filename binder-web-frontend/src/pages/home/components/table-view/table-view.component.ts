import { Component, OnInit } from '@angular/core';
import { DefaultTableService, ToDoTask } from 'src/api';

@Component({
  selector: 'table-view',
  templateUrl: './table-view.component.html',
  styleUrls: ['./table-view.component.scss']
})
export class TableViewComponent implements OnInit {
  columns: string[] = ["name", "description", "isCompleted"];
  tasks: ToDoTask[] = [];

  constructor(private defaultTableService: DefaultTableService) { }

  ngOnInit() {
    this.defaultTableService.getToDoTaskGet(1)
      .pipe()
      .subscribe((task: ToDoTask) => {
        this.tasks.push(task);
      });
  }
}
