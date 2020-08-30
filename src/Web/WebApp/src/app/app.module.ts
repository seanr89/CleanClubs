import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavmenuComponent } from './Components/navmenu/navmenu.component';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { DefaultCompComponent } from './Components/default-comp/default-comp.component';
import { PageLinkComponent } from './Core/page-link/page-link.component';
import { SigninComponent } from './Core/signin/signin.component';
import { AngularFireAuthModule } from '@angular/fire/auth';
import { AngularFireModule } from '@angular/fire';
import { environment } from './../environments/environment';
import { AuthGuard } from './Services/Guards/authguard';
import { SecureInnerPagesGuard } from './Services/Guards/secureinnerpagesguard';
import { ClubListComponent } from './Components/Clubs/club-list/club-list.component';

@NgModule({
    declarations: [
        AppComponent,
        NavmenuComponent,
        DefaultCompComponent,
        PageLinkComponent,
        SigninComponent,
        ClubListComponent,
    ],
    imports: [
        AngularFireModule.initializeApp(environment.firebaseConfig),
        BrowserModule,
        AppRoutingModule,
        BrowserAnimationsModule,
        LayoutModule,
        MatToolbarModule,
        MatButtonModule,
        MatSidenavModule,
        MatIconModule,
        MatListModule,
        AngularFireModule,
        AngularFireAuthModule,
    ],
    providers: [AuthGuard, SecureInnerPagesGuard],
    bootstrap: [AppComponent],
})
export class AppModule {}
