import { Injectable, isDevMode } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router, NavigationStart } from '@angular/router';
import { Subject, Observable, throwError } from 'rxjs';
import { Utilities } from 'src/app/Core/shared/utilities';
import { Notification } from 'src/app/Models/notification';
// import { Utilities } from 'src/app/core/shared/Utilities';
import { NotificationType } from 'src/app/Models/Notifitications/notificationtype';

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

    // enable subscribing to notifications observable to support change events such as clearing records and added new ones!
    onNotification(): Observable<Notification[]> {
        return this.subject.asObservable().pipe();
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // convenience methods for sending messages to the notification layer

    /**
     * Handle notification for successful events, such as Update and Insert events
     * @param message[string] : the message to be output to the notification record to the user
     * @param showSnackBar[boolean] : controls if an on screen message is to be displayed (defaulted to false)
     * @param notificationId[string] : defaulted to a uniquely generated UUID
     */
    success(
        message: string,
        showSnackBar: boolean = false,
        notificationId: string = Utilities.generateUUID()
    ) {
        this.notify(
            new Notification({
                message: message,
                //type: NotificationType.Success,
                notificationId,
                //typeName: NotificationType[NotificationType.Success],
            })
        );
        if (showSnackBar) {
            this.snackBar.open(message, 'Success', {
                panelClass: 'success-dialog',
            });
        }
    }

    /**
     * Handle notification for errors events, such as Authorisation API errors
     * @param message[string] : the message to be output to the notification record to the user
     * @param showSnackBar[boolean] : controls if an on screen message is to be displayed (defaulted to false)
     * @param notificationId[string] : defaulted to a uniquely generated UUID
     */
    error(
        message: string,
        showSnackBar: boolean = true,
        notificationId: string = Utilities.generateUUID()
    ) {
        this.notify(
            new Notification({
                message: message,
                type: NotificationType.Error,
                notificationId,
                typeName: NotificationType[NotificationType.Error],
            })
        );
        if (showSnackBar) {
            //enforce current snack bar dismissal for errors!
            this.snackBar.dismiss();
            this.snackBar.open(message, 'Error', {
                duration: 5000,
                panelClass: 'error-dialog',
            });
        }
    }

    /**
     * Handle notifications for informational events
     * @param message[string] : the message to be output to the notification record to the user
     * @param showSnackBar[boolean] : controls if an on screen message is to be displayed (defaulted to false)
     * @param notificationId[string] : defaulted to a uniquely generated UUID
     */
    info(
        message: string,
        showSnackBar: boolean = false,
        notificationId: string = Utilities.generateUUID()
    ) {
        this.notify(
            new Notification({
                message: message,
                type: NotificationType.Info,
                notificationId,
                typeName: NotificationType[NotificationType.Info],
            })
        );
        if (showSnackBar) {
            this.snackBar.open(message, 'Info', {
                panelClass: 'success-dialog',
            });
        }
    }

    /**
     * Handle notification for events that have perhaps not completed or have timed out!
     * @param message[string] : the message to be output to the notification record to the user
     * @param showSnackBar[boolean] : controls if an on screen message is to be displayed (defaulted to false)
     * @param notificationId[string] : defaulted to a uniquely generated UUID
     */
    warn(
        message: string,
        showSnackBar: boolean = false,
        notificationId: string = Utilities.generateUUID()
    ) {
        this.notify(
            new Notification({
                message: message,
                type: NotificationType.Warning,
                notificationId,
                typeName: NotificationType[NotificationType.Warning],
            })
        );
        if (showSnackBar) {
            this.snackBar.open(message, 'Warning', {
                panelClass: 'success-dialog',
            });
        }
    }

    /**
     * main alert method to log an alert/notification
     * @param notification[Notification] : string with notification content
     */
    notify(notification: Notification) {
        //update the date of the event to here!
        notification.eventTime = new Date();

        this.notifications.push(notification);
        this.subject.next(this.notifications);
    }
}
