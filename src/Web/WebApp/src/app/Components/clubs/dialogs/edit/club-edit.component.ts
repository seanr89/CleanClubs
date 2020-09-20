import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Component, Inject } from '@angular/core';
import { Club } from 'src/app/Models/Clubs/club';

@Component({
    selector: 'app-edit-add',
    templateUrl: './club-edit.component.html',
    styleUrls: ['./club-edit.component.scss'],
})
export class ClubEditComponent {
    constructor(
        public dialogRef: MatDialogRef<ClubEditComponent>,
        @Inject(MAT_DIALOG_DATA) public data: Club
    ) {}
}
