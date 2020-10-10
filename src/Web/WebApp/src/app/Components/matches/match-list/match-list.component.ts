import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { GridPaginatorOption } from 'src/app/Core/grid-paginator-option';
import { Match } from 'src/app/Models/match/match';
import { DataStateService } from 'src/app/Services/datastate.service';

@Component({
    selector: 'app-match-list',
    templateUrl: './match-list.component.html',
    styleUrls: ['./match-list.component.scss'],
})
export class MatchListComponent implements OnInit {
    private pageName: string = 'Match List';
    dataSource: MatTableDataSource<Match>;
    public gridPageOptions: GridPaginatorOption;
    displayedColumns: string[] = ['date', 'status'];
    isLoading: boolean = false;

    constructor(private router: Router, private dataService: DataStateService) {
        this.dataService.updatePageTitle(this.pageName);
    }

    ngOnInit(): void {}

    //#region Grid Controls
    public doFilter = (value: string) => {
        this.dataSource.filter = value.trim().toLocaleLowerCase();
    };

    ////#endregion
}
