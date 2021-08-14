import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { OrdendetalleService } from 'src/app/services/ordendetalle.service';

@Component({
  selector: 'app-listar-orden',
  templateUrl: './listar-orden.component.html',
  styleUrls: ['./listar-orden.component.css']
})
export class ListarOrdenComponent implements OnInit {

  constructor(public Ordendetalleservice:OrdendetalleService,
              public toastr:ToastrService) { }

  ngOnInit(): void {
    this.Ordendetalleservice.ObtenerListaOrden();
  }
  CancelarOrden(id_orden: string | undefined){
    if(confirm('Seguro que desee eliminar el registro')){
      id_orden?.toString;
      this.Ordendetalleservice.CancelarOrden(id_orden!).subscribe(data =>{
        this.toastr.warning('Registro Eliminado','SKU fue eliminado')
        this.Ordendetalleservice.ObtenerListaOrden();
      })
    }
  }
}
