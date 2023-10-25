import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subject, take } from 'rxjs';
import { AppVersionsService } from 'src/api';

@Component({
  selector: 'header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent implements OnInit, OnDestroy {
  private subscribe$: Subject<void> = new Subject<void>();
  attributes: string[] = ['major', 'minor', 'patch', 'name'];
  //version?: DisplayableVersion;
  version?: string;

  constructor(private appVersionsService: AppVersionsService) {}

  ngOnInit(): void {
    this.appVersionsService
      .getVersionGet()
      .pipe(take(1))
      .subscribe({
        next: (ver: string) => 

          this.version = ver as string
        ,
        error: (error: any) => {
          console.error(error);
        },
      });
  }

  ngOnDestroy(): void {
    this.subscribe$.unsubscribe();
  }
}
