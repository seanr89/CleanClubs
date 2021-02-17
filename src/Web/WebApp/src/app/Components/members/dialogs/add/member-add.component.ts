import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Component, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Member } from 'src/app/Models/interfaces/members/member';
@Component({
    selector: 'app-member-add',
    templateUrl: './member-add.component.html',
    styleUrls: ['./member-add.component.scss'],
})
export class MemberAddComponent {
    //FormGroup for validation of the create clinic form.
    form: FormGroup;

    constructor(
        public dialogRef: MatDialogRef<MemberAddComponent>,
        @Inject(MAT_DIALOG_DATA) public data: Member
    ) {}

    ngOnInit(): void {
        //Add validation to make sure fields have been added correctly
        this.form = new FormGroup({
            firstname: new FormControl(this.data.firstName, [
                Validators.required,
            ]),
            lastname: new FormControl(this.data.lastName, [
                Validators.required,
            ]),
            email: new FormControl(this.data.email, [Validators.required]),
        });
    }

    get firstname() {
        return this.form.get('firstname');
    }
    get lastname() {
        return this.form.get('lastname');
    }
    get email() {
        return this.form.get('email');
    }

    onClose(): void {
        //TODO: update text
        this.dialogRef.close(this.data);
    }
}
