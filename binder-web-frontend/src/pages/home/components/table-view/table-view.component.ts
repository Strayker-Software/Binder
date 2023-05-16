import { Component, OnInit } from '@angular/core';
import { ToDoTask } from 'src/shared/models/ToDoTask';

@Component({
  selector: 'table-view',
  templateUrl: './table-view.component.html',
  styleUrls: ['./table-view.component.scss']
})
export class TableViewComponent implements OnInit {
  columns: string[] = ["name", "description", "isCompleted"];
  tasks: ToDoTask[] = [
    { name: "Task 1", description: "Cool Description", isCompleted: false },
    { name: "Task 2", description: "Nice Description", isCompleted: true },
    { name: "Task 3", description: "OK Description", isCompleted: false }
  ];

  constructor() { }

  ngOnInit() {
  }
}
