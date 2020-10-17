import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoadingComponent } from './loading/loading.component';
import { MatCardModule } from '@angular/material/card';

@NgModule({
    declarations: [
      LoadingComponent,
    ],
    imports: [
        CommonModule,
        MatCardModule
    ],
    exports: [LoadingComponent],
    entryComponents: [],
})
export class CoreModule {}
