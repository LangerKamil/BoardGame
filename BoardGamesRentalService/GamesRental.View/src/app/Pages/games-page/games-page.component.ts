import { Component, OnInit, OnDestroy } from '@angular/core';
import { Games } from '../../Models/Games';
import { GamesService } from '../../Services/games.service';
import { Subject } from 'rxjs';
import { Customers } from '../../Models/Customers';
import { RentalService } from '../../Services/rental.service';
import { Game } from '../../Models/Game';
import { EmailService } from '../../Services/email.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-games-page',
  templateUrl: './games-page.component.html',
  styleUrls: ['./games-page.component.scss']
})
export class GamesComponent implements OnInit {

  dtOptions: DataTables.Settings = {};

  games = Games;
  customers = Customers;
  blacklistAddresses: string[] = [];
  blacklisted: any[] = [];

  dtTrigger: Subject<any> = new Subject<any>();

  constructor(private service: GamesService, private rentService: RentalService,
    private emailService: EmailService, private snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.getGames();
    this.getBlacklisted();
    this.renderGamesTable();
    this.renderBlacklistTable();
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

  getBlacklisted() {
    this.rentService.getBlackListed().subscribe(response => {
      this.blacklisted = response;
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

  renderBlacklistTable() {
    $('#blacklistedTable').DataTable().clear().destroy();
    this.getBlacklisted();
    this.dtOptions = {
      retrieve:true,
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

  sendEmails() {
    var address: string = "";
    this.blacklisted.forEach(function (value) {
      address += `${value.customer.emailAddress},`
    })

    address = address.slice(0, -1);

    this.emailService.sendEmail(address)
      .subscribe(data => this.openSnackBar("Deptors emails sent!"),
        error => this.openSnackBar(`Error! ${error}`))
  }

  openSnackBar(message: string) {
    this.snackBar.open(message, "Ok");
  }
}
