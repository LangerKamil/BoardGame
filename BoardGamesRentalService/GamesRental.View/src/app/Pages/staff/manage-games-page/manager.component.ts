import { Component, OnInit, OnDestroy } from '@angular/core';
import { Games } from 'src/app/Models/Games';
import { GamesService } from 'src/app/Services/games.service';
import { Subject } from 'rxjs';
import { Game } from 'src/app/Models/Game';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-manager',
  templateUrl: './manager.component.html',
  styleUrls: ['./manager.component.scss']
})
export class ManagerComponent implements OnInit {

  dtOptions: DataTables.Settings = {};
  games = Games;
  edit = false;

  game: Game = {
    id: Games.length + 1,
    title: "",
    description: "",
    inStock: 0,
    price: 0
  };

  dtTrigger: Subject<any> = new Subject<any>();

  constructor(private service: GamesService, private snackBar: MatSnackBar) { }

  ngOnInit(): void {

    this.getGames();

    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 5,
      search: {
        caseInsensitive: true
      },

    };
  }

  ngOnDestroy(): void {
    this.dtTrigger.unsubscribe();
  }
  getGames(): void {

    this.service.getGames().subscribe(response => {
      this.games = response;
      this.dtTrigger.next();
    })
  }

  deleteGame(game: Game) {
    this.service.deleteGame(game)
      .subscribe(data => this.openSnackBar("Game has been deleted successfully!"),
        error => this.openSnackBar(`Error! ${error}`));

    this.renderTable();
  }

  editGame(game: Game) {
    this.service.editGame(game)
      .subscribe(data => this.openSnackBar("Game has been edited successfully!"),
        error => this.openSnackBar(`Error! ${error}`));

    this.renderTable();
  }

  editor(game: Game) {
    this.game = game;
    this.edit = !this.edit;

  }

  openSnackBar(message: string) {
    this.snackBar.open(message, "Ok");
  }

  renderTable() {
    $('#ediTable').DataTable().clear().destroy();
    this.getGames();
    this.dtOptions = {
      retrieve:true,
      pagingType: 'full_numbers',
      pageLength: 5,
      search: {
        caseInsensitive: true
      },

    };
  }

  checkAvailability(game: Game): boolean {
    if (game.inStock === 0) return false;
    else return true;
  }
}
