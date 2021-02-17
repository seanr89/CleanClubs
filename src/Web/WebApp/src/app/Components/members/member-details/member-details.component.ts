import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Member } from 'src/app/Models/interfaces/members/member';
import { MembersService } from 'src/app/Services/API/members.service';
import { DataStateService } from 'src/app/Services/datastate.service';
import { NotificationsService } from 'src/app/Services/notifications/notifications.service';

@Component({
  selector: 'app-member-details',
  templateUrl: './member-details.component.html',
  styleUrls: ['./member-details.component.scss']
})
export class MemberDetailsComponent implements OnInit {

  private pageName: string = 'Member Details';
    record: Member;

    constructor(
        private memberService: MembersService,
        private router: Router,
        private dataService: DataStateService,
        private activeRoute: ActivatedRoute,
        private notifications: NotificationsService
    ) {}

  ngOnInit(): void {
  }

}
