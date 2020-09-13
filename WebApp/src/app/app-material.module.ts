import { NgModule } from '@angular/core';

import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSelectModule } from '@angular/material/select';
import { MatListModule } from '@angular/material/list';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatRadioModule } from '@angular/material/radio';
import {MatCheckboxModule} from '@angular/material/checkbox';

@NgModule({
    imports: [
        MatFormFieldModule,
        MatInputModule,
        MatButtonModule,
        MatProgressSpinnerModule,
        MatSelectModule,
        MatListModule,
        MatDatepickerModule,
        MatNativeDateModule,
        MatRadioModule,
        MatCheckboxModule
    ],
    exports: [
        MatFormFieldModule,
        MatInputModule,
        MatButtonModule,
        MatProgressSpinnerModule,
        MatSelectModule,
        MatListModule,
        MatDatepickerModule,        
        MatRadioModule,
        MatCheckboxModule
    ]
})
export class AppMaterialModule { }