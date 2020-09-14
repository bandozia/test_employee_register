import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { EmployeeService } from './employee.service';
import { Employee } from './model/employee.model';

@Injectable({
	providedIn: 'root'
})
export class SingleEmployeeResolver implements Resolve<Observable<Employee>> {

	constructor(private employeeService: EmployeeService) { }
	
	resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<Employee> {		        		
		return this.employeeService.getEmployeeById(route.params.id);
	}
}
