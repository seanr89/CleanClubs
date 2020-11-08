import { ViewChild } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { GridPaginatorOption } from 'src/app/Core/grid-paginator-option';
import { ILocation } from 'src/app/Models/interfaces/locations/ilocation';
import { LocationsService } from 'src/app/Services/API/locations.service';
import { DataStateService } from 'src/app/Services/datastate.service';
import { NotificationsService } from 'src/app/Services/notifications/notifications.service';

@Component({
  selector: 'app-locations-list',
  templateUrl: './locations-list.component.html',
  styleUrls: ['./locations-list.component.scss']
})
export class LocationsListComponent implements OnInit {
  private pageName: string = 'Location List';
    dataSource: MatTableDataSource<ILocation>;
    public gridPageOptions: GridPaginatorOption;
    displayedColumns: string[] = ['name', 'active', 'actions'];
    isLoading: boolean = true;
    pageSizeOptions: number[] = [100, 200, 300];

    //Paginator needs to be setup like this as the grid is hidden initially.
    @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
    @ViewChild(MatSort, { static: false }) sort: MatSort;


  constructor(private router: Router,
    private dataService: DataStateService,
    private notifications: NotificationsService,
    private locationsService: LocationsService) {
      this.dataService.updatePageTitle(this.pageName)
    }

  ngOnInit(): void {
    this.dataSource = new MatTableDataSource<ILocation>();
    this.gridPageOptions = new GridPaginatorOption();
    this.gridPageOptions.pageSizeOptions = [10, 25, 100];

    this.locationsService.GetAllLocations().then(res =>{
        //if the results is good set the object
        if (res.status === 200) {
          console.log("locations found");
          this.isLoading = false;
          this.dataSource.data = res.body;
        }
    });
  }

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  /**
   * support re-direction to the details screen
   * @param id : unique location ID
   */
  public redirectToDetails = (id: string) => {
    // let url: string = `/clubs/details/${id}`;
    // this.router.navigate([url]);
  };

  //#region Grid Controls

  public doFilter = (value: string) => {
        this.dataSource.filter = value.trim().toLocaleLowerCase();
  };

  addNew(){
    
  }

  //#endregion

}
