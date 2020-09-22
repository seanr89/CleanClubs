import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SigninComponent } from './Core/signin/signin.component';
import { AuthGuard } from './Services/Guards/authguard';
import { SecureInnerPagesGuard } from './Services/Guards/secureinnerpagesguard';
import { HomeComponent } from './Components/home/home.component';

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
    { path: 'home', component: HomeComponent },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
})
export class AppRoutingModule {}
