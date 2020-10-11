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
import { MatCardModule } from '@angular/material/card';
import { MatchListComponent } from './match-list/match-list.component';
import { MatchTeamCreateComponent } from './match-team-create/match-team-create.component';
import { MatchesRoutingModule } from './matches-routing.module';
import { MembersModule } from '../members/members.module';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { MatNativeDateModule } from '@angular/material/core';
import { MatInputModule } from '@angular/material/input';
import { MatStepperModule } from '@angular/material/stepper';
import { NgxMaterialTimepickerModule } from 'ngx-material-timepicker';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatDatepickerModule } from '@angular/material/datepicker';

@NgModule({
    declarations: [
        MatchListComponent,
        MatchTeamCreateComponent,
    ],
    imports: [
        CommonModule,
        MatTableModule,
        MatDialogModule,
        MatPaginatorModule,
        MatIconModule,
        MatButtonModule,
        MatSlideToggleModule,
        MatCheckboxModule,
        FormsModule,
        MatFormFieldModule,
        ReactiveFormsModule,
        FlexLayoutModule,
        MatCardModule,
        MatchesRoutingModule,
        MembersModule,
        FlexLayoutModule,
        MatCardModule,
        DragDropModule,
        MatFormFieldModule,
        FormsModule,
        ReactiveFormsModule,
        MatNativeDateModule,
        MatStepperModule,
        MatInputModule,
        MatSnackBarModule,
        MatDatepickerModule,
        NgxMaterialTimepickerModule.setLocale('en-GB'),
    ],
    exports: [MatchListComponent, MatchTeamCreateComponent],
    entryComponents: [],
})
export class MatchesModule {}
