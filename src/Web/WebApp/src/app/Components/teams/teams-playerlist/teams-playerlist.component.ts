import { Component, Input, OnInit } from '@angular/core';
import { Player } from 'src/app/Models/interfaces/player/player';
import { NotificationsService } from 'src/app/Services/notifications/notifications.service';

@Component({
  selector: 'app-teams-playerlist',
  templateUrl: './teams-playerlist.component.html',
  styleUrls: ['./teams-playerlist.component.scss']
})
export class TeamsPlayerlistComponent implements OnInit {

  @Input()
  teamOnePlayers: Player[];
  @Input()
  teamTwoPlayers: Player[];

  constructor() { }

  ngOnInit(): void {
  }

}
