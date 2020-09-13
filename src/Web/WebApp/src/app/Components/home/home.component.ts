import { Component, OnInit } from '@angular/core';
import { DataStateService } from 'src/app/Services/datastate.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  constructor(private dataState: DataStateService) {
    this.dataState.updatePageTitle("Home");
   }

  ngOnInit(): void {
  }

}
