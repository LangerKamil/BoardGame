import { Component, OnInit } from '@angular/core';
import { Customer } from 'src/app/Models/Customer';
import { ActivatedRoute} from '@angular/router';
import { Game } from 'src/app/Models/Game';
import { Games } from 'src/app/Models/Games';
import { GamesService } from 'src/app/Services/games.service';
import { RentalService } from 'src/app/Services/rental.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-rent',
  templateUrl: './rent.component.html',
  styleUrls: ['./rent.component.scss']
})
export class RentComponent implements OnInit {

  newCustomer: Customer ={
    id: 5,
    firstName: "",
    lastName: "",
    emailAddress: ""
  }

  games= Games;

  gameId:number = 1;

  game:Game={
    id:1,
    title:"",
    description:"",
    inStock:1,
    price:1
  }

  title:string= "";

  constructor(private router: ActivatedRoute, private _gameService:GamesService, private _rentalService:RentalService, private snackBar:MatSnackBar) { }

  ngOnInit(): void {
    this.router.queryParams.subscribe(params=>{
      this.gameId = params['id'];
      this.title = params['title'];
    })
    this.getGameByTitle(this.title);
  }

  getGameByTitle(title:string){
    this._gameService.getGameByTitle(title).subscribe(response=>{
      this.game = response;
      Object.values(response).forEach(val=>{
        this.game = val;
      })
    })
  }

  rent(newCustomer:Customer){
    this._rentalService.rentGame(this.gameId,newCustomer)
    .subscribe(data=>this.openSnackBar("Success!"),
    error=>this.openSnackBar(`Error! ${error}`))
  }


  openSnackBar(message:string) {
    this.snackBar.open(message, "Ok");
  }
}
