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

  usuarios: Usuario[] = [];
  usuariosGeral: Usuario[] = [];

  columnsToDisplay = ['Nome', 'Sobrenome', 'E-mail', 'Data de Nascimento', 'Escolaridade'];

  constructor(private usuarioDataService: UsuarioDataService, public matDialog: MatDialog) {

  }

  ngOnInit(): void {
    this.usuarioDataService.GetAllUsers().subscribe((data) => {
      
      console.log(data);
      

      
      data.map(( item)=>{
          item.DataNascimento = new Date(item.DataNascimento!).toLocaleDateString('pt-BE');
          //item.Nome = "rebecca";
        console.log("------------");
        console.log("Nome: " + item.Nome);
        console.log("Sobrenome: " + item.Nome);
         
      });

      this.usuarios = data;
      this.usuariosGeral = data;

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
