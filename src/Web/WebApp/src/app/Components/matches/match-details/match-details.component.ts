import { HttpResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { MatchStatus } from 'src/app/Models/enums/matchstatus.enum';
import { Match } from 'src/app/Models/interfaces/match/match';
import { MatchDetailsUpdateModel } from 'src/app/Models/interfaces/match/matchdetailsupdatemodel';
import { DataStateService } from 'src/app/Services/datastate.service';
import { NotificationsService } from 'src/app/Services/notifications/notifications.service';
import { MatchService } from '../../../Services/API/match.service';
import { MatchEditDialogComponent } from '../match-edit-dialog/match-edit-dialog.component';

@Component({
  selector: 'app-match-details',
  templateUrl: './match-details.component.html',
  styleUrls: ['./match-details.component.scss']
})
export class MatchDetailsComponent implements OnInit {
  private pageName: string = 'Match Details';
  match: Match;

  constructor(private matchService: MatchService,
    private dataService: DataStateService,
    private activeRoute: ActivatedRoute,
    public dialog: MatDialog,
    private notifications: NotificationsService) {
      this.dataService.updatePageTitle(this.pageName);
     }

  ngOnInit(): void {
    let id: string = this.activeRoute.snapshot.params['id'];

    if(id !== null){
        //run the query for details specific to the match!
        this.matchService.GetMatchById(id).then((res: HttpResponse<Match> | HttpResponse<string>) => {
          if(res.status === 200)
          {
            this.match = res.body as Match;
          }else{
            this.notifications.error(res.body as string, true);
          }
      });
    }
    else{
      //we should re-route here!
    }
  }

  /**
   * Support click event to open view logic for editing match!
   */
  onEditMatchClick()
  {
      console.log("onEditMatchClick");

      const dialogConfig = new MatDialogConfig();

      dialogConfig.disableClose = true;
      dialogConfig.autoFocus = true;
      dialogConfig.data = this.match;
      // open dialog to add a testReg to the testRegistrations list.
      const dialogRef = this.dialog.open(MatchEditDialogComponent, dialogConfig);

      dialogRef.afterClosed().subscribe((res) => {
        if(res === -1)
        {
          alert("cancelled");
        }
        else
        {
          let match = res as Match;
          //TODO: Update the returning match!
          let matchDetails: MatchDetailsUpdateModel = {
            id : match.id,
            location : match.location,
            status: match.status,
            date : match.date
          }

          this.matchService.UpdateScheduledMatchDetails(matchDetails).then((res : HttpResponse<any>) => {
            if(res.status !== 204){
              //didnt save!
              this.notifications.error("update failed", true);
            }
            //else we refresh the on screen contents!
            else{
              this.notifications.success("match updated", true);
            }
          });
        }
      });
  }

  /**
   * TODO: move this as a utility method at some stage I believe!
   *  */
  getMatchStatus(status: MatchStatus): string{
    return MatchStatus[status];
  }

}
