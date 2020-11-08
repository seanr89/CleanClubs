import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';

import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from 'src/app/Services/Guards/authguard';
import { LocationsListComponent } from './locations-list/locations-list.component';

const routes: Routes = [
    {
        path: 'list',
        component: LocationsListComponent,
        canActivate: [AuthGuard],
    },
];

@NgModule({
    declarations: [],
    imports: [CommonModule, RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class LocationsRoutingModule {}
