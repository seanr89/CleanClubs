import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { LoadingComponent } from './loading/loading.component';

@NgModule({
    declarations: [
        LoadingComponent
    ],
    imports: [
        CommonModule,
        MatCardModule
    ],
    exports: [LoadingComponent],
    entryComponents: [],
})
export class SharedModule {}
