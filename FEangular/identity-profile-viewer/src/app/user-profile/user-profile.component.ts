import { Component, OnInit } from '@angular/core';
import { UserService, UserIdentity } from '../user.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common'; 


@Component({
  selector: 'app-user-profile',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './user-profile.component.html'
})
export class UserProfileComponent implements OnInit {
  user: UserIdentity | null = null;
  fullName: string = '';
  email: string = '';
  message: string = '';

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    const userId = 1; 
    this.userService.getUser(userId).subscribe({
      next: (data) => {
        console.log("data",data)
        this.user = data;
        this.fullName = data.fullName;
        this.email = data.email;
      },
      error: (err) => {
        this.message = 'Error fetching user data.';
      }
    });
  }

  updateUser(): void {
    if (!this.user) return;

    const patchData = {
      id: this.user.id,
      fullName: this.fullName,
      email: this.email
    };
    console.log("id",this.user.id)
    this.userService.updateUser(this.user.id, patchData).subscribe({
      next: () => {
        this.message = 'User updated successfully.';
      },
      error: () => {
        this.message = 'Error updating user.';
      }
    });
  }
}