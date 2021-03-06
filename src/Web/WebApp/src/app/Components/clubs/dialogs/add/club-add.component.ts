import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Component, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CreateClubModel } from 'src/app/Models/interfaces/clubs/createclubmodel';
import { Club } from 'src/app/Models/interfaces/clubs/club';

@Component({
    selector: 'app-club-add',
    templateUrl: './club-add.component.html',
    styleUrls: ['./club-add.component.scss'],
})
export class ClubAddComponent {
    //FormGroup for validation of the create clinic form.
    form: FormGroup;

    constructor(
        public dialogRef: MatDialogRef<ClubAddComponent>,
        @Inject(MAT_DIALOG_DATA) public data: CreateClubModel
    ) {}

    ngOnInit(): void {
        //Add validation to make sure fields have been added correctly
        this.form = new FormGroup({
            name: new FormControl(this.data.name, [Validators.required]),
        });
    }

    get name() {
        return this.form.get('name');
    }
    get creatorName() {
        return this.form.get('creatorName');
    }

    //Updated the slider when changed
    // onChange(event) {
    //     this.data.active = event.checked;
    // }
    onPrivateChange(event) {
        this.data.private = event.checked;
    }

    onClose(): void {
        this.data.name = this.form.value.name;
        //this.data.creator = this.form.value.creatorName;
        this.dialogRef.close(this.data);
    }
}
