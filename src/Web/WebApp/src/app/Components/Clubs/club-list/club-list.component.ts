import { Component, OnInit, ViewChild } from '@angular/core';
import { Club } from 'src/app/Models/club';
import { MatTableDataSource } from '@angular/material/table';
import { ClubsService } from 'src/app/Services/API/clubs.service';
import { Sort, MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { GridPaginatorOption } from 'src/app/Core/grid-paginator-option';
import { Router } from '@angular/router';

@Component({
    selector: 'app-club-list',
    templateUrl: './club-list.component.html',
    styleUrls: ['./club-list.component.scss'],
})
export class ClubListComponent implements OnInit {
    dataSource: MatTableDataSource<Club>;
    public gridPageOptions: GridPaginatorOption;
    displayedColumns: string[] = ['id'];
    isLoading: boolean = false;
    itemsPerPage: number = 100;
    pageSizeOptions: number[] = [100, 200, 300];
    paginatorTotalItems: number = 0;

    constructor(private clubService: ClubsService, private router: Router) {
        this.dataSource = new MatTableDataSource();
        this.gridPageOptions = new GridPaginatorOption();
        this.gridPageOptions.pageSizeOptions = [10, 25, 100];
    }

    ngOnInit(): void {
        this.populateTable();
    }
    //Paginator needs to be setup like this as the grid is hidden initially.
    @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
    @ViewChild(MatSort, { static: false }) sort: MatSort;

    populateTable(): void {
        this.clubService.GetAllClubs().then((res) => {
            if (res.status === 200) {
                console.log('populate Clubs 200');
                res.body.forEach((element) => {
                    console.log(element.id);
                });
                this.isLoading = false;
                this.dataSource = new MatTableDataSource(res.body);
            }
        });
    }

    //#region Grid Controls
    public doFilter = (value: string) => {
        this.dataSource.filter = value.trim().toLocaleLowerCase();
    };
    //#endregion
}
