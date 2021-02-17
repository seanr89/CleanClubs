import { SelectionModel } from '@angular/cdk/collections';
import { OnChanges, SimpleChanges } from '@angular/core';
import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { GridPaginatorOption } from 'src/app/Core/grid-paginator-option';
import { Member } from 'src/app/Models/interfaces/members/member';
import { AuthService } from 'src/app/Services/auth.service';
import { DataStateService } from 'src/app/Services/datastate.service';
import { NotificationsService } from 'src/app/Services/notifications/notifications.service';

@Component({
    selector: 'app-member-list',
    templateUrl: './member-list.component.html',
    styleUrls: ['./member-list.component.scss'],
})
export class MemberListComponent implements OnInit, OnChanges {
    @Input()
    members: Member[];
    @Input()
    showSelector: boolean = false;

    dataSource: MatTableDataSource<Member>;
    selection = new SelectionModel<Member>(true, []);
    public gridPageOptions: GridPaginatorOption;
    displayedColumns: string[] = [];
    isLoading: boolean = true;

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
        if (this.showSelector) {
            this.setColumnsWithSelection();
        } else {
            this.setColumns();
        }
    }

    ngOnChanges(changes: SimpleChanges): void {
        for (const propName in changes) {
            if (changes.hasOwnProperty(propName)) {
                switch (propName) {
                    case 'members': {
                        this.initialiseDataSource();
                    }
                }
            }
        }
    }

    ngAfterViewInit(): void {
        //Initially configure pagination and sorting!
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;

        this.initialiseDataSource();
    }

    initialiseDataSource() {
        if (this.members !== null) {
            this.isLoading = false;
            this.dataSource.data = this.members;
        }
    }

    //#region Grid Controls
    public doFilter = (value: string) => {
        this.dataSource.filter = value.trim().toLocaleLowerCase();
    };

    //#region ColumnSelection

    setColumns() {
        this.displayedColumns = ['fname', 'lname', 'email', 'rating'];
    }

    setColumnsWithSelection() {
        this.displayedColumns = ['select', 'fname', 'lname', 'email', 'rating'];
    }

    //#region

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

    /**
     * supports the select all requested to check all items!
     */
    public getAllSelected(): Member[] {
        return this.selection.selected;
    }
}
