import { NgModule } from '@angular/core';
import { AuthGuard } from './auth.guard';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { LoginComponent } from './pages/login/login.component';
import { UsersComponent } from './pages/users/users.component';
import { UserEditComponent } from './pages/users/user-edit/user-edit.component';
import { CategoryComponent } from './pages/category/category.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'login', component: LoginComponent },

  { path: 'users', component: UsersComponent, canActivate: [AuthGuard] },
  { path: 'users/edit/:id', component: UserEditComponent, canActivate: [AuthGuard] },

  { path: 'category', component: CategoryComponent, canActivate: [AuthGuard] },

  { path: '**', redirectTo: '/not-found' }, // Exemplu de rută wildcard

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
