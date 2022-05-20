import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import { Restaurant } from '../_models/restaurant';
import { RestaurantService } from '../_services/restaurant.service';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.css']
})
export class DetailComponent implements OnInit 
{
  restaurant: Restaurant;

  constructor(private route: ActivatedRoute, private restaurantService: RestaurantService, private router: Router) {
    this.route.params.subscribe( params => console.log(params) );
   }

  ngOnInit(): void {
    this.loadRestaurant();
  }

  loadRestaurant()
  {
    this.restaurantService.getRestaurant(this.route.snapshot.paramMap.get('id')).subscribe(restaurant =>
    {
      this.restaurant = restaurant;
      console.log(this.restaurant);
    }, error =>
    {
      this.router.navigateByUrl("/notauthorized");
    })
  }

  numSequence(n: number): Array<number> 
  {
    return Array(n);
  }
}
