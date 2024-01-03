import { Component } from '@angular/core';

@Component({
  selector: 'navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss'],
})
export class NavbarComponent {
  showHideColumnButtonVisibility: boolean = false;
  resetViewButtonVisibility: boolean = false;
  
  constructor() {}
}
