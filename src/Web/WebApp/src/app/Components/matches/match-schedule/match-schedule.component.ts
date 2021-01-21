import { HttpResponse } from '@angular/common/http';

import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import * as dayjs from 'dayjs';
import { Utilities } from 'src/app/Core/shared/utilities';
import { MatchStatus } from 'src/app/Models/enums/matchstatus.enum';
import { Club } from 'src/app/Models/interfaces/clubs/club';
import { Match } from 'src/app/Models/interfaces/match/match';
import { ScheduleMatchModel } from 'src/app/Models/interfaces/match/schedulematchmodel';
import { Player } from 'src/app/Models/interfaces/player/player';
import { ClubsService } from 'src/app/Services/API/clubs.service';
import { LocationsService } from 'src/app/Services/API/locations.service';
import { MatchService } from 'src/app/Services/API/match.service';
import { DataStateService } from 'src/app/Services/datastate.service';
import { NotificationsService } from 'src/app/Services/notifications/notifications.service';
import { MemberListComponent } from '../../members/member-list/member-list.component';


@Component({
  selector: 'app-match-schedule',
  templateUrl: './match-schedule.component.html',
  styleUrls: ['./match-schedule.component.scss']
})
export class MatchScheduleComponent implements OnInit {
  private pageName: string = 'Schedule Match';
  @ViewChild(MemberListComponent) memberList;
  club: Club;
  //The match record to go on and be saved!
  matchDetails: ScheduleMatchModel;
  //Stepper forms
  firstFormGroup: FormGroup;
  secondFormGroup: FormGroup;

  selectedDate: Date;
  selectedTime: string;

  checked = false;
  autoInvite : boolean = false;

  constructor(
    private clubService: ClubsService,
    private matchService: MatchService,
    private dataService: DataStateService,
    private notifications: NotificationsService,
    private _formBuilder: FormBuilder,
    private activeRoute: ActivatedRoute,
) {
    this.dataService.updatePageTitle(this.pageName);

    let id: string = this.activeRoute.snapshot.params['id'];
    this.clubService.GetClubById(id).then((res) => {
      if (res.status === 200) {
        this.club = res.body as Club;

        this.matchDetails = this.initialiseMatchDetails();
    }});

}

ngOnInit(): void {

    this.firstFormGroup = this._formBuilder.group({
      locationInput: ['', Validators.required],
      dateInput: ['', Validators.required],
      timeInput: ['', Validators.required],
      inviteInput: ['', Validators.required]
    });
    this.secondFormGroup = this._formBuilder.group({
    });
  }

  public onChecked(event: any) {
    this.checked = event
}

  /**
     * Handles the save process being triggered
     */
    onSaveMatchClick() {
      console.log('onSaveMatchClick');

      //TODO: needs to be better handled!
      this.updateMatchDetailsForSaving();
      debugger;
      //Support the saving attempt!
      this.matchService.ScheduleMatch(this.matchDetails).then((resp: HttpResponse<Match>) => {
          //Also need to check if this is a 200 or 201 returned!
          if (resp.status === 200) {
              this.notifications.success('Match Scheduled', true);
              //we may want to re-direct here!
          }
          else {
              this.notifications.error("save failed", true);
          }
      });
  }

  updateMatchDetailsForSaving(){
    console.log('updateMatchDetailsForSaving');
    debugger;

    this.matchDetails.date = this.combineDateAndTime();
    this.matchDetails.sendInvites = this.checked;

    if(this.autoInvite == false)
    {
      this.matchDetails.selectedMembers = this.memberList.getAllSelected();
    }
  }

  initialiseMatchDetails() : ScheduleMatchModel{
    //console.log('initialiseMatchDetails');
      let obj : ScheduleMatchModel = {
        status: MatchStatus.SCHEDULED,
        date: new Date(),
        selectedMembers: [],
        location: "Unknown",
        clubId: this.club.id,
        sendInvites: false,
    }
    return obj;
  }

  /**
     * Merges the date and time picker element content into a single date/moment record!
     * @returns : a combined Date object with the Date and Time combined
     */
    combineDateAndTime(): Date {
      let hours: number;
      let minutes: number;

      if (!Utilities.IsEmpty(this.selectedDate)) {
          hours = parseInt(this.selectedTime.substring(0, 2));
          minutes = parseInt(this.selectedTime.substring(3, 5));
      }

      let date = this.selectedDate;
      let dateDay = dayjs(date);
      dateDay = dayjs(dateDay).add(hours, 'hour')
      dateDay = dayjs(dateDay).add(minutes, 'minute')
      return dateDay.toDate()
  }
}
