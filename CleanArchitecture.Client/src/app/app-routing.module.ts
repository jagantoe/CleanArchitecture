import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AsyncpipeComponent } from './rxjs/asyncpipe/asyncpipe.component';
import { ChangedetectionComponent } from './rxjs/changedetection/changedetection.component';
import { OperatorsComponent } from './rxjs/operators/operators.component';

const routes: Routes = [
  {
    path: "asyncpipe",
    component: AsyncpipeComponent
  },
  {
    path: "changedetection",
    component: ChangedetectionComponent
  },
  {
    path: "operators",
    component: OperatorsComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
