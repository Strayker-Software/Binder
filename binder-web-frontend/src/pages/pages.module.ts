import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { NavbarComponent } from './home/components/navbar/navbar.component';
import { MatDividerModule } from '@angular/material/divider';
import { TablesListComponent } from './home/components/tables-list/tables-list.component';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatTableModule } from '@angular/material/table';
import { TableViewComponent } from './home/components/table-view/table-view.component';
import { DomainButtonsComponent } from './home/components/domain-buttons/domain-buttons.component';

@NgModule({
  imports: [CommonModule, MatDividerModule, MatExpansionModule, MatTableModule],
  declarations: [
    HomeComponent,
    NavbarComponent,
    TablesListComponent,
    TableViewComponent,
    DomainButtonsComponent,
  ],
  exports: [HomeComponent],
})
export class PagesModule {}
