// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
    production: false,
    firebaseConfig: {
        apiKey: 'AIzaSyBoAMBmEPyuBYhFKVcdHaYKnSe6I5_S33M',
        authDomain: 'cleanclubs-da2bc.firebaseapp.com',
        databaseURL: 'https://cleanclubs-da2bc.firebaseio.com',
        projectId: 'cleanclubs-da2bc',
        storageBucket: 'cleanclubs-da2bc.appspot.com',
        messagingSenderId: '126891447011',
        appId: '1:126891447011:web:af1b18328a120ceb6aabd6',
        measurementId: 'G-SG30S31C4T',
    },
    ApiConfig: {
        url: 'https://localhost:5001/api',
    },
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
