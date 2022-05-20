import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-catalogue',
  templateUrl: './catalogue.component.html',
  styleUrls: ['./catalogue.component.css']
})
export class CatalogueComponent implements OnInit {

  restaurants: any;
  constructor(private http: HttpClient) { }

  ngOnInit(): void 
  {
    this.getRestaurants();
  }

  getRestaurants()
  {
    this.http.get('https://localhost:7251/api/restaurant').subscribe(response => {
      this.restaurants = response
    }, error => {
      console.log(error)
    })
  }

  numSequence(n: number): Array<number> 
  {
    return Array(n);
  }
}
