import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { WishlistService, Wishlist, Product } from '../../services/wishlist.service';
import { HttpClient } from '@angular/common/http';
import jwtDecode from 'jwt-decode';


@Component({
  selector: 'app-wishlist',
  templateUrl: './wishlist.component.html',
  styleUrls: ['./wishlist.component.css'],
})
export class WishlistComponent implements OnInit {
  wishlist: Wishlist | null = null;
  loggedInUserId: string = ''; // Assume this is retrieved from a token or authentication service
  searchTerm: string = '';

  constructor(private wishlistService: WishlistService, private http: HttpClient) { }

  ngOnInit(): void {
    this.fetchWishlist();
  }

  fetchWishlist(): void {
    // Assuming `loggedInUserId` is obtained from a token or auth service
    this.loggedInUserId = this.getUserIdFromToken();
    this.wishlistService.getWishlistByUserId(this.loggedInUserId).subscribe(
      (data) => {
        this.wishlist = data;
      },
      (error) => {
        console.error('Error fetching wishlist!', error);
      }
    );
  }

  removeFromWishlist(product: Product): void {
    if (this.wishlist) {
      const updatedProducts = this.wishlist.products.filter((p) => p.id !== product.id);
      this.wishlistService.updateWishlist(this.wishlist.id, updatedProducts).subscribe(
        (updatedWishlist) => {
          this.wishlist = updatedWishlist;
        },
        (error) => {
          console.error('Error removing product from wishlist', error);
        }
      );
    }
  }

  

  getUserIdFromToken(): string {
    const token = localStorage.getItem('token'); // Ensure this matches the storage key for your token
    if (token) {
      try {
        const payloadBase64 = token.split('.')[1]; // Extract the payload part of the JWT
        const decodedPayload = JSON.parse(atob(payloadBase64)); // Decode the base64-encoded payload
        return decodedPayload.nameid || ''; // Extract the `nameid` field as the user ID
      } catch (error) {
        console.error('Error parsing JWT token:', error);
        return '';
      }
    }
    return '';
  }


}
