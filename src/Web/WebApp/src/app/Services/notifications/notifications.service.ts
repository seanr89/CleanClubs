import { Injectable, isDevMode } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router, NavigationStart } from '@angular/router';
import { Subject, Observable, throwError } from 'rxjs';
// import { Utilities } from 'src/app/core/shared/Utilities';
// import { NotificationType } from 'src/app/models/enums/notificationtype';

//following sample: https://jasonwatmore.com/post/2019/07/05/angular-8-alert-toaster-notifications
@Injectable({
    providedIn: 'root',
})
/**
 * service to support the handling of events/nofication storage and type identification with the handling of toasts events
 * on the UI to the user!
 */
export class NotificationsService {
    private subject = new Subject<Notification[]>();
    private keepAfterRouteChange = true;
    private notifications: Notification[];

    /**
     * constructor with routing subscription for navigation events and and snackbar inclusion
     * @param snackBar: planned inclusion for display snack bar controls if needed
     * @param router: app router to support subscription to route changes
     */
    constructor(private snackBar: MatSnackBar, private router: Router) {
        this.notifications = [];
        //TODO: clear alert messages on route change unless 'keepAfterRouteChange' flag is true
        this.router.events.subscribe((event) => {
            if (event instanceof NavigationStart) {
                if (this.keepAfterRouteChange) {
                    // only keep for a single route change
                    this.keepAfterRouteChange = false;
                } else {
                    // clear all notifications
                    //this.clearAll();
                    this.keepAfterRouteChange = true;
                }
            }
        });
    }
}
