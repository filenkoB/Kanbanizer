import { environment } from "src/environments/environment";

export abstract class BaseService {
    protected readonly url : string;

    constructor() {
        this.url = environment.backendUrl;
    }
}