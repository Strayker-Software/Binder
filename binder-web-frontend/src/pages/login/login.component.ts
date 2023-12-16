import { Component, OnDestroy } from '@angular/core';
import { Subject, takeUntil } from 'rxjs';
import { AuthService } from 'src/api';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnDestroy {
  private subscribe$: Subject<void> = new Subject<void>();

  constructor(private authService: AuthService) {
    this.authService
      .apiAuthLoginGet()
      .pipe(takeUntil(this.subscribe$))
      .subscribe({
        next: (url: string) => {
          window.location.replace(url);
        },
        error: (error: any) => {
          console.error(error);
        },
      });
  }

  ngOnDestroy() {
    this.subscribe$.unsubscribe();
  }
}
