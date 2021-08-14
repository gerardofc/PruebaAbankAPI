import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OrdenDetalleComponent } from './components/orden-detalle/orden-detalle.component';
import { SkuComponent } from './components/sku/sku.component';

const routes: Routes = [
  {
    
    
    path:'ordendetalle',
    component:OrdenDetalleComponent

  },
  {
    path:'sku',
    component:SkuComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
