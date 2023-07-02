import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router) { }

  private isAllowed(): boolean {
    if(localStorage.getItem('token') && localStorage.getItem('role') == 'admin')
      return true;
    else return false;
  }
  canActivate(): boolean {
    if (this.isAllowed()) {
      return true;
    } else {

     if(confirm('Authenticated users only allowed!!!'))
     {
      this.router.navigate(['/logIN']);
     }
     return false;

    }
  }
}