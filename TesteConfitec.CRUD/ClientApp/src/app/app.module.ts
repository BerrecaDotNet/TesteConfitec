import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './pages/home/home.component';

import { UsuarioComponent } from './pages/usuario/usuario.component';
import { UsuarioDataService } from './_data-services/user.data-service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CadastroComponent } from './pages/usuario/cadastro/cadastro.component';



import {MatButtonModule} from '@angular/material/button';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatCardModule} from '@angular/material/card';
import {MatTableModule} from '@angular/material/table';
import {MatInputModule} from '@angular/material/input';
import {MatSelectModule} from '@angular/material/select';
import {MatDialogModule} from '@angular/material/dialog';

import{CUSTOM_ELEMENTS_SCHEMA} from '@angular/core';
import { EditarComponent } from './pages/usuario/editar/editar.component';




@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    UsuarioComponent,
    EditarComponent,
   
    

  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'usuario', component: UsuarioComponent },
      { path: 'usuario/cadastro', component: CadastroComponent },
      { path: 'usuario/editar', component: EditarComponent },
    ]),
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatFormFieldModule,
    MatCardModule,
    MatTableModule,
    MatInputModule,
    MatSelectModule,
    MatDialogModule,

    

  ],
  providers: [UsuarioDataService],
  bootstrap: [AppComponent],
  schemas:[CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
