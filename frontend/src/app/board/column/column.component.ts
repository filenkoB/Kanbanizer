import { Component, Input } from "@angular/core";
import { Column } from "src/app/model/column";
import { ShortTask } from "src/app/model/short-task";
import { HttpClientService } from "src/app/services/httpClient.service";

@Component({
    selector: "app-column",
    templateUrl: "./column.component.html",
    styleUrls: ["./column.component.scss"]
})
export class ColumnComponent {
    @Input() public column? : Column;

    public tasks : ShortTask[] = [];

    constructor(private readonly http : HttpClientService) {
        this._loadTasks();
    }

    private async _loadTasks() : Promise<void> {
        let tasks = await this.http.getAll<ShortTask>("./Tasks/" + this.column?.id).toPromise();
        this.tasks = tasks || [];
    }
}