import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppHeaderComponent } from '../pages/home/components/app-header/app-header.component';

@NgModule({
  imports: [CommonModule],
  declarations: [AppHeaderComponent],
  exports: [AppHeaderComponent],
})
export class SharedModule {}
