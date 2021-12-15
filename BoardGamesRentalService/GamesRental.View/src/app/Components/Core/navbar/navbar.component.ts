import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss'],
})
export class NavbarComponent implements OnInit {
  title: string = 'BoardGamesRental';
  login: boolean = false;

  constructor() {}

  ngOnInit(): void {}

  logIn(): void {
    this.login = !this.login;
  }

  logOut(): void {
    this.login = !this.login;
  }
}
