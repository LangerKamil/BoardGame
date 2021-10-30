import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RentedGamesComponent } from './customer/rented-games/rented-games.component';
import { AddGameComponent } from './games/add-game/add-game.component';
import { GamesComponent } from './games/games.component';
import { ManagerComponent } from './games/manager/manager.component';
import { RentComponent } from './games/rent/rent.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/home',
    pathMatch: 'full'
  },
  { path: 'home', component: HomeComponent},
  { path: 'rent/:id:title', component: RentComponent },
  { path: 'rent', component: RentComponent },
  { path: 'games', component: GamesComponent },
  { path: 'add-game', component: AddGameComponent },
  { path: 'manager', component: ManagerComponent },
  { path: 'forCustomers', component: RentedGamesComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
