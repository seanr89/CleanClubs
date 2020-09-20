export class Utilities {
    //Get the name of a variable name from the given interface
    public static NameOf<A, B = {}>(): <A>(
        name: keyof A,
        name2?: keyof B
    ) => any {
        return <A>(name: keyof A, name2?: keyof B) => {
            if (name2 !== undefined) {
                return `${name}.${name2}`;
            } else return name;
        };
    }

    //Formats the passed through date to local client time.
    // static getUTCDate = (date: Date): Date => {
    //     let utcOffset = moment(date).utcOffset();
    //     return moment.utc(date).utcOffset(utcOffset).toDate();
    // };

    //Formats the passed through date to local client time.
    // static getDateAndTime = (date: Date): string => {
    //     let utcOffset = moment(date).utcOffset();
    //     return moment
    //         .utc(date)
    //         .utcOffset(utcOffset)
    //         .format('MMM-DD-YYYY HH:mm');
    // };

    //Get the time in minutes between the two given dates.
    static getDifferenceInMinutes(date1: Date, date2: Date): number {
        let difference = (date2.getTime() - date1.getTime()) / 1000;
        difference /= 60;
        return Math.abs(difference);
    }

    /**
     * Helper method to generate a UUID for instances where one could be needed
     * Found on stack-overflow
     */
    static generateUUID = () => {
        // Public Domain/MIT
        var d = new Date().getTime(); //Timestamp
        var d2 =
            (performance && performance.now && performance.now() * 1000) || 0; //Time in microseconds since page-load or 0 if unsupported
        return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(
            /[xy]/g,
            function (c) {
                var r = Math.random() * 16; //random number between 0 and 16
                if (d > 0) {
                    //Use timestamp until depleted
                    r = (d + r) % 16 | 0;
                    d = Math.floor(d / 16);
                } else {
                    //Use microseconds since page-load if supported
                    r = (d2 + r) % 16 | 0;
                    d2 = Math.floor(d2 / 16);
                }
                return (c === 'x' ? r : (r & 0x3) | 0x8).toString(16);
            }
        );
    };

    //Checks if an object is empty.
    static IsEmpty(value: any): boolean {
        return value === '' || value === null || value === undefined;
    }
}
