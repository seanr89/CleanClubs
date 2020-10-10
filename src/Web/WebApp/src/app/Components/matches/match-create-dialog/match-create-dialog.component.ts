import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Match } from 'src/app/Models/match/match';

@Component({
    selector: 'app-match-create-dialog',
    templateUrl: './match-create-dialog.component.html',
    styleUrls: ['./match-create-dialog.component.scss'],
})
export class MatchCreateDialogComponent {

    //FormGroup for validation of the create clinic form.
    form: FormGroup;

    constructor(public dialogRef: MatDialogRef<MatchCreateDialogComponent>,
        @Inject(MAT_DIALOG_DATA) public data: Match) {
        }

  ngOnInit(): void {
    //Add validation to make sure fields have been added correctly
    this.form = new FormGroup({
        selectedDate: new FormControl('', []),
        selectedTime: new FormControl('', []),
    });
    }

    get selectedDate() {
        return this.form.get('inputDate');
    }

    get selectedTime() {
        return this.form.get('inputTime');
    }
}
