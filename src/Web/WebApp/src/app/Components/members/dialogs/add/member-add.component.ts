import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Component, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
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
        @Inject(MAT_DIALOG_DATA) public data: any
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
