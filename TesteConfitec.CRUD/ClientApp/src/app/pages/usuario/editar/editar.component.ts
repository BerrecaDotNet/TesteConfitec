import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UsuarioDataService } from '../../../_data-services/user.data-service';
import { Usuario } from 'src/app/models/Usuario';

@Component({
  selector: 'app-editar',
  templateUrl: './editar.component.html',
  styleUrls: ['./editar.component.css']
})
export class EditarComponent implements OnInit{
  btnAcao = "Editar";
  btnTitulo = "Editar Usuarios!";
  usuario!: Usuario;

  constructor(private usuarioDataService: UsuarioDataService, private router: Router, private route: ActivatedRoute) {


  }

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.usuarioDataService.GetUsuario(id).subscribe((data) => {
      this.usuario = data.dados;

    });
  }

  async editarFuncionario(usuario: Usuario) {

    this.usuarioDataService.EditarUsuario(usuario).subscribe(data => {
      this.router.navigate(['/']);
    });

  }
}
