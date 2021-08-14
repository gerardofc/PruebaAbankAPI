import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {ReactiveFormsModule} from '@angular/forms';
import {HttpClientModule} from '@angular/common/http'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SkuComponent } from './components/sku/sku.component';
import { FooterComponent } from './components/footer/footer.component';
import { AgregarSkuComponent } from './components/sku/agregar-sku/agregar-sku.component';
import { ListarSkuComponent } from './components/sku/listar-sku/listar-sku.component';
import { OrdenDetalleComponent } from './components/orden-detalle/orden-detalle.component';
import { ListarOrdenComponent } from './components/orden-detalle/listar-orden/listar-orden.component';
import { MenuComponent } from './menu/menu.component';

@NgModule({
  declarations: [
    AppComponent,
    SkuComponent,
    FooterComponent,
    AgregarSkuComponent,
    ListarSkuComponent,
    OrdenDetalleComponent,
    ListarOrdenComponent,
    MenuComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
