import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SigninComponent } from './Core/signin/signin.component';
import { DefaultCompComponent } from './Components/default-comp/default-comp.component';
import { AuthGuard } from './Services/Guards/authguard';
import { SecureInnerPagesGuard } from './Services/Guards/secureinnerpagesguard';

const routes: Routes = [
    {
        path: 'sign-in',
        component: SigninComponent,
        canActivate: [SecureInnerPagesGuard],
    },
    {
        path: 'default',
        component: DefaultCompComponent,
        canActivate: [AuthGuard],
    },
    {
        path: 'clubs',
        loadChildren: './Components/Clubs/clubs.module#ClubsModule',
    },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
})
export class AppRoutingModule {}
