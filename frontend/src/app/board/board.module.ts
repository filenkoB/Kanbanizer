import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { BoardRoutingModule } from "./board-routing.module";
import { BoardComponent } from "./board/board.component";
import { ColumnComponent } from "./column/column.component";

@NgModule({
    declarations: [
        BoardComponent,
        ColumnComponent
    ],
    imports: [
        CommonModule,
        BoardRoutingModule
    ]
})
export class BoardModule {

}