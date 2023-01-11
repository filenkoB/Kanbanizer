import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { Board } from "src/app/model/board";
import { Column } from "src/app/model/column";
import { HttpClientService } from "src/app/services/httpClient.service";

@Component({
    selector: "app-board",
    templateUrl: "./board.component.html",
    styleUrls: [ "./board.component.scss" ]
})
export class BoardComponent {
    private _boardId : string;
    public columns : Column[] = [];
    public board? : Board;

    constructor(private readonly router : Router, private readonly http : HttpClientService) {
        var path = this.router.url.split('/');
        this._boardId = path[path.length - 1];
        this._loadBoardInfo();
        this._loadColumns();
    }

    private async _loadBoardInfo() : Promise<void> {
        this.board = await this.http.get<Board>(`./Board/${this._boardId}`).toPromise();
    }

    private async _loadColumns() : Promise<void> {
        let columns = await this.http.getAll<Column>(`./Column/${this._boardId}`).toPromise();
        this.columns = columns || [];
    }
}