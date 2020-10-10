import { Component, OnInit, ViewChild } from '@angular/core';
import {
    CdkDragDrop,
    moveItemInArray,
    transferArrayItem,
} from '@angular/cdk/drag-drop';
import { Club } from 'src/app/Models/Clubs/club';
import { ClubsService } from 'src/app/Services/API/clubs.service';
import { ActivatedRoute, Router } from '@angular/router';
import { DataStateService } from 'src/app/Services/datastate.service';
import { NotificationsService } from 'src/app/Services/notifications/notifications.service';
import { Team } from 'src/app/Models/team/team';
import { MemberListComponent } from '../../clubs/member-list/member-list.component';
import { Member } from 'src/app/Models/Members/member';
import { Player } from 'src/app/Models/player/player';
import { Utilities } from 'src/app/Core/shared/utilities';
import { MatDialog } from '@angular/material/dialog';
import { MatchCreateDialogComponent } from '../match-create-dialog/match-create-dialog.component';
import { Match } from 'src/app/Models/match/match';
import { MatchService } from '../../../Services/API/match.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import * as dayjs from 'dayjs';

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
        public dialog: MatDialog,
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
                    status: 0,
                    date: new Date(),
                    invites: [],
                    location: '',
                    clubId: this.club.id
                };
            }
        });

        this.firstFormGroup = this._formBuilder.group({
            locationInput: ['', Validators.required],
            dateInput: ['', Validators.required],
            timeInput: ['', Validators.required]
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

    onSaveMatchClick() {
        console.log('onSaveMatchClick');

        this.matchDetails.date = this.combineDateAndTime();
        
        //TODO: create and populate the match
        //let record: Match = {} as Match;
        this.matchDetails.teams = [];

        let teamOne: Team = {} as Team;
        let teamTwo: Team = {} as Team;
        teamOne.players = [];
        teamTwo.players = [];

        teamOne.players = this.teamOne;
        teamTwo.players = this.teamTwo;
        this.matchDetails.teams.push(teamOne);
        this.matchDetails.teams.push(teamTwo);

        this.matchService.CreateMatchWithTeams(this.matchDetails).then(() => {});

        // const dialogRef = this.dialog.open(MatchCreateDialogComponent, {
        //     data: record,
        // });

        // //Handles the close of the dialog box
        // dialogRef.afterClosed().subscribe((res: Match | number) => {
        //     //If the save button is clicked then add test
        //     //alert('create match closed!');
        //     if (res !== -1 && res !== undefined)
        //         this.matchService.CreateMatchWithTeams(res as Match).then(() => {});
        // });
    }

    //#endregion

    /**
     * Support the random splitting of selected members into two teams
     * @param members : selected member list
     */
    createRandomMemberSplit(members: Member[]) {
        console.log('createRandomMemberSplit');
        Utilities.shuffle(members);

        let arrayLength: number = members.length;
        let members1 = members.slice(0, arrayLength / 2);
        let members2 = members.slice(arrayLength / 2 + 1);

        this.teamOne = this.createPlayersFromMembers(members1);
        this.teamTwo = this.createPlayersFromMembers(members2);
    }

    createPlayersFromMembers(members: Member[]) : Player[]
    {
        let players = [];
        members.forEach(element => {
            let player :Player = {
                id: null,
                firstName: element.firstName,
                lastName: element.lastName,
                email: element.email,
                rating: element.rating,
                memberId : element.id
            }
            players.push(player);
        });
        return players;
    }

    /**
     * Support the merging of date and time picker element content into a single date/moment record!
     */
    combineDateAndTime() : Date
    {
        console.log("combineDateAndTime");
        let hours: number;
        let minutes: number;

        if (!Utilities.IsEmpty(this.selectedDate)) {
            hours = parseInt(this.selectedTime.substring(0, 2));
            minutes = parseInt(this.selectedTime.substring(3, 5));
        }

        let date = this.selectedDate;

        let dateDay = dayjs(date);
        dateDay = dayjs(dateDay).add(hours, 'hour');
        dateDay = dayjs(dateDay).add(minutes, 'minute');

        return dateDay.toDate()
    }


}
