import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subject, takeUntil } from 'rxjs';
import { AppVersionsService } from 'src/api';

@Component({
  selector: 'header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent implements OnInit, OnDestroy {
  private subscribe$: Subject<void> = new Subject<void>();
  version: string = '';

  constructor(private appVersionsService: AppVersionsService) {}

  ngOnInit(): void {
    this.appVersionsService
      .apiVersionsGet()
      .pipe(takeUntil(this.subscribe$))
      .subscribe({
        next: (ver: string) => (this.version = ver),
        error: (error: any) => {
          console.error(error);
        },
      });
  }

  ngOnDestroy(): void {
    this.subscribe$.unsubscribe();
  }
}
