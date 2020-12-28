import { Component, OnInit, ViewChild } from '@angular/core';
import {
    CdkDragDrop,
    moveItemInArray,
    transferArrayItem,
} from '@angular/cdk/drag-drop';
import { ClubsService } from 'src/app/Services/API/clubs.service';
import { ActivatedRoute, Router } from '@angular/router';
import { DataStateService } from 'src/app/Services/datastate.service';
import { NotificationsService } from 'src/app/Services/notifications/notifications.service';
import { Utilities } from 'src/app/Core/shared/utilities';
import { MatchService } from '../../../Services/API/match.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import * as dayjs from 'dayjs';
import { MemberListComponent } from '../../members/member-list/member-list.component';
import { HttpResponse } from '@angular/common/http';
import { MatchStatus } from 'src/app/Models/enums/matchstatus.enum';
import { Club } from 'src/app/Models/interfaces/clubs/club';
import { Match } from 'src/app/Models/interfaces/match/match';
import { Member } from 'src/app/Models/interfaces/members/member';
import { Player } from 'src/app/Models/interfaces/player/player';
import { Team } from 'src/app/Models/interfaces/team/team';

@Component({
    selector: 'app-match-team-create',
    templateUrl: './match-team-create.component.html',
    styleUrls: ['./match-team-create.component.scss'],
})
export class MatchTeamCreateComponent implements OnInit {
    @ViewChild(MemberListComponent) memberList;
    private pageName: string = 'Create Match';
    club: Club;
    //The match record to go on and be saved!
    matchDetails: Match;
    checked = false;

    //Stepper forms
    firstFormGroup: FormGroup;
    secondFormGroup: FormGroup;
    reviewFormGroup: FormGroup;

    selectedDate: Date;
    selectedTime: string;

    teamOne: Player[] = [];
    teamTwo: Player[] = [];

    constructor(
        private clubService: ClubsService,
        private matchService: MatchService,
        private dataService: DataStateService,
        private activeRoute: ActivatedRoute,
        private notifications: NotificationsService,
        private _formBuilder: FormBuilder
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

    //#region Drag&Drop

    drop(event: CdkDragDrop<string[]>) {
        if (event.previousContainer === event.container) {
            moveItemInArray(
                event.container.data,
                event.previousIndex,
                event.currentIndex
            );
        } else {
            transferArrayItem(
                event.previousContainer.data,
                event.container.data,
                event.previousIndex,
                event.currentIndex
            );
        }
    }

    //#endregion

    //#region Click Events
    onGenerateClick() {
        let selectedMembers = this.memberList.getAllSelected();
        if (selectedMembers !== null) {
            this.teamOne = [];
            this.teamTwo = [];

            //alert('members selected!');
            this.createRandomMemberSplit(selectedMembers);
        }
    }

    /**
     * Handles the save process being triggered
     */
    onSaveMatchClick() {
        console.log('onSaveMatchClick');

        this.matchDetails.date = this.combineDateAndTime();
        this.matchDetails.teams = [];

        //TODO: This is all really messy and needs re-worked!!
        let teamOne: Team = {} as Team;
        let teamTwo: Team = {} as Team;
        teamOne.players = [];
        teamTwo.players = [];

        teamOne.players = this.teamOne;
        teamTwo.players = this.teamTwo;
        this.matchDetails.teams.push(teamOne);
        this.matchDetails.teams.push(teamTwo);

        //Support the saving attempt!
        this.matchService.CreateMatchWithTeams(this.matchDetails).then((resp: HttpResponse<Match>) => {
            //Also need to check if this is a 200 or 201 returned!
            if (resp.status === 200) {
                this.notifications.success('Match Created', true);
                //we may want to re-direct here!
            }
            else {
                this.notifications.error("save failed", true);
            }
        });
    }

    //#endregion

    /**
     * Support the random splitting of selected members into two teams
     * @param members : selected member list
     */
    createRandomMemberSplit(members: Member[]) {
        //utility process to randomize the list
        Utilities.shuffle(members);

        //calculate array length then split it
        let arrayLength: number = members.length;
        let members1 = members.slice(0, arrayLength / 2);
        let members2 = members.slice(arrayLength / 2 + 1);

        //This a side-affect and needs to be removed/moved somewhere else
        //OR needs to be re-named
        this.teamOne = this.createPlayersFromMembers(members1);
        this.teamTwo = this.createPlayersFromMembers(members2);
    }

    /**
     * parse a list of members and re-work into the players
     * @param members : array of members to be re-formatted
     * @returns an array of players
     */
    createPlayersFromMembers(members: Member[]): Player[] {
        let players = [];
        members.forEach(element => {
            let player: Player = {
                id: null,
                firstName: element.firstName,
                lastName: element.lastName,
                email: element.email,
                rating: element.rating,
                memberId: element.id
            }
            players.push(player);
        });
        return players;
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
