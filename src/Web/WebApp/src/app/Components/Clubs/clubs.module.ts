import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClubListComponent } from './club-list/club-list.component';
import { ClubsRoutingModule } from './clubs-routing.module';

@NgModule({
    declarations: [ClubListComponent],
    imports: [CommonModule, ClubsRoutingModule],
})
export class ClubsModule {}
