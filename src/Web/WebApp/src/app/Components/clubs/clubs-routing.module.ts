import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';

import { RouterModule, Routes } from '@angular/router';
import { ClubListComponent } from './club-list/club-list.component';
import { AuthGuard } from 'src/app/Services/Guards/authguard';
import { ClubDetailsComponent } from './club-details/club-details.component';

const routes: Routes = [
    {
        path: 'list',
        component: ClubListComponent,
        canActivate: [AuthGuard],
    },
    {
        path: 'details/:id',
        component: ClubDetailsComponent,
        canActivate: [AuthGuard],
    },
];

@NgModule({
    declarations: [],
    imports: [CommonModule, RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class ClubsRoutingModule {}
