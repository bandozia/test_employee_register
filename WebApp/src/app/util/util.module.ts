import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ToAgePipe } from './to-age.pipe';



@NgModule({
  declarations: [ToAgePipe],
  imports: [
    CommonModule
  ],
  exports: [
    ToAgePipe
  ]
})
export class UtilModule { }
