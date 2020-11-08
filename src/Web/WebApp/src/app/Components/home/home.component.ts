import { Component, OnInit } from '@angular/core';
import { DataStateService } from 'src/app/Services/datastate.service';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
    private title: string = 'Home';
    
    gridColumns = 3;

    constructor(private dataState: DataStateService) {
        this.dataState.updatePageTitle(this.title);
    }

    ngOnInit(): void {}


    toggleGridColumns() {
      this.gridColumns = this.gridColumns === 3 ? 4 : 3;
    }
}
