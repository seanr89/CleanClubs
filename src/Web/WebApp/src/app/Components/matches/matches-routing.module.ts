import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from 'src/app/Services/Guards/authguard';
import { MatchTeamCreateComponent } from './match-team-create/match-team-create.component';

const routes: Routes = [
    {
        path: 'creatematch/:id',
        component: MatchTeamCreateComponent
    },
];

@NgModule({
    declarations: [],
    imports: [CommonModule, RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class MatchesRoutingModule {}
