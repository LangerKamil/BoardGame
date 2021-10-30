import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { DataTablesModule } from 'angular-datatables';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { GamesComponent } from './games/games.component';
import { HttpClientModule } from '@angular/common/http';
import { AddGameComponent } from './games/add-game/add-game.component';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { ManagerComponent } from './games/manager/manager.component';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { RentComponent } from './games/rent/rent.component';
import { HomeComponent } from './home/home.component';
import { OrdersComponent } from './orders/orders.component';
import { RentedGamesComponent } from './customer/rented-games/rented-games.component';





@NgModule({
  declarations: [
    AppComponent,
    GamesComponent,
    AddGameComponent,
    ManagerComponent,
    RentComponent,
    HomeComponent,
    OrdersComponent,
    RentedGamesComponent
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

