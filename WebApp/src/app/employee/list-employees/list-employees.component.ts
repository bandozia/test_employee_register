import { Component, OnDestroy, OnInit } from '@angular/core';
import { from, Observable, Subject } from 'rxjs';
import { EmployeeService } from '../employee.service';
import { Employee } from '../model/employee.model';
import { debounceTime } from 'rxjs/operators';
import { Skill } from '../model/skill.model';
import { Gender } from '../model/gender.model';
import { ActivatedRoute } from '@angular/router';
import { MatCheckboxChange } from '@angular/material/checkbox';

@Component({
	selector: 'app-list-employees',
	templateUrl: './list-employees.component.html',
	styleUrls: ['./list-employees.component.css']
})
export class ListEmployeesComponent implements OnInit, OnDestroy {

	constructor(private employeeService: EmployeeService, private activatedRoute: ActivatedRoute) { }

	skills: Skill[] = [];
	genders: Gender[] = [];
	
	employees$: Observable<Employee[]>;
	debounceName: Subject<string> = new Subject<string>();
	debounceAge: Subject<number> = new Subject<number>();
	
	searchName: string = '';
	filterAge: number = 0;
	skillsFilter: Skill[];	
	genderFilter: Gender;

	ngOnInit(): void {
		this.skills = this.activatedRoute.snapshot.data.skills;
		this.genders = this.activatedRoute.snapshot.data.genders;

		this.employees$ = this.employeeService.getEmployees();

		this.debounceName.pipe(debounceTime(300)).subscribe(filter => this.searchName = filter);
		this.debounceAge.pipe(debounceTime(300)).subscribe(filter => this.filterAge = filter);

		
	}

	filterSkills(): void {		
		this.skillsFilter = this.skills.filter(s => s.selected);
	}
	

	ngOnDestroy(): void {
		this.debounceName.unsubscribe();
		this.debounceAge.unsubscribe();
	}

}
