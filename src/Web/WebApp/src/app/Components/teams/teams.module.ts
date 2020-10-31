import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatIcon, MatIconModule } from '@angular/material/icon';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FlexLayoutModule } from '@angular/flex-layout';
import { TeamsPlayerlistComponent } from './teams-playerlist/teams-playerlist.component';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatStepperModule } from '@angular/material/stepper';
import { MatListModule } from '@angular/material/list';

@NgModule({
    declarations: [
        TeamsPlayerlistComponent],
    imports: [
        CommonModule,
        MatTableModule,
        MatListModule,
        MatStepperModule,
        MatSnackBarModule,
        MatDatepickerModule,

    ],
    exports: [TeamsPlayerlistComponent],
    entryComponents: [],
})
export class TeamsModule {}
