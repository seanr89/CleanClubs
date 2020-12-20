import { HttpResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { MatchStatus } from 'src/app/Models/enums/matchstatus.enum';
import { Club } from 'src/app/Models/interfaces/clubs/club';
import { Match } from 'src/app/Models/interfaces/match/match';
import { Player } from 'src/app/Models/interfaces/player/player';
import { ClubsService } from 'src/app/Services/API/clubs.service';
import { LocationsService } from 'src/app/Services/API/locations.service';
import { MatchService } from 'src/app/Services/API/match.service';
import { DataStateService } from 'src/app/Services/datastate.service';
import { NotificationsService } from 'src/app/Services/notifications/notifications.service';

@Component({
  selector: 'app-match-schedule',
  templateUrl: './match-schedule.component.html',
  styleUrls: ['./match-schedule.component.scss']
})
export class MatchScheduleComponent implements OnInit {
  private pageName: string = 'Schedule Match';
  club: Club;
  //The match record to go on and be saved!
  matchDetails: Match;
  //Stepper forms
  firstFormGroup: FormGroup;
  secondFormGroup: FormGroup;
  reviewFormGroup: FormGroup;
  selectedDate: Date;
  selectedTime: string;

  teamOne: Player[] = [];
  teamTwo: Player[] = [];

  checked : boolean = false;

  constructor(
    private LocationsService: LocationsService,
    private clubService: ClubsService,
    private matchService: MatchService,
    private dataService: DataStateService,
    private notifications: NotificationsService,
    private _formBuilder: FormBuilder,
    private activeRoute: ActivatedRoute,
) {
    this.dataService.updatePageTitle(this.pageName);

    
}

  ngOnInit(): void {
    
    let id: string = this.activeRoute.snapshot.params['id'];
    this.clubService.GetClubById(id).then((res) => {
      if (res.status === 200) {
          this.club = res.body as Club;

          this.matchDetails = {
              id: '',
              teams: [],
              status: MatchStatus.SCHEDULED,
              date: new Date(),
              invites: [],
              location: "Unknown",
              clubId: this.club.id,
              invitesSent: false
          };
        }
    });
    this.firstFormGroup = this._formBuilder.group({
      locationInput: ['', Validators.required],
      dateInput: ['', Validators.required],
      timeInput: ['', Validators.required],
      invitesInput: [false, Validators.required]
    });
    this.secondFormGroup = this._formBuilder.group({
    });
  }

  /**
     * Handles the save process being triggered
     */
    onSaveMatchClick() {
      console.log('onSaveMatchClick');

      //TODO: needs to be better handled!

      //Support the saving attempt!
      this.matchService.ScheduleMatch(this.matchDetails).then((resp: HttpResponse<Match>) => {
          //Also need to check if this is a 200 or 201 returned!
          if (resp.status === 200) {
              this.notifications.success('Club Created', true);
              //we may want to re-direct here!
          }
          else {
              this.notifications.error("save failed", true);
          }
      });
  }

}
