import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppMaterialModule } from '../app-material.module'
import { HttpClientModule } from '@angular/common/http';

import { FlexLayoutModule } from '@angular/flex-layout';
import { RegisterEmployeeComponent } from './register-employee/register-employee.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ListEmployeesComponent } from './list-employees/list-employees.component';
import { UtilModule } from '../util/util.module';
import { FilterByPipe } from './list-employees/filter-by.pipe';

@NgModule({
  declarations: [RegisterEmployeeComponent, ListEmployeesComponent, FilterByPipe],
  imports: [
    CommonModule,    
    HttpClientModule,
    ReactiveFormsModule,
    AppMaterialModule,
    FlexLayoutModule,    
    UtilModule
  ]
})
export class EmployeeModule { }
