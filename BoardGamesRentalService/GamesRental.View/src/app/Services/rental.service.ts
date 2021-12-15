import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { Game } from '../Models/Game';
import { Customer } from '../Models/Customer';
import { Observable} from 'rxjs';

const headers = new HttpHeaders()
  .set('content-type','application/json')
  .set('Access-Control-Allow-Origin','*');

@Injectable({
  providedIn: 'root'
})
export class RentalService {

  constructor(private httpClient: HttpClient) { }

  rentGame(gameId: number,customer:Customer){
    return this.httpClient.post(`https://localhost:44370/rental/add/${gameId}/${customer.firstName}/${customer.lastName}/${customer.emailAddress}`,{headers:headers});
  }

  returnGame(gameId: number,email:string){
    return this.httpClient.post(`https://localhost:44370/rental/return/${gameId}/${email}`,{headers:headers});
  }

  getRentedGames(email:string):Observable<Game[]>{
    return this.httpClient.get<Game[]>(`https://localhost:44370/rental/get/rentedGames/${email}/`,{headers:headers});
  }

  getBlackListed():Observable<any[]>{
    return this.httpClient.get<any[]>('https://localhost:44370/rental/get/blacklisted');
  }

}
