import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { SKUService } from 'src/app/services/sku.service';

@Component({
  selector: 'app-listar-sku',
  templateUrl: './listar-sku.component.html',
  styleUrls: ['./listar-sku.component.css']
})
export class ListarSkuComponent implements OnInit {

  constructor(public Skuservice:SKUService,
              public toastr:ToastrService) { }

  ngOnInit(): void {
    this.Skuservice.ObtenerListaSKU();
  }
  EliminarSku(id_sku: string | undefined){
    if(confirm('Seguro que desee eliminar el registro')){
      id_sku?.toString;
      this.Skuservice.EliminarSKU(id_sku!).subscribe(data =>{
        this.toastr.warning('Registro Eliminado','SKU fue eliminado')
        this.Skuservice.ObtenerListaSKU();
      })
    }
  }
}
