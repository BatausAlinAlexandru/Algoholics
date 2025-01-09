import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  SERVER_URL = environment.SERVER_URL;
  constructor(private http: HttpClient) { }

  /* returneaza toate produsele din backend */
  getAllProducts(numberOfResults = 10) {
    return this.http.get(this.SERVER_URL+'/products', {
      params: {
        limit: numberOfResults.toString()
      }
    });
  }
  private products = [
    {
      id: 1, name: 'MACBOOK PRO RETINA 13 INCH', description:
['Informatii MacBook:',
'Seria: MacBook Pro',
'An: Mid 2014',
'Stare baterie: 663 Cicluri / 88 % Health',
'Accesorii incluse: Incarcator',
'Model procesor: Core i5 - 4278U',
'Diagonala display: 13 - inch',
'Memorie: 8GB',
'Capacitate stocare: 128GB SSD',
'Placa video: Iris 5100 1.5GB shared',
'Versiune tastatura: NOR',
'Culoare: Silver'], image: '/assets/img/product01.png' },
    { id: 2, name: 'CASTI SUPERLUX HD681', description: 'Descrierea produsului 2', image: '/assets/img/product02.png' },
    { id: 3, name: 'MACBOOK PRO 15.4 INCH', description: 'Descrierea produsului 3', image: '/assets/img/product03.png' },
    { id: 4, name: 'TASTATURA GAMING NATEC', description: 'Descrierea produsului 3', image: '/assets/img/product14.png' },
    { id: 5, name: 'SONY MDR-CD1700', description: 'Descrierea produsului 3', image: '/assets/img/product05.png' },
    { id: 6, name: 'SAMSUNG GALAXY EDGE S7', description: 'Descrierea produsului 3', image: '/assets/img/product07.png' },
    { id: 7, name: 'REKAM PRESTO-SL101', description: 'Descrierea produsului 3', image: '/assets/img/product09.png' },
    { id: 8, name: 'ASUS X200MA', description: 'Descrierea produsului 3', image: '/assets/img/product08.png' },
    { id: 9, name: 'APPLE IPHONE 13', description: 'Descrierea produsului 3', image: '/assets/img/product10.png' },
    { id: 10, name: 'SONY CYBER-SHOT', description: 'Descrierea produsului 3', image: '/assets/img/product12.png' },
    { id: 11, name: 'MOUSE GAMING LOGITECH', description: 'Descrierea produsului 3', image: '/assets/img/product13.png' },
    { id: 12, name: 'GALAXY A15 LTE', description: 'Descrierea produsului 3', image: '/assets/img/product11.png' },

  ];

  getProductById(id:number){
    return this.products.find(product => product.id === id);
  }
}
