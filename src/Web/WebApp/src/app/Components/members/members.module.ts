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
import { MemberListComponent } from './member-list/member-list.component';
import { MembersRoutingModule } from './members-routing.module';
import { CoreModule } from 'src/app/Core/core.module';

@NgModule({
    declarations: [
      MemberListComponent],
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
        MembersRoutingModule,
        CoreModule
    ],
    exports: [MemberListComponent],
    entryComponents: [],
})
export class MembersModule {}
