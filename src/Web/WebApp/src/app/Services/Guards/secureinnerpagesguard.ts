import { Injectable } from '@angular/core';
import {
    CanActivate,
    ActivatedRouteSnapshot,
    RouterStateSnapshot,
    Router,
} from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../auth.service';

@Injectable({
    providedIn: 'root',
})

/**
 * Designed to dis-allow access to pages that require a user not be authenticated to acccess
 * i.e. the sign-in page
 */
export class SecureInnerPagesGuard implements CanActivate {
    constructor(public authService: AuthService, public router: Router) {}

    canActivate(
        next: ActivatedRouteSnapshot,
        state: RouterStateSnapshot
    ): Observable<boolean> | Promise<boolean> | boolean {
        if (this.authService.isLoggedIn) {
            //window.alert('You are already signed in, access denied!');
            this.router.navigate(['home']);
        }
        return true;
    }
}
