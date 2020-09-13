import { AbstractControl } from '@angular/forms';

export function legalAgeValidator(control: AbstractControl) {
    let birth = control.value as Date;
    if (birth != null) {
        let diff = new Date().getTime() - birth.getTime()
        if ( (diff /  (1000 * 3600 * 365 * 24)) < 18) {
            return { legalage: true };
        }
    }

    return null;
}
