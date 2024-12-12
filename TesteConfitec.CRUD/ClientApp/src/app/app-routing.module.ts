import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
// import { DetalhesComponent } from './pages/detalhes/detalhes.component';
import { HomeComponent } from './pages/home/home.component';
import { CadastroComponent } from './pages/usuario/cadastro/cadastro.component';
// import { EditarComponent } from './pages/editar/editar.component';
import { UsuarioComponent } from './pages/usuario/usuario.component';

const routes: Routes = [
//   {path:'detalhes/:id', component: DetalhesComponent },
  {path: '', component: HomeComponent},
  {path: 'cadastro', component: CadastroComponent},
  {path: 'usuario', component: UsuarioComponent}
//   {path: 'editar/:id', component: EditarComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }