import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PermissionService {

  constructor() { }

  canActivate (currentUser: number, userId: string): boolean {
    return true;
  }
}
