import { Component, OnInit, OnDestroy } from '@angular/core';
import { Games } from 'src/app/Models/Games';
import { GamesService } from 'src/app/Services/games.service';
import { Subject } from 'rxjs';
import { RentalService } from 'src/app/Services/rental.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-rented-games',
  templateUrl: './rented-games.component.html',
  styleUrls: ['./rented-games.component.scss']
})
export class RentedGamesComponent implements OnInit {


  dtOptions: DataTables.Settings = {};
  games = Games;


  dtTrigger: Subject<any> = new Subject<any>();


  email: string = "";

  constructor(private service: GamesService, private rentalService: RentalService,private snackBar:MatSnackBar) { }


  ngOnInit(): void {
    $('#customerGamesTable').DataTable().destroy();
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 5,
      search: {
        caseInsensitive: true
      }
    }
  }

  showRentedGames(email: string) {
   this.rentalService.getRentedGames(email).subscribe(response=>{
     console.log(response)
     this.games = response
   });
  }

  returnGame(gameId:number){
    console.log("dziala");
    this.rentalService.returnGame(gameId,this.email).subscribe(data=>this.openSnackBar("Success!"),
    error=>this.openSnackBar(`Error! ${error}`))
  }

  openSnackBar(message:string) {
    this.snackBar.open(message, "Ok");
  }
}
