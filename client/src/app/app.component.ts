import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Iitems } from './models/item';
import { IPagination } from './models/pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  
  title = 'LoveCrochet';
  items: Iitems[];

  //call the API 
  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    //returns an observable and subscribe to the observeable to make it useful
    this.http.get('https://localhost:5001/api/items?pageSize=50').subscribe((response: IPagination) => {
    this.items = response.data;
    }, error => {
      console.log(error);
    } );

  }
}
