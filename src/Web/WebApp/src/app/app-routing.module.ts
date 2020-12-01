import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SigninComponent } from './Core/signin/signin.component';
import { AuthGuard } from './Services/Guards/authguard';
import { SecureInnerPagesGuard } from './Services/Guards/secureinnerpagesguard';
import { HomeComponent } from './Components/home/home.component';
import { MatchTeamCreateComponent } from './Components/matches/match-team-create/match-team-create.component';

const routes: Routes = [
    {
        path: 'sign-in',
        component: SigninComponent,
        canActivate: [SecureInnerPagesGuard],
    },
    {
        path: 'clubs',
        loadChildren: './Components/clubs/clubs.module#ClubsModule',
    },
    {
        path: 'matches',
        loadChildren: './Components/matches/matches.module#MatchesModule',
    },
    {
        path: 'members',
        loadChildren: './Components/members/members.module#MembersModule',
    },
    {
        path: 'locations',
        loadChildren: './Components/locations/locations.module#LocationsModule',
    },
    {
      path: 'users',
      loadChildren: './Components/users/users.module#UsersModule',
  },
    { path: 'home', component: HomeComponent },
    { path: "**", redirectTo: "home" }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
})
export class AppRoutingModule {}
