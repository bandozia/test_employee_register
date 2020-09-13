import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { Gender } from './model/gender.model';
import { EmployeeService } from './employee.service';

@Injectable({
	providedIn: 'root'
})
export class GenderResolver implements Resolve<Observable<Gender[]>> {

	constructor(private employeeService: EmployeeService) { }
	
	resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<Gender[]> {				
		return this.employeeService.getGenderList();
	}
}
