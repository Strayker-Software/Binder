import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { TablesListComponent } from './home/components/tables-list/tables-list.component';
import { MatExpansionModule } from '@angular/material/expansion';

@NgModule({
  imports: [
    CommonModule,
    MatExpansionModule
  ],
  declarations: [HomeComponent,TablesListComponent],
  exports: [HomeComponent]
})
export class PagesModule { }
