import { Pipe, PipeTransform } from '@angular/core';
import { birthToAge } from '../util/date-ops.util';

@Pipe({
	name: 'toAge'
})
export class ToAgePipe implements PipeTransform {

	transform(birthDate: Date): string {		
		let birth = new Date(birthDate);
		return birthToAge(birth).toString();
	}

}
