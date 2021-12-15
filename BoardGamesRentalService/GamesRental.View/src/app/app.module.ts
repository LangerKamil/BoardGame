import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { DataTablesModule } from 'angular-datatables';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { GamesComponent } from './Pages/games-page/games-page.component';
import { HttpClientModule } from '@angular/common/http';
import { AddGameComponent } from './Pages/staff/add-game-page/add-game.component';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { ManagerComponent } from './Pages/staff/manage-games-page/manager.component';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { RentComponent } from './Pages/games-page/rent/rent.component';
import { HomeComponent } from './Pages/home-page/home-page.component';
import { OrdersComponent } from './orders/orders.component';
import { RentedGamesComponent } from './customer/rented-games/rented-games.component';
import { NavbarComponent } from './Components/Core/navbar/navbar.component';





@NgModule({
  declarations: [
    AppComponent,
    GamesComponent,
    AddGameComponent,
    ManagerComponent,
    RentComponent,
    HomeComponent,
    OrdersComponent,
    RentedGamesComponent,
    NavbarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    DataTablesModule,
    MatCardModule,
    MatInputModule,
    MatIconModule,
    FormsModule,
    MatButtonModule,
    MatSnackBarModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

