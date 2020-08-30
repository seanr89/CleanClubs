import { Component, OnInit, Input } from '@angular/core';

@Component({
    selector: 'app-page-link',
    templateUrl: './page-link.component.html',
    styleUrls: ['./page-link.component.scss'],
})
export class PageLinkComponent implements OnInit {
    @Input()
    pageName: string;
    @Input()
    pageLink: string;
    @Input()
    pageIcon: string;
    @Input()
    isDropdown: boolean = false;

    isAuthorized: boolean = true;

    opened: boolean;
    showMenu = false;

    constructor() {}

    ngOnInit() {}

    /**
     * Handle the updating of the page title state when the navigation link is clicked
     */
    onClickUpdatePageTitle(): void {
        //this.dataStateService.updatePageTitle(this.pageName);
    }

    toggleMenu() {
        this.showMenu = !this.showMenu;
    }
}
