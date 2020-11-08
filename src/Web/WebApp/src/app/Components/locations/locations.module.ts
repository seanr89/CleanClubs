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
import { LocationsListComponent } from './locations-list/locations-list.component';
import { LocationsRoutingModule } from './locations-routing.module';
import { MatInputModule } from '@angular/material/input';
import { SharedModule } from 'src/app/shared/shared.module';
import { LocationDetailsComponent } from './location-details/location-details.component';

@NgModule({
    declarations: [
    LocationsListComponent,
    LocationDetailsComponent],
    imports: [
        CommonModule,
        LocationsRoutingModule,
        MatTableModule,
        MatDialogModule,
        MatPaginatorModule,
        MatIconModule,
        MatButtonModule,
        MatSlideToggleModule,
        MatCheckboxModule,
        MatInputModule,
        MatFormFieldModule,
        SharedModule,
    ],
    exports: [],
    entryComponents: [, ],
})
export class LocationsModule {}
