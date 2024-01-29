import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'table-dialog',
  templateUrl: './table-dialog.component.html',
  styleUrls: ['./table-dialog.component.scss'],
})
export class TableDialogComponent {
  constructor(
    private dialogRef: MatDialogRef<TableDialogComponent>,
    @Inject(MAT_DIALOG_DATA) protected data: any
  ) {}

  onCancel(): void {
    this.dialogRef.close();
  }
}
