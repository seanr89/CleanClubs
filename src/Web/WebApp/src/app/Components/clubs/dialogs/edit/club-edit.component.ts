import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Component, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CreateClubModel } from 'src/app/Models/Clubs/createclubmodel';
import { Club } from 'src/app/Models/Clubs/club';

@Component({
    selector: 'app-club-edit',
    templateUrl: './club-edit.component.html',
    styleUrls: ['./club-edit.component.scss'],
})
export class ClubEditComponent {
    constructor(
        public dialogRef: MatDialogRef<ClubEditComponent>,
        @Inject(MAT_DIALOG_DATA) public data: Club
    ) {}
}
