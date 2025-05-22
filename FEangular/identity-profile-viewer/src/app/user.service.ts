import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface UserIdentity {
  id: number;
  userId: string;
  fullName: string;
  email: string;
  sourceSystem: string;
  lastUpdated: string;
  isActive: boolean;
}

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiUrl = 'http://localhost:5265/api/identities';

  constructor(private http: HttpClient) { }

  getUser(id: number): Observable<UserIdentity> {
    return this.http.get<UserIdentity>(`${this.apiUrl}/${id}`);
  }

  updateUser(id: number, patchData: any): Observable<any> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json-patch+json' });
    return this.http.patch(`${this.apiUrl}/${id}`, patchData, { headers });
  }
}