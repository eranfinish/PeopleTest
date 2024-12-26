import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Person } from '../models/Person';

@Injectable({
  providedIn: 'root',
})
export class PersonService {
  private baseUrl = 'https://localhost:7180/api/people'; // Update to match your API

  constructor(private http: HttpClient) {}

  getAllPeople(): Observable<Person[]> {
    return this.http.get<Person[]>(this.baseUrl);
  }

  getPersonById(id: number): Observable<Person> {
    return this.http.get<Person>(`${this.baseUrl}/${id}`);
  }

  createPerson(person: Person): Observable<Person> {
    return this.http.post<Person>(this.baseUrl, person);
  }

  updatePerson(id: number, person: Person): Observable<void> {
    return this.http.put<void>(`${this.baseUrl}/${id}`, person);
  }

  deletePerson(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
