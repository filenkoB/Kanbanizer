import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainComponent } from './main/main.component';

const routes: Routes = [{ 
  path: "", component: MainComponent, children: [
    { path: "board/:id", loadChildren: () => import("../board/board.module").then(module => module.BoardModule), pathMatch: "full" }
  ]
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class MainRoutingModule { }
