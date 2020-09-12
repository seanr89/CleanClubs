import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClubListComponent } from './club-list/club-list.component';
import { ClubsRoutingModule } from './clubs-routing.module';
import { MatTableModule } from '@angular/material/table';

@NgModule({
    declarations: [ClubListComponent],
    imports: [CommonModule, MatTableModule, ClubsRoutingModule],
    exports: [ClubListComponent],
})
export class ClubsModule {}
