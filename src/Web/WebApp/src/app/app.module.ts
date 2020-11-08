import { BrowserModule } from '@angular/platform-browser';
import { ErrorHandler, NgModule } from '@angular/core';
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
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ClubsModule } from './Components/clubs/clubs.module';
import { HomeComponent } from './Components/home/home.component';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatDialogModule } from '@angular/material/dialog';
import { FlexLayoutModule } from '@angular/flex-layout';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatchesModule } from './Components/matches/matches.module';
import { MatStepperModule} from '@angular/material/stepper';
import { MatInputModule } from '@angular/material/input';
import { NgxMaterialTimepickerModule } from 'ngx-material-timepicker';
import { MatCardModule } from '@angular/material/card';
import { httpInterceptorProviders } from './Services/Interceptors/Index';
import { GlobalErrorHandler } from './Services/globalerrorhandler';
import { LocationsModule } from './Components/locations/locations.module';
import {MatMenuModule} from '@angular/material/menu';


@NgModule({
    declarations: [
        AppComponent,
        NavmenuComponent,
        PageLinkComponent,
        SigninComponent,
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
        AngularFireModule,
        AngularFireAuthModule,
        HttpClientModule,
        ClubsModule,
        LocationsModule,
        MatchesModule,
        FlexLayoutModule,
        DragDropModule,
        MatFormFieldModule,
        FormsModule,
        ReactiveFormsModule,
        MatStepperModule,
        MatInputModule,
        MatCardModule,
        MatMenuModule,
    ],
    providers: [AuthGuard, SecureInnerPagesGuard, { 
        // processes all errors
        provide: ErrorHandler, 
        useClass: GlobalErrorHandler 
      },
      httpInterceptorProviders,
    ],
    bootstrap: [AppComponent],
    exports: [],
    entryComponents: []
})
export class AppModule {}
