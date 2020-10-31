import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from 'src/app/Services/Guards/authguard';
import { MatchTeamCreateComponent } from './match-team-create/match-team-create.component';
import { MatchDetailsComponent } from './match-details/match-details.component';

const routes: Routes = [
    {
        path: 'creatematch/:id',
        component: MatchTeamCreateComponent
    },
    {
        path: 'details/:id',
        component: MatchDetailsComponent,
        canActivate: [AuthGuard],
    },
];

@NgModule({
    declarations: [],
    imports: [CommonModule, RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class MatchesRoutingModule {}
