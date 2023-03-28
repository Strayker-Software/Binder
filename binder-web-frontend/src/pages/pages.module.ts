import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { NavbarComponent } from './home/components/navbar/navbar.component';
import { MatDividerModule } from '@angular/material/divider';


@NgModule({
  imports: [
    CommonModule,
    MatDividerModule
  ],
  declarations: [
    HomeComponent,
    NavbarComponent
  ],
  exports: [HomeComponent]
})
export class PagesModule { }
