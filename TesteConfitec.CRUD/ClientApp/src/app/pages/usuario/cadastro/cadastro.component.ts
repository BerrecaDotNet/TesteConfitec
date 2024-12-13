import { Component, OnInit, Output, Input, EventEmitter} from '@angular/core';
import { FormControl, FormGroup, Validators  } from '@angular/forms';

import {MatButtonModule} from '@angular/material/button';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatCardModule} from '@angular/material/card';
import {MatTableModule} from '@angular/material/table';
import {MatInputModule} from '@angular/material/input';
import {MatSelectModule} from '@angular/material/select';
import {MatDialog, MatDialogModule} from '@angular/material/dialog';
import { UsuarioDataService } from '../../../_data-services/user.data-service';
import { Usuario } from '../../../models/Usuario';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css']
})
export class CadastroComponent implements OnInit {

  @Output() onSubmit = new EventEmitter<Usuario>();
  @Input() btnAcao!: string;
  @Input() btnTitulo!: string;
  @Input() dadosUsuario: Usuario | null = null;

  usuarioForm!: FormGroup;

  constructor(private usuarioDataService: UsuarioDataService, private router: Router) {
    
  }

  ngOnInit(): void {

    this.usuarioForm = new FormGroup({
      id: new FormControl(this.dadosUsuario ? this.dadosUsuario.UsuarioId : 0),
      nome: new FormControl(this.dadosUsuario ? this.dadosUsuario.Nome : '', [Validators.required]),
      sobrenome: new FormControl(this.dadosUsuario ? this.dadosUsuario.Sobrenome : '', [Validators.required]),
      email: new FormControl(this.dadosUsuario ? this.dadosUsuario.Email : '', [Validators.required]),
      dataNascimento: new FormControl(this.dadosUsuario ? this.dadosUsuario.DataNascimento : '', [Validators.required]),
     
    });

  }

  criarUsuario(usuario: Usuario) {

    this.usuarioDataService.CriarUsuario(usuario).subscribe((data) => {
      this.router.navigate(['/']);
    })
  }

  submit() {

    console.log(this.usuarioForm.value)

    this.onSubmit.emit(this.usuarioForm.value);
  }



 
}
  
