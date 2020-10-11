import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { MemberListComponent } from './member-list/member-list.component';
import { AuthGuard } from 'src/app/Services/Guards/authguard';

const routes: Routes = [
  {
    path: 'members/:id',
    component: MemberListComponent,
    canActivate: [AuthGuard],
},
];

@NgModule({
    declarations: [],
    imports: [CommonModule, RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class MembersRoutingModule {}
