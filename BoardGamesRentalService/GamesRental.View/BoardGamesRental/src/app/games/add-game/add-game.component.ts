import { Component, OnInit } from '@angular/core';
import { Game } from 'src/app/Models/Game';
import { Games } from 'src/app/Models/Games';
import { GamesService } from 'src/app/Services/games.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-add-game',
  templateUrl: './add-game.component.html',
  styleUrls: ['./add-game.component.scss']
})
export class AddGameComponent implements OnInit {

  constructor(private service:GamesService,private snackBar: MatSnackBar) { }

  ngOnInit(): void {
  }
games = Games;

game: Game = {
  id: Games.length +1,
  title: "",
  description: "",
  inStock: 0,
  price: 0
};

addGame():void{
  this.service.addGame(this.game)
  .subscribe(data=>this.openSnackBar("Success!"),
  error=>this.openSnackBar(`Error! ${error}`))
}

openSnackBar(message:string) {
  this.snackBar.open(message, "Ok");
}

}
