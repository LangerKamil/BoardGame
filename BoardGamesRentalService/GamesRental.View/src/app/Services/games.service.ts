import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { Game } from '../Models/Game';
import { Observable} from 'rxjs';

const headers = new HttpHeaders()
  .set('content-type','application/json')
  .set('Access-Control-Allow-Origin','*');


@Injectable({
  providedIn: 'root'
})
export class GamesService {

  constructor(private httpClient: HttpClient) { }

  port: string = '44360';

  getGames():Observable<Game[]>{
    return this.httpClient.get<Game[]>(`https://localhost:${this.port}/game/get`);
  }

  getGameByTitle(title:string):Observable<Game>{
    return this.httpClient.get<Game>(`https://localhost:${this.port}/game/get/singleByTitle/${title}`);
  }

  addGame(game:Game){
    return this.httpClient.post(`https://localhost:${this.port}/game/add/${game.title}/${game.description}/${game.inStock}/${game.price}`,{headers:headers});
  }

  deleteGame(game:Game){
    return this.httpClient.delete(`https://localhost:${this.port}/game/delete/${game.id}`,{headers: headers})
  }

  editGame(game:Game){
    return this.httpClient.put(`https://localhost:${this.port}/game/edit/${game.id}/${game.title}/${game.description}/${game.inStock}/${game.price}`,{headers:headers})
  }
}
