import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Component, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Club } from 'src/app/Models/interfaces/clubs/club';

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
