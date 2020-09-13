import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { AuthService } from 'src/app/Services/auth.service';
import { isNullOrUndefined } from 'util';
import { User } from 'src/app/Models/user';
import { DataStateService } from 'src/app/Services/datastate.service';

@Component({
    selector: 'app-navmenu',
    templateUrl: './navmenu.component.html',
    styleUrls: ['./navmenu.component.scss'],
})
export class NavmenuComponent {
    pageTitle: string = "Unknown";
    isAuthenticated: boolean = false;
    isHandset$: Observable<boolean> = this.breakpointObserver
        .observe(Breakpoints.Handset)
        .pipe(
            map((result) => result.matches),
            shareReplay()
        );

    constructor(
        private breakpointObserver: BreakpointObserver,
        public auth: AuthService,
        private dataState: DataStateService
    ) {
        this.auth.signedIn.subscribe((user: User) => {
            if (user === null) {
                this.isAuthenticated = false;
            } else {
                this.isAuthenticated = true;
            }
        });

        //Update the current title
        this.dataState.getPageTitle().subscribe((res) => {
            this.pageTitle = res;
        });
    }
}
