import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeeService } from '../employee.service';
import { Gender } from '../model/gender.model';
import { Skill } from '../model/skill.model';
import { Employee } from '../model/employee.model';
import { legalAgeValidator } from '../../shared/validators/date.validators';

@Component({
	selector: 'app-register-employee',
	templateUrl: './register-employee.component.html',
	styleUrls: ['./register-employee.component.css']
})
export class RegisterEmployeeComponent implements OnInit {
	
	employee: Employee;

	skills: Skill[] = [];
	genders: Gender[] = [];

	formGroup: FormGroup;
	selectedGender: Gender;

	skillsInvalid = false;
	genderInvalid = false;
	isWorking = false;
		
	constructor(
		private activatedRoute: ActivatedRoute, 
		private employeeService: EmployeeService,
		private formBuilder: FormBuilder,
		private router: Router) { }

	ngOnInit(): void {
		
		this.employee = this.activatedRoute.snapshot.data.employee;
		
		this.skills = this.activatedRoute.snapshot.data.skills;
		this.genders = this.activatedRoute.snapshot.data.genders;
		
		if (this.employee) {
			this.selectedGender = this.employee.gender;
			this.skills.forEach(s => {				
				s.selected = this.employee.skills.find(es => es.id == s.id) != null;
			});			
		}

		this.formGroup = this.formBuilder.group({
			firstName: [this.employee?.firstName, Validators.required],
			lastName: [this.employee?.lastName, Validators.required],	
			birthDate: [this.employee?.birthDate ? new Date(this.employee.birthDate) : null, [Validators.required, legalAgeValidator]],
			email: [this.employee?.email, Validators.email]			
		});
	}

	register(): void {		
		let employeeSkills = this.skills.filter(s => s.selected);
		this.genderInvalid = this.selectedGender == null;
		this.skillsInvalid = employeeSkills.length < 1;
		
		if (!this.genderInvalid && !this.skillsInvalid)	{
			let newEmployee = this.formGroup.getRawValue() as Employee;
			newEmployee.skills = employeeSkills;
			newEmployee.gender = this.selectedGender;
			
			this.isWorking = true;
			this.employeeService.createEmployee(newEmployee).subscribe(res => {
				this.router.navigate(['']);
			}, err => {
				alert("erro ao cadastrar")
				this.isWorking = false;
			})
		}
	}

}
