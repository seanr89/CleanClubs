import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import * as dayjs from 'dayjs';
import { MatchStatus } from 'src/app/Models/enums/matchstatus.enum';
import { Match } from 'src/app/Models/interfaces/match/match';

@Component({
  selector: 'app-match-edit-dialog',
  templateUrl: './match-edit-dialog.component.html',
  styleUrls: ['./match-edit-dialog.component.scss']
})

//https://github.com/angular-university/angular-material-course/blob/3-dialog-finished/src/app/course-dialog/course-dialog.component.html
//https://blog.angular-university.io/angular-material-dialog/
//https://github.com/h2qutc/angular-material-components
export class MatchEditDialogComponent implements OnInit {

  form: FormGroup;
  match: Match;
  keys = [];
  matchStatus = MatchStatus

  constructor(private fb: FormBuilder
    ,public dialogRef: MatDialogRef<MatchEditDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Match) {
      this.match = data;
      //used for setting up the status options!
      this.keys = Object.keys(this.matchStatus).filter(k => !isNaN(Number(k)));

      this.form = fb.group({
          location: [this.match.location, Validators.required],
          dateControl: [this.match.date, Validators.required],
          status: ["", Validators.required]
      });
     }

  ngOnInit(): void {
  }

  save() {
    this.dialogRef.close(this.form.value);
  }

  close() {
      this.dialogRef.close(-1);
  }

  /**
   * TODO: move this as a utility method at some stage I believe!
   *  */
  getMatchStatus(status: MatchStatus): string{
    return MatchStatus[status];
  }


}
