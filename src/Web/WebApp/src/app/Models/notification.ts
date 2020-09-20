//import { NotificationType } from '../../enums/notificationtype';

export class Notification {
    //type: NotificationType;
    typeName: string;
    message: string;
    notificationId: string;
    //keepAfterRouteChange: boolean;
    hasBeenRead: boolean = false;
    eventTime: Date;

    constructor(init?: Partial<Notification>) {
        Object.assign(this, init);
    }
}
