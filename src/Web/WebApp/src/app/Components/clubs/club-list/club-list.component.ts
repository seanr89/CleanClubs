import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ClubsService } from 'src/app/Services/API/clubs.service';
import { Sort, MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { GridPaginatorOption } from 'src/app/Core/grid-paginator-option';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { ClubAddComponent } from '../dialogs/add/club-add.component';
import { DataStateService } from 'src/app/Services/datastate.service';
import { HttpResponse } from '@angular/common/http';
import { NotificationsService } from 'src/app/Services/notifications/notifications.service';
import { AuthService } from 'src/app/Services/auth.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Club } from 'src/app/Models/interfaces/clubs/club';
import { CreateClubModel } from 'src/app/Models/interfaces/clubs/createclubmodel';

@Component({
    selector: 'app-club-list',
    templateUrl: './club-list.component.html',
    styleUrls: ['./club-list.component.scss'],
})
export class ClubListComponent implements OnInit {
    private pageName: string = 'Club List';
    dataSource: MatTableDataSource<Club>;
    public gridPageOptions: GridPaginatorOption;
    displayedColumns: string[] = ['name', 'active', 'private', 'actions'];
    isLoading: boolean = true;
    pageSizeOptions: number[] = [100, 200, 300];
    filterForm: FormGroup;

    constructor(
        private clubService: ClubsService,
        private router: Router,
        public dialog: MatDialog,
        private dataService: DataStateService,
        private notifications: NotificationsService,
        private authService: AuthService,
        private _formBuilder: FormBuilder
    ) {
        this.dataSource = new MatTableDataSource<Club>();
        this.gridPageOptions = new GridPaginatorOption();
        this.gridPageOptions.pageSizeOptions = [10, 25, 100];

        this.filterForm = this._formBuilder.group({});
    }

    ngOnInit(): void {
        this.dataService.updatePageTitle(this.pageName);
        this.populateTable();
    }

    ngAfterViewInit(): void {
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
    }

    //Paginator needs to be setup like this as the grid is hidden initially.
    @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
    @ViewChild(MatSort, { static: false }) sort: MatSort;

    populateTable(): void {
        this.clubService.GetAllClubs().then((res) => {
            if (res.status === 200) {
                this.isLoading = false;
                this.dataSource.data = res.body;
            }
        });
    }

    //#region Grid Controls and Click Events
    public doFilter = (value: string) => {
        this.dataSource.filter = value.trim().toLocaleLowerCase();
    };

    /**
     * support re-direction to the clubs screen!
     * @param id : unique club ID
     */
    public redirectToDetails = (id: string) => {
        let url: string = `/clubs/details/${id}`;
        this.router.navigate([url]);
    };

    onRowDoubleClick(row) {
        let url: string = `/clubs/details/${row.id}`;
        this.router.navigate([url]);
    }

    public addNew() {
        //Opens the add dialog box - with dummy data included
        let club: CreateClubModel = {
            name: '',
            private: false,
            creator: '',
        };
        const dialogRef = this.dialog.open(ClubAddComponent, {
            data: club,
        });

        //Handles the close of the dialog box
        dialogRef.afterClosed().subscribe((result: CreateClubModel) => {
            //If the save button is clicked then add test
            if (result != null) {
                result.creator = this.authService.userData.email;
                this.clubService
                    .CreateClub(result)
                    .then((resp: HttpResponse<CreateClubModel>) => {
                        //we may need to refresh the datasource!
                        if (resp.status === 201) {
                            this.notifications.success('Club Created', true);
                            this.populateTable();
                        } else {
                            this.notifications.error(
                                'Failed to save club',
                                true
                            );
                        }
                    });
            } else {
                //this has been closed!
            }
        });
    }
    //#endregion
}
