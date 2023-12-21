import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PermissionService {

  constructor() { }

  canActivate (token: string): boolean {
    return token !== null || token !== "" ? true : false;
  }
}
