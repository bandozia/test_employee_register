import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { RegisterEmployeeComponent } from './employee/register-employee/register-employee.component';
import { SkillsResolver } from './employee/skills.resolver';
import { GenderResolver } from './employee/gender.resolver';
import { ListEmployeesComponent } from './employee/list-employees/list-employees.component';

const routes: Routes = [
  {
    path: '', component: ListEmployeesComponent,
    resolve: {
      skills: SkillsResolver,
      genders: GenderResolver
    }
  },
  {
    path: 'registrar', component: RegisterEmployeeComponent,
    resolve: {
      skills: SkillsResolver,
      genders: GenderResolver
    }    
  }  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
