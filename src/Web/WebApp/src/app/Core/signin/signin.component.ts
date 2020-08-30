import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/Services/auth.service';
import { isNullOrUndefined } from 'util';

@Component({
    selector: 'app-signin',
    templateUrl: './signin.component.html',
    styleUrls: ['./signin.component.scss'],
})
export class SigninComponent implements OnInit {
    public isAuthenticated: boolean = false;

    constructor(public authService: AuthService) {
        this.authService.signedIn.subscribe((user) => {
            if (isNullOrUndefined(user)) this.isAuthenticated = false;
            else this.isAuthenticated = true;
        });
    }

    ngOnInit(): void {}
}
