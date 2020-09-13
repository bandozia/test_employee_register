import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { EmployeeService } from '../employee.service';
import { Gender } from '../model/gender.model';
import { Skill } from '../model/skill.model';

@Component({
	selector: 'app-register-employee',
	templateUrl: './register-employee.component.html',
	styleUrls: ['./register-employee.component.css']
})
export class RegisterEmployeeComponent implements OnInit {

	skills: Skill[] = [];
	genders: Gender[] = [];

	formGroup: FormGroup;

	constructor(
		private activatedRoute: ActivatedRoute, 
		private employeeService: EmployeeService,
		private formBuilder: FormBuilder) { }

	ngOnInit(): void {
		this.skills = this.activatedRoute.snapshot.data.skills;
		this.genders = this.activatedRoute.snapshot.data.genders;

		this.formGroup = this.formBuilder.group({
			firstName: ['', Validators.required],
			lastName: ['', Validators.required],
			birthDate: [null, Validators.required],
			email: ['', Validators.email]
		});
	}

}
