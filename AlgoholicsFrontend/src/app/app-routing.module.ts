/// <reference path="app.module.server.ts" />
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomepageComponent } from './components/homepage/homepage.component';
import { ProductComponent } from './components/product/product.component';
import { CartComponent } from './components/cart/cart.component';
import { CheckboxControlValueAccessor } from '@angular/forms';
import { CheckoutComponent } from './components/checkout/checkout.component';
import { LoginComponent } from './components/login/login.component';
import { SignupComponent } from './components/signup/signup.component';
import { UserProfileComponent } from './components/user-profile/user-profile.component';
import { EditUserProfileComponent } from './components/edit-user-profile/edit-user-profile.component'; 
import { WishlistComponent } from './components/wishlist/wishlist.component';
import { ProductPageComponent } from './components/product-page/product-page.component';
import { ProductListComponent } from './components/product-list/product-list.component';

const routes: Routes = [
  {
    path: '', component: HomepageComponent
  },
  {
    path: 'product/:id', component: ProductComponent
  },
  {
    path: 'cart', component: CartComponent
  },
  {
    path: 'checkout', component: CheckoutComponent
  },
  {
    path: 'login', component: LoginComponent
  },
  {
    path: 'signup', component: SignupComponent
  },
  {
    path: 'user-profile', component: UserProfileComponent
  },
  {
    path: 'edit-user-profile', component: EditUserProfileComponent
  },
  {
    path: 'wishlist', component: WishlistComponent
  },
  {
    path: 'product-details/:id', component: ProductPageComponent
  },
  {
    path: '**', redirectTo: ''
  },
  {
    path: '', component: ProductListComponent
  },

  {
    path: 'cart', component: CartComponent
  }
 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
