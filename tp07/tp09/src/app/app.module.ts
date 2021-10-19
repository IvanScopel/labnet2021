import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { NgModule, Component } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ShippersComponent } from './shippers/shippers.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ShipperFormComponent } from './shipper-form/shipper-form.component';

@NgModule({
  declarations: [
    AppComponent,
    ShippersComponent,
    ShipperFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path : '', component: ShippersComponent},
      { path : 'formulario', component: ShipperFormComponent}
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]


})
export class AppModule { }
