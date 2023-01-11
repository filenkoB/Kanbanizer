export class Credential {
    public login : string;
    public passwordHash : string;

    constructor(login : string, passwordHash : string) {
        this.login = login;
        this.passwordHash = passwordHash;
    }
}