import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Club } from 'src/app/Models/Clubs/club';
import { ClubsService } from 'src/app/Services/API/clubs.service';
import { DataStateService } from 'src/app/Services/datastate.service';
import { NotificationsService } from 'src/app/Services/notifications/notifications.service';

@Component({
    selector: 'app-club-details',
    templateUrl: './club-details.component.html',
    styleUrls: ['./club-details.component.scss'],
})
export class ClubDetailsComponent implements OnInit {
    private pageName: string = 'Club Details';
    club: Club;

    constructor(
        private clubService: ClubsService,
        private router: Router,
        private dataService: DataStateService,
        private activeRoute: ActivatedRoute,
        private notifications: NotificationsService
    ) {}

    ngOnInit(): void {
        this.dataService.updatePageTitle(this.pageName);
        this.getClubDetails();
    }

    private getClubDetails = () => {
        let id: string = this.activeRoute.snapshot.params['id'];

        this.clubService.GetClubById(id).then((res) => {
            if (res.status === 200) {
                this.club = res.body as Club;
                //console.log(`members count ${this.club.members.length}`);
            }
        });
    };

    ////////////////////////////////////////////////////////////////
    //Button Click Events

    public redirectToMatchCreate = () => {
        let url: string = `/creatematch/${this.club.id}`;
        this.router.navigate([url]);
    };
}
