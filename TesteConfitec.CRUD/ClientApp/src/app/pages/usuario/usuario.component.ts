import { Component, OnInit } from '@angular/core';
import { UsuarioDataService } from '../../_data-services/user.data-service';
import { Usuario } from '../../models/Usuario';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-usuario',
  //imports: [],
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.css']
})
export class UsuarioComponent implements OnInit{

  usuarios: Usuario[] = [] ;
  usuariosGeral: Usuario[] = [];
  

  columnsToDisplay = ['Nome', 'Sobrenome', 'E-mail', 'Data de Nascimento', 'Escolaridade'];

  constructor(private usuarioDataService: UsuarioDataService, public matDialog: MatDialog) {
    
  }

  ngOnInit(): void {

    this.usuarioDataService.GetTodosUsuarios().subscribe((data) => {

      const dados = data.dados;

      console.log("------DATA------");
      console.log(data);

      console.log("------DADOS------");
      console.log(dados);
      
      console.log("------DADOS[1].Nome------");
      console.log(dados[1].Nome);

      
      dados.map(( item) => {
          item.DataNascimento = new Date(item.DataNascimento!).toLocaleDateString('pt-BE');
        
      });

      this.usuarios = dados;
      this.usuariosGeral = dados;

    });
    }

    search(event : Event){

      console.log(event);
      const target = event.target as HTMLInputElement;
      const value = target.value.toLowerCase();

      this.usuarios = this.usuariosGeral.filter(usuario => {
        return usuario.Nome.toLowerCase().includes(value);
      })

      }

  

 

}
