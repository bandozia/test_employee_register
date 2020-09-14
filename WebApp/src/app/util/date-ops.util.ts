
export function birthToAge(birthDate: Date): number {
    let birth = new Date(birthDate);
    let diff = new Date().getTime() - birth.getTime()
    return Math.floor(diff / (1000 * 3600 * 365 * 24));
}