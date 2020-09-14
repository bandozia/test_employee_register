import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, ObservedValueOf } from 'rxjs';

import { Skill } from './model/skill.model';
import { Gender } from './model/gender.model';
import { Employee } from './model/employee.model';

const BASE_API_URL = '/api/employee';

@Injectable({
	providedIn: 'root'
})
export class EmployeeService {

	constructor(private http: HttpClient) { }

	public getEmployees(): Observable<Employee[]> {
		return this.http.get<Employee[]>(`${BASE_API_URL}`);
	}

	public getEmployeeById(id: number): Observable<Employee> {
		return this.http.get<Employee>(`${BASE_API_URL}/${id}`);
	}

	public getSkillList(): Observable<Skill[]> {
		return this.http.get<Skill[]>(`${BASE_API_URL}/skill-list`);
	}

	public getGenderList(): Observable<Gender[]> {
		return this.http.get<Gender[]>(`${BASE_API_URL}/gender-list`);
	} 

	public createEmployee(employee: Employee) {
		return this.http.post(`${BASE_API_URL}`, employee);
	}

}
