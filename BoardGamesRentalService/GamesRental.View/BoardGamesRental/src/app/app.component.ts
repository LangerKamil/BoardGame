import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'BoardGamesRental';

  login = false;

  logIn(){
    this.login = !this.login;
  }

  logOut(){
    this.login = !this.login;
  }
}
