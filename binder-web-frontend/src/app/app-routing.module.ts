import { NgModule, inject } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivateFn, RouterModule, RouterStateSnapshot, Routes } from '@angular/router';
import { HomeComponent } from 'src/pages/home/home.component';
import { LoginComponent } from 'src/pages/login/login.component';
import { UnauthorizedComponent } from 'src/pages/unauthorized/unauthorized.component';
import { PermissionService } from 'src/shared/services/permission.service';

const canActivateTeam: CanActivateFn =
  (route: ActivatedRouteSnapshot, state: RouterStateSnapshot) => {
    return inject(PermissionService).canActivate(0, route.params['id']);
};

const routes: Routes = [
  { path: "", component: LoginComponent },
  { path: "unauthorized", component: UnauthorizedComponent },
  { path: "home", component: HomeComponent, canActivate: [canActivateTeam] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
