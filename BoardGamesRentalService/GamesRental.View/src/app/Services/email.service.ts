import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';

const headers = new HttpHeaders()
  .set('content-type','application/json')
  .set('Access-Control-Allow-Origin','*');

@Injectable({
  providedIn: 'root'
})
export class EmailService {

  constructor(private httpClient: HttpClient) { }

  sendEmail(addresses:string){
    return this.httpClient.post(`https://localhost:44370/email/send/${addresses}`,{headers:headers});
  }
}
