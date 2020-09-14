import { Pipe, PipeTransform } from '@angular/core';
import { Employee } from '../model/employee.model';
import { birthToAge } from '../../util/date-ops.util';
import { Skill } from '../model/skill.model';
import { Gender } from '../model/gender.model';

@Pipe({
	name: 'filterBy'
})
export class FilterByPipe implements PipeTransform {

	transform(employees: Employee[], name: string, age: number = 0, skills: Skill[] = null, gender: Gender = null): Employee[] {		
		name = name.trim().toLowerCase();		
		if (name) {
			employees = employees.filter(e => e.firstName.toLowerCase().includes(name) || e.lastName.toLowerCase().includes(name));			
		}

		if (age > 0) {
			employees = employees.filter(e => birthToAge(e.birthDate) >= age);
		}

		if (gender) {
			employees = employees.filter(e => e.gender.id == gender.id);
		}
			
		
		if (skills?.length > 0) {
			employees = employees.filter(e => {
				let hasSkill = false;
				skills.forEach(s => {
					hasSkill = e.skills.filter(es => es.id == s.id).length > 0;
				})
				return hasSkill;				
			});
		}

	

		return employees;
	}

}
