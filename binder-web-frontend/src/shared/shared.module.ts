import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActiveTableService } from './services/activeTable.service';
import { PermissionService } from './services/permission.service';

@NgModule({
  imports: [CommonModule],
  declarations: [],
  exports: [],
  providers: [ActiveTableService, PermissionService],
})
export class SharedModule {}
