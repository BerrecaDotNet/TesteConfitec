import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Usuario } from "../models/Usuario";
import { Response } from '../models/Response';

@Injectable()
export class UsuarioDataService {

  private apiUrl  = 'https://localhost:7212/api/Usuario'


  // module: string = '/api/Usuario';

  constructor(private http: HttpClient){ }

  // get() {
  //   this.http.get(this.module);
  // }
  GetTodosUsuarios(): Observable<Response<Usuario[]>>{
    //return this.http.get<Usuario[]>(`${this.apiUrl}/AllUsers`);
    return this.http.get<Response<Usuario[]>>(this.apiUrl);

  }

  GetUsuario(id: number): Observable<Response<Usuario>> {
    return this.http.get<Response<Usuario>>(`${this.apiUrl}/${id}`);
  }

  CriarUsuario(usuario: Usuario): Observable<Response<Usuario[]>> {
    return this.http.post<Response<Usuario[]>>(this.apiUrl, usuario);
  }

  EditarUsuario(usuario: Usuario): Observable<Response<Usuario[]>> {
    return this.http.put<Response<Usuario[]>>(this.apiUrl, usuario);
  }

  DeletarUsuario(id: number): Observable<Response<Usuario[]>> {
    return this.http.delete<Response<Usuario[]>>(`${this.apiUrl}?id=${id}`)
  }

}
