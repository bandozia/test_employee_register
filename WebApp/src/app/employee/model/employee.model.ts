import { Skill } from './skill.model';
import { Gender } from './gender.model';

export interface Employee {
    firstName: string;
    lastName: string;
    birthDate: Date;
    gender: Gender;
    skills: Skill[];
    email: string;    
}