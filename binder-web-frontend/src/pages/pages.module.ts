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
import { HeaderComponent } from './home/components/header/header.component';
import { SidePanelComponent } from './home/components/side-panel/side-panel.component';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { TranslocoModule } from '@ngneat/transloco';
import { MainSpaceComponent } from './home/components/main-space/main-space.component';
import { MatTreeModule } from '@angular/material/tree';
import { MatIconModule } from '@angular/material/icon';

@NgModule({
  imports: [
    CommonModule, 
    MatCheckboxModule, 
    MatDividerModule, 
    MatExpansionModule, 
    MatTableModule, 
    TranslocoModule, 
    MatTreeModule, 
    MatIconModule
  ],
  declarations: [
    HomeComponent,
    NavbarComponent,
    TablesListComponent,
    TableViewComponent,
    DomainButtonsComponent,
    HeaderComponent,
    SidePanelComponent,
    MainSpaceComponent
  ],
  exports: [HomeComponent],
})
export class PagesModule {}
