import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppMaterialModule } from '../app-material.module'
import { HttpClientModule } from '@angular/common/http';

import { FlexLayoutModule } from '@angular/flex-layout';
import { RegisterEmployeeComponent } from './register-employee/register-employee.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ListEmployeesComponent } from './list-employees/list-employees.component';

@NgModule({
  declarations: [RegisterEmployeeComponent, ListEmployeesComponent],
  imports: [
    CommonModule,    
    HttpClientModule,
    ReactiveFormsModule,
    AppMaterialModule,
    FlexLayoutModule
  ]
})
export class EmployeeModule { }
