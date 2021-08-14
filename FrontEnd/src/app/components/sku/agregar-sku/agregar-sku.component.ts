import { Component, OnInit } from '@angular/core';
import {FormGroup,FormBuilder,Validators} from '@angular/forms'
import { ToastrService } from 'ngx-toastr';
import { Sku } from 'src/app/models/Sku';
import { SKUService } from 'src/app/services/sku.service';

@Component({
  selector: 'app-agregar-sku',
  templateUrl: './agregar-sku.component.html',
  styleUrls: ['./agregar-sku.component.css']
})
export class AgregarSkuComponent implements OnInit {
  form: FormGroup;
  constructor(private formBuilder: FormBuilder,
              private SKUService: SKUService,
              private toastr: ToastrService) {
    this.form =this.formBuilder.group({
      id:['',[Validators.required]],
      descripcion:['',[Validators.required]],
      existencia:['',[Validators.required]],
    })
   }

  ngOnInit(): void {
  }

  agregarsku(){
    const sku: Sku ={
      id_sku: this.form.get("id")?.value,
      descripcion: this.form.get("descripcion")?.value,
      existencia: parseInt(this.form.get("existencia")?.value),
      estado: true
    }
    this.SKUService.agregarsku(sku).subscribe(data =>{
      this.toastr.success('Registro Agregado','SKU fue ingresado');
      this.SKUService.ObtenerListaSKU()
      this.form.reset();
    });
  }
}
