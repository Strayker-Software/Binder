import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from 'src/api';

@Component({
  selector: 'callback',
  templateUrl: './callback.component.html',
  styleUrls: ['./callback.component.scss']
})
export class CallbackComponent {
  constructor(private authService: AuthService, private route: ActivatedRoute) {
    this.authService
      .apiAuthCallbackPost(this.route.snapshot.paramMap.get('code')?.toString());
      const date = new Date();
      date.setTime(date.getTime() + (24 * 60 * 60 * 1000));
      document.cookie = "binder_token=" + "token" + "; expires=" + date.toUTCString() + "; path=/; HttpOnly; Secure";

      window.location.replace("/home");
  }
}
