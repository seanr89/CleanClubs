import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
    providedIn: 'root',
})

/**
 * Communication service designed provide a method to allow components to interact with each other using a for of "State"
 */
export class DataStateService {
    private pageTitle: BehaviorSubject<string>;
    public storage: any;
    constructor() {
        this.pageTitle = new BehaviorSubject<string>('Clubs App');
    }

    /**
     * update the current nav pageTitle
     * @param {string} value: the title of the current page/component
     */
    updatePageTitle = (value: string) => {
        this.pageTitle.next(value);
    };

    /**
     * request the current pageTitle
     * @returns {Observable<string>}: An observable of the current pageTitle
     */
    getPageTitle(): Observable<string> {
        return this.pageTitle.asObservable();
    }
}
