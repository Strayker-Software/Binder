import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { NavbarComponent } from './home/components/navbar/navbar.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [HomeComponent, NavbarComponent],
  exports: [HomeComponent]
})
export class PagesModule { }
