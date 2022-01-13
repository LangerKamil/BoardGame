import { Component, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { Customers } from 'src/app/Models/Customers';
import { Game } from 'src/app/Models/Game';
import { Games } from 'src/app/Models/Games';
import { GamesService } from 'src/app/Services/games.service';
import { RentalService } from 'src/app/Services/rental.service';

@Component({
  selector: 'app-games-list',
  templateUrl: './games-list.component.html',
  styleUrls: ['./games-list.component.scss']
})
export class GamesListComponent implements OnInit {
  games = Games;
  customers = Customers;
  dtOptions: DataTables.Settings = {};
  dtTrigger: Subject<any> = new Subject<any>();

  constructor(private service: GamesService, private rentService: RentalService) { }

  ngOnInit(): void {
    this.getGames();
    this.renderGamesTable();
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

  renderGamesTable() {
    $('#customerTable').DataTable().clear().destroy();
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 5,
      search: {
        caseInsensitive: true
      }
    };
  }

  checkAvailability(game: Game): boolean {
    if (game.inStock === 0) return false;
    else return true;
  }
}
