import { NotificationType } from './interfaces/notifications/notificationtype';


export class Notification {
    type: NotificationType;
    typeName: string;
    message: string;
    notificationId: string;
    hasBeenRead: boolean = false;
    eventTime: Date;

    constructor(init?: Partial<Notification>) {
        Object.assign(this, init);
    }
}
