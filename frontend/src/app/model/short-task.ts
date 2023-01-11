export class ShortTask {
    public id? : string;
    public title? : string;
    public status? : string;
    public columnId? : string;
    public ownerId? : string;

    constructor(id : string, title : string, status : string, columnId : string, ownerId : string) {
        this.id = id;
        this.title = title;
        this.status = status;
        this.columnId = columnId;
        this.ownerId = ownerId;
    }
}