import { SelectionModel } from '@angular/cdk/collections';
import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { GridPaginatorOption } from 'src/app/Core/grid-paginator-option';
import { Member } from 'src/app/Models/Members/member';
import { AuthService } from 'src/app/Services/auth.service';
import { DataStateService } from 'src/app/Services/datastate.service';
import { NotificationsService } from 'src/app/Services/notifications/notifications.service';

@Component({
    selector: 'app-member-list',
    templateUrl: './member-list.component.html',
    styleUrls: ['./member-list.component.scss'],
})
export class MemberListComponent implements OnInit {
    @Input()
    members: Member[];
    dataSource: MatTableDataSource<Member>;
    selection = new SelectionModel<Member>(true, []);
    public gridPageOptions: GridPaginatorOption;
    displayedColumns: string[] = [
        'select',
        'fname',
        'lname',
        'email',
        'rating',
    ];
    isLoading: boolean = false;
    pageSizeOptions: number[] = [100, 200, 300];

    constructor(
        private router: Router,
        private dataService: DataStateService,
        private notifications: NotificationsService,
        private authService: AuthService
    ) {
        this.dataSource = new MatTableDataSource<Member>();
        this.gridPageOptions = new GridPaginatorOption();
        this.gridPageOptions.pageSizeOptions = [10, 25, 100];
    }

    //Paginator needs to be setup like this as the grid is hidden initially.
    @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
    @ViewChild(MatSort, { static: false }) sort: MatSort;

    ngOnInit(): void {
        //this.populateTable();
    }

    ngAfterViewInit(): void {
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;

        if (this.members !== null) {
            console.log(`members = ${this.members.length}`);
            this.isLoading = false;
            this.dataSource.data = this.members;
        }
    }

    //#region Grid Controls
    public doFilter = (value: string) => {
        this.dataSource.filter = value.trim().toLocaleLowerCase();
    };

    ////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////
    // Members and Selection Events

    /** Whether the number of selected elements matches the total number of rows. */
    isAllSelected() {
        const numSelected = this.selection.selected.length;
        const numRows = this.dataSource.data.length;
        return numSelected === numRows;
    }

    /** Selects all rows if they are not all selected; otherwise clear selection. */
    masterToggle() {
        this.isAllSelected()
            ? this.selection.clear()
            : this.dataSource.data.forEach((row) => this.selection.select(row));
    }

    public getAllSelected(): Member[] {
        console.log('getAllSelected');
        return this.selection.selected;
    }
}
