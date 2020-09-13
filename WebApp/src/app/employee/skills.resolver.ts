import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { Skill } from './model/skill.model';
import { EmployeeService } from './employee.service';

@Injectable({
	providedIn: 'root'
})
export class SkillsResolver implements Resolve<Observable<Skill[]>> {

	constructor(private employeeService: EmployeeService) { }
	
	resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<Skill[]> {
		return this.employeeService.getSkillList();
	}
}
