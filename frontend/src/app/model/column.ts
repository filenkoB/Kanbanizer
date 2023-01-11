export class Column {
    public id? : string;
    public name? : string;
    public maxTasks? : number;
    public order? : number;

    constructor(id : string, name : string, maxTasks : number, order : number) {
        this.id = id;
        this.name = name;
        this.maxTasks = maxTasks;
        this.order = order;
    }
}