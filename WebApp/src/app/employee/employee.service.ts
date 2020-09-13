import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Skill } from './model/skill.model';
import { Gender } from './model/gender.model';

const BASE_API_URL = '/api/employee';

@Injectable({
	providedIn: 'root'
})
export class EmployeeService {

	constructor(private http: HttpClient) { }

	public getSkillList(): Observable<Skill[]> {
		return this.http.get<Skill[]>(`${BASE_API_URL}/skill-list`);
	}

	public getGenderList(): Observable<Gender[]> {
		return this.http.get<Gender[]>(`${BASE_API_URL}/gender-list`);
	} 

}
