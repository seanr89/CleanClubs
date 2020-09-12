import { Component, OnInit, Input } from '@angular/core';
import { AuthService } from 'src/app/Services/auth.service';
import { isNullOrUndefined } from 'util';

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

    constructor(private authService: AuthService) {}

    ngOnInit() {
        this.authService.signedIn.subscribe((res) => {
            if (isNullOrUndefined(res)) this.isAuthorized = false;
            else this.isAuthorized = true;
        });
    }

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
