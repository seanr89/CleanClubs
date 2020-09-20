import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Component, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CreateClubModel } from 'src/app/Models/Clubs/createclubmodel';

@Component({
    selector: 'app-club-add',
    templateUrl: './club-add.component.html',
    styleUrls: ['./club-add.component.scss'],
})
export class ClubAddComponent {
    //FormGroup for validation of the create clinic form.
    form: FormGroup;
    //validationHandler: ValidationHandler;

    constructor(
        public dialogRef: MatDialogRef<ClubAddComponent>,
        @Inject(MAT_DIALOG_DATA) public data: CreateClubModel
    ) {}

    ngOnInit(): void {
        //Add validation to make sure fields have been added correctly
        this.form = new FormGroup({
            name: new FormControl('', [Validators.required]),
            glossary: new FormControl(''),
            description: new FormControl(''),
            outOfRangeDescription: new FormControl(''),
        });
        //this.validationHandler = new ValidationHandler(this.form);
    }

    get name() {
        return this.form.get('name');
    }

    //Updated the slider when changed
    onChange(event) {
        this.data.active = event.checked;
    }
    onPrivateChange(event) {
        this.data.private = event.checked;
    }
}
