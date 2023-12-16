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
    
      window.location.replace("/home");
  }
}
