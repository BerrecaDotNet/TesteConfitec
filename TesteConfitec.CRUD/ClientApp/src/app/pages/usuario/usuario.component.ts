import { Component, OnInit } from '@angular/core';
import { UsuarioDataService } from '../../_data-services/user.data-service';
import { Usuario } from '../../models/Usuario';

@Component({
  selector: 'app-usuario',
  //imports: [],
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.css']
})
export class UsuarioComponent implements OnInit{

  usuarios: Usuario[] = [];
  usuariosGeral: Usuario[] = [];

  constructor(private usuarioDataService: UsuarioDataService) {

  }

  ngOnInit(): void {
    this.usuarioDataService.GetAllUsers().subscribe(data => {
      
      console.log(data);

      const dados = data;
      
      dados.map(( item)=>{
          item.DataNascimento = new Date(item.DataNascimento!).toLocaleDateString('pt-BR');
          //item.Nome = "rebecca";
          console.log(item.Email);
         
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
