import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Usuario } from "../models/Usuario";

@Injectable()
export class UsuarioDataService {

  private apiUrl  = 'https://localhost:7212/api/Usuario/AllUsers'


  // module: string = '/api/Usuario';

  constructor(private http: HttpClient){ }

  // get() {
  //   this.http.get(this.module);
  // }
  GetAllUsers(): Observable<Usuario[]>{
    return this.http.get<Usuario[]>(this.apiUrl);

  }

}
