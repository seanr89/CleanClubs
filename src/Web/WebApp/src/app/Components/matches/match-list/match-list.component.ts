import { HttpResponse } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { GridPaginatorOption } from 'src/app/Core/grid-paginator-option';
import { Match } from 'src/app/Models/interfaces/match/match';
import { MatchService } from 'src/app/Services/API/match.service';
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

    @Input()
    clubId: string;

    constructor(private router: Router,
      private dataService: DataStateService,
      private matchService: MatchService,
      private activeRoute: ActivatedRoute) {
        this.dataService.updatePageTitle(this.pageName);
    }

    ngOnInit(): void {
      //handle query to get all matches you can query!
      this.matchService.GetMatchesForClub(this.clubId).then((resp: HttpResponse<Match[]>) => {
        //TODO: comment and handle errors!
        if(resp.status === 200)
        {
          this.dataSource.data = resp.body as Match[];
        }
        else{
          alert("No matches found!");
        }
      });
    }

    //#region Grid Controls
    public doFilter = (value: string) => {
        this.dataSource.filter = value.trim().toLocaleLowerCase();
    };

    ////#endregion
}
