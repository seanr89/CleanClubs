import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DataStateService } from 'src/app/Services/datastate.service';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.scss'],
})
export class HomeComponent {
    private title: string = 'Home';

    gridColumns = 3;

    constructor(private dataState: DataStateService, private router: Router) {
        this.dataState.updatePageTitle(this.title);
    }

    toggleGridColumns() {
        this.gridColumns = this.gridColumns === 3 ? 4 : 3;
    }
}
