import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RentedGamesComponent } from './customer/rented-games/rented-games.component';
import { AddGameComponent } from './Pages/staff/add-game-page/add-game.component';
import { GamesComponent } from './Pages/games-page/games-page.component';
import { ManagerComponent } from './Pages/staff/manage-games-page/manager.component';
import { RentComponent } from './Pages/games-page/rent/rent.component';
import { HomeComponent } from './Pages/home-page/home-page.component';

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
