import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatIcon, MatIconModule } from '@angular/material/icon';
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
import { MatNativeDateModule, MatOptionModule } from '@angular/material/core';
import { MatInputModule } from '@angular/material/input';
import { MatStepperModule } from '@angular/material/stepper';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatchDetailsComponent } from './match-details/match-details.component';
import { TeamsModule } from '../teams/teams.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { MatchEditDialogComponent } from './match-edit-dialog/match-edit-dialog.component';
import { MatSelectModule } from '@angular/material/select';
import { MatRadioModule } from '@angular/material/radio';
import { MatchScheduleComponent } from './match-schedule/match-schedule.component';
import { MatCheckboxModule } from '@angular/material/checkbox';

@NgModule({
    declarations: [
        MatchListComponent,
        MatchTeamCreateComponent,
        MatchDetailsComponent,
        MatchEditDialogComponent,
        MatchScheduleComponent,
    ],
    imports: [
        CommonModule,
        MatTableModule,
        MatDialogModule,
        MatPaginatorModule,
        MatIconModule,
        MatButtonModule,
        MatSlideToggleModule,
        FormsModule,
        MatFormFieldModule,
        ReactiveFormsModule,
        FlexLayoutModule,
        MatCardModule,
        MatCheckboxModule,
        MatchesRoutingModule,
        FlexLayoutModule,
        MatCardModule,
        DragDropModule,
        MatFormFieldModule,
        ReactiveFormsModule,
        MatNativeDateModule,
        MatStepperModule,
        MatInputModule,
        MatSelectModule,
        MatOptionModule,
        MatSnackBarModule,
        MatRadioModule,
        MatDatepickerModule,
        MembersModule,
        TeamsModule,
        SharedModule,
    ],
    exports: [MatchListComponent, MatchTeamCreateComponent],
    entryComponents: [MatchEditDialogComponent],
})
export class MatchesModule {}
