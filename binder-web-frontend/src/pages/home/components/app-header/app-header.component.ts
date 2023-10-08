import { Component } from '@angular/core';
import  packageInfo  from 'package.json';

@Component({
  selector: 'app-header',
  templateUrl: './app-header.component.html',
  styleUrls: ['./app-header.component.scss']
})
export class AppHeaderComponent {
 
   version: any = packageInfo.version;
}
