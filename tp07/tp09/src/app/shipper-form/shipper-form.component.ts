
import { Shipper } from './../models/shipper';
import { ShippersService } from './../services/shippers.service';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import {Router} from "@angular/router"

import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-shipper-form',
  templateUrl: './shipper-form.component.html',
  styleUrls: ['./shipper-form.component.css']
})
export class ShipperFormComponent implements OnInit {

  newShipper: Shipper;
  form: FormGroup;
  submitted = false;
  loading = false;
  constructor(private fb: FormBuilder,private shipperService: ShippersService, private router: Router) { }

  ngOnInit() {
    this.form = this.fb.group({
      nombre: ['', [Validators.required, Validators.maxLength(40) ]],
      telefono: ['', [Validators.required, Validators.maxLength(24) ]]
    });
  }

  get f() { return this.form.controls;}

  onSubmit(){
    this.submitted = true;


    if (this.form.invalid) {
        console.log("no anda")
        return;
    }
    this.loading = true;

    this.guardarShipper()



  }

  getValue(value:string): AbstractControl {
    return this.form.get(value) as FormGroup;
  }

  guardarShipper(){
    var ship = new Shipper();
    ship.CompanyName = this.form.get('nombre')?.value;
    ship.Phone = this.form.get('telefono')?.value;
    this.shipperService.crearShipper(ship).subscribe(res =>{
      this.form.reset();
    this.router.navigate([''])

    });



  }

}
