import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

import {MatButtonModule} from '@angular/material/button';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatCardModule} from '@angular/material/card';
import {MatTableModule} from '@angular/material/table';
import {MatInputModule} from '@angular/material/input';
import {MatSelectModule} from '@angular/material/select';
import {MatDialogModule} from '@angular/material/dialog';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css']
})
export class CadastroComponent implements OnInit {

  usuarioForm!: FormGroup;


  /**
   *
   */
  constructor() {
    
  }

  ngOnInit(): void {
    this.usuarioForm = new FormGroup({
      id:  new FormControl(0),
      nome: new FormControl(''),
      sobrenome: new FormControl(''),
      email: new FormControl(''),
      dataNascimento: new FormControl(''),
      escolaridade: new FormControl('')
    })

  }

  submit(){
    console.log(this.usuarioForm);
  }
}
  
