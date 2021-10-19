import { ShippersService } from './../services/shippers.service';
import { Component, OnInit } from '@angular/core';

import { Shipper } from '../models/shipper';

@Component({
  selector: 'app-shippers',
  templateUrl: './shippers.component.html',
  styleUrls: ['./shippers.component.css']
})
export class ShippersComponent implements OnInit {

  public listShippers: Array<Shipper> = [];


  constructor(private shipperService: ShippersService) { }

  ngOnInit(): void {
    this.obtenerShippers();
  }

  obtenerShippers(){
    this.shipperService.getShippers().subscribe(res =>{
        this.listShippers = res;
    })
  }

  borrarShipper(ship: Shipper): void{
    this.shipperService.borrarShipper(ship).subscribe(res => {

      this.listShippers = this.listShippers.filter(s => s != ship);
    })
}
}
