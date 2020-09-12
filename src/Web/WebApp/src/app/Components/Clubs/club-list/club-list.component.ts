import { Component, OnInit, ViewChild } from '@angular/core';
import { Club } from 'src/app/Models/club';
import { MatTableDataSource } from '@angular/material/table';
import { ClubsService } from 'src/app/Services/API/clubs.service';
import { Sort, MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';

@Component({
    selector: 'app-club-list',
    templateUrl: './club-list.component.html',
    styleUrls: ['./club-list.component.scss'],
})
export class ClubListComponent implements OnInit {
    dataSource: MatTableDataSource<Club>;
    //public gridPageOptions: GridPaginatorOption;
    displayedColumns: string[] = ['id', 'name'];
    isLoading: boolean = false;
    itemsPerPage: number = 100;
    pageSizeOptions: number[] = [100, 200, 300];
    paginatorTotalItems: number = 0;

    constructor(private clubService: ClubsService) {}

    ngOnInit(): void {
        this.populateTable();
    }
    //Paginator needs to be setup like this as the grid is hidden initially.
    //@ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
    @ViewChild(MatSort, { static: false }) sort: MatSort;

    populateTable(): void {
        this.clubService.GetAllClubs().then((res) => {
            if (res.status === 200) {
                this.isLoading = false;
            }
        });
    }

    //Called with the header ordering is clicked on the grid.
    sortData(sort: Sort): void {}

    //#region Grid Controls

    public doFilter = (value: string) => {
        this.dataSource.filter = value.trim().toLocaleLowerCase();
    };
    //#endregion
}
