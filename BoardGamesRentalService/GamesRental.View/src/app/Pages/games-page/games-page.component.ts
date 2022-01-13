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

  blacklistAddresses: string[] = [];
  blacklisted: any[] = [];
  dtOptions: DataTables.Settings = {};
  dtTrigger: Subject<any> = new Subject<any>();

  constructor(private rentService: RentalService,
    private emailService: EmailService, private snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.getBlacklisted();
    this.renderBlacklistTable();
  }

  ngOnDestroy(): void {
    this.dtTrigger.unsubscribe();
  }

  getBlacklisted() {
    this.rentService.getBlackListed().subscribe(response => {
      this.blacklisted = response;
    })

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
