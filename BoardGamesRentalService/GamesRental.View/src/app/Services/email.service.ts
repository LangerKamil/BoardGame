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

  port: string = '44360';

  sendEmail(addresses:string){
    return this.httpClient.post(`https://localhost:${this.port}/email/send/${addresses}`,{headers:headers});
  }
}
