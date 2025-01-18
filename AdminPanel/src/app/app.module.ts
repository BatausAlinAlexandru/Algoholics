import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home/home.component';
import { LoginComponent } from './pages/login/login.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { UsersComponent } from './pages/users/users.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { UserEditComponent } from './pages/users/user-edit/user-edit.component';
import { AuthService } from './auth.service';
import { NgxPaginationModule } from 'ngx-pagination';
import { CategoryComponent } from './pages/category/category.component';
import { ProductComponent } from './pages/product/product.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    NavbarComponent,
    UsersComponent,
    UserEditComponent,
    CategoryComponent,
    ProductComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    RouterModule.forRoot([]), // Adaugă rutele tale aici
    FormsModule, NgbModule, // Adaugă aici FormsModule
    NgxPaginationModule,

  ],
  providers: [AuthService],
  bootstrap: [AppComponent]
})
export class AppModule { }
