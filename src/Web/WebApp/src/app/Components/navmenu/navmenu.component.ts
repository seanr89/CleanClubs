import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { AuthService } from 'src/app/Services/auth.service';
import { isNullOrUndefined } from 'util';

@Component({
    selector: 'app-navmenu',
    templateUrl: './navmenu.component.html',
    styleUrls: ['./navmenu.component.scss'],
})
export class NavmenuComponent {
    isAuthenticated: boolean = false;
    isHandset$: Observable<boolean> = this.breakpointObserver
        .observe(Breakpoints.Handset)
        .pipe(
            map((result) => result.matches),
            shareReplay()
        );

    constructor(
        private breakpointObserver: BreakpointObserver,
        public auth: AuthService
    ) {
        this.auth.signedIn.subscribe((user) => {
            if (isNullOrUndefined(user)) this.isAuthenticated = false;
            else this.isAuthenticated = true;
        });
    }
}
