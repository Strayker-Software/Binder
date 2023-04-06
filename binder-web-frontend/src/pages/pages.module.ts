import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { NavbarComponent } from './home/components/navbar/navbar.component';
import { MatDividerModule } from '@angular/material/divider';
import { TablesListComponent } from './home/components/tables-list/tables-list.component';
import { MatExpansionModule } from '@angular/material/expansion';

@NgModule({
  imports: [CommonModule, MatDividerModule, MatExpansionModule],
  declarations: [HomeComponent, NavbarComponent, TablesListComponent],
  exports: [HomeComponent],
})
export class PagesModule {}
