export class Board {
    public id : string;
    public name : string;
    public description : string;
    public ownerId : string;

    constructor(id : string, name : string, description : string, ownerId : string) {
        this.id = id;
        this.name = name;
        this.description = description;
        this.ownerId = ownerId;
    }
}