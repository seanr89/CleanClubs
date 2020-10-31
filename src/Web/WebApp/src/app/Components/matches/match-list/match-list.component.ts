import { HttpResponse } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { GridPaginatorOption } from 'src/app/Core/grid-paginator-option';
import { MatchStatus } from 'src/app/Models/enums/matchstatus.enum';
import { Match } from 'src/app/Models/interfaces/match/match';
import { MatchService } from 'src/app/Services/API/match.service';
import { DataStateService } from 'src/app/Services/datastate.service';
import { NotificationsService } from 'src/app/Services/notifications/notifications.service';

@Component({
    selector: 'app-match-list',
    templateUrl: './match-list.component.html',
    styleUrls: ['./match-list.component.scss'],
})
export class MatchListComponent implements OnInit {
    private pageName: string = 'Match List';
    dataSource: MatTableDataSource<Match>;
    public gridPageOptions: GridPaginatorOption;
    displayedColumns: string[] = ['date', 'status', 'location'];
    isLoading: boolean = true;

    @Input()
    clubId: string;

    constructor(private router: Router,
      private dataService: DataStateService,
      private matchService: MatchService,
      private activeRoute: ActivatedRoute,
      private notifications: NotificationsService) {
        this.dataService.updatePageTitle(this.pageName);
    }

    ngOnInit(): void {
      this.dataSource = new MatTableDataSource<Match>();
      //handle query to get all matches you can query!
      this.matchService.GetMatchesForClub(this.clubId).then((res: HttpResponse<Match[]> | HttpResponse<string>) => {
        if(res.status === 200)
        {
          let arrayData: Match[] = res.body as Match[];
          this.dataSource.data = arrayData;
          this.isLoading = false;
        }
        else{
          this.notifications.error(res.body as string, true);
          this.isLoading = false;
        }
      });
    }

    getMatchStatusString(status: MatchStatus): string{
      return MatchStatus[status];
    }

    //#region Grid Controls
    public doFilter = (value: string) => {
        this.dataSource.filter = value.trim().toLocaleLowerCase();
    };

    onRowDoubleClick(row)
    {
      let url: string = `/matches/details/${row.id}`;
      this.router.navigate([url]);
    }

    ////#endregion
}
