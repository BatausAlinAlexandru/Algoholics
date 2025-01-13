import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { User, UserService } from '../../services/user.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css'], // Observă "styleUrls" în loc de "styleUrl"
})
export class UsersComponent implements OnInit {
  users: User[] = [];
  selectedUser: User = {
      id: '', email: '', userAccountRole: '',
      dateCreated: '',
      userAccountGender: '',
      alias: ''
  };

  currentPage: number = 1;
  itemsPerPage: number = 8; 

  searchTerm: string = '';

  get filteredUsers() {
    if (!this.searchTerm) {
      return this.users;
    }

    const lowerCaseSearchTerm = this.searchTerm.toLowerCase();
    return this.users.filter(user =>
      user.email.toLowerCase().includes(lowerCaseSearchTerm) ||
      user.alias.toLowerCase().includes(lowerCaseSearchTerm) ||
      user.id.toString().includes(lowerCaseSearchTerm)
    );
  }


  @ViewChild('editModal', { static: true }) editModal!: TemplateRef<any>;

  constructor(
    private userService: UserService,
    private modalService: NgbModal
  ) { }

  ngOnInit() {
    this.loadUsers();
  }

  loadUsers() {
    this.userService.getUsers().subscribe((data) => {
      this.users = data;
    });
  }

  editUser(user: User) {
    this.selectedUser = { ...user };
    this.openEditModal();
  }

  openEditModal() {
    this.modalService.open(this.editModal, { ariaLabelledBy: 'modal-basic-title' });
  }

  saveUser(modal: any) {
    this.userService.updateUser(this.selectedUser).subscribe(() => {
      this.loadUsers();
      modal.close();
    });
  }

  deleteUser(id: string) {
    if (confirm('Ești sigur că dorești să ștergi acest utilizator?')) {
      this.userService.deleteUser(id).subscribe(() => {
        this.loadUsers();
      });
    }
  }
}
