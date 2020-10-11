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
import { MatTableModule } from '@angular/material/table';
import { PageLinkComponent } from './Core/page-link/page-link.component';
import { SigninComponent } from './Core/signin/signin.component';
import { AngularFireAuthModule } from '@angular/fire/auth';
import { AngularFireModule } from '@angular/fire';
import { environment } from './../environments/environment';
import { AuthGuard } from './Services/Guards/authguard';
import { SecureInnerPagesGuard } from './Services/Guards/secureinnerpagesguard';
import { LoadingComponent } from './Core/loading/loading.component';
import { HttpClientModule } from '@angular/common/http';
import { ClubsModule } from './Components/clubs/clubs.module';
import { HomeComponent } from './Components/home/home.component';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatDialogModule } from '@angular/material/dialog';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MatCardModule } from '@angular/material/card';
import { MatchListComponent } from './Components/matches/match-list/match-list.component';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatchesModule } from './Components/matches/matches.module';
import {MatStepperModule} from '@angular/material/stepper';
import { MatInputModule } from '@angular/material/input';
import { NgxMaterialTimepickerModule } from 'ngx-material-timepicker';


@NgModule({
    declarations: [
        AppComponent,
        NavmenuComponent,
        PageLinkComponent,
        SigninComponent,
        LoadingComponent,
        HomeComponent,
    ],
    imports: [
        AngularFireModule.initializeApp(environment.firebaseConfig),
        NgxMaterialTimepickerModule.setLocale('en-GB'),
        BrowserModule,
        AppRoutingModule,
        BrowserAnimationsModule,
        LayoutModule,
        MatToolbarModule,
        MatButtonModule,
        MatSidenavModule,
        MatIconModule,
        MatListModule,
        MatTableModule,
        MatDialogModule,
        MatSnackBarModule,
        MatDatepickerModule,
        AngularFireModule,
        AngularFireAuthModule,
        HttpClientModule,
        ClubsModule,
        MatchesModule,
        FlexLayoutModule,
        MatCardModule,
        DragDropModule,
        MatFormFieldModule,
        FormsModule,
        ReactiveFormsModule,
        MatNativeDateModule,
        MatStepperModule,
        MatInputModule,

    ],
    providers: [AuthGuard, SecureInnerPagesGuard],
    bootstrap: [AppComponent],
    exports: [LoadingComponent],
    entryComponents: []
})
export class AppModule {}
