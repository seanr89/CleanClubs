import { NotificationType } from './Notifitications/notificationtype';

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
