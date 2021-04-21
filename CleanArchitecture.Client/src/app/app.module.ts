import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AsyncpipeComponent } from './rxjs/asyncpipe/asyncpipe.component';
import { OperatorsComponent } from './rxjs/operators/operators.component';
import { ChangedetectionComponent } from './rxjs/changedetection/changedetection.component';
import { PushComponent } from './rxjs/changedetection/push/push.component';
import { DefaultComponent } from './rxjs/changedetection/default/default.component';
import { PushobservableComponent } from './rxjs/changedetection/pushobservable/pushobservable.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CombinelatestComponent } from './rxjs/operators/combinelatest/combinelatest.component';
import { ShareComponent } from './rxjs/operators/share/share.component';
import { ScanComponent } from './rxjs/operators/scan/scan.component';

@NgModule({
  declarations: [
    AppComponent,
    AsyncpipeComponent,
    OperatorsComponent,
    ChangedetectionComponent,
    PushComponent,
    DefaultComponent,
    PushobservableComponent,
    CombinelatestComponent,
    ShareComponent,
    ScanComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
