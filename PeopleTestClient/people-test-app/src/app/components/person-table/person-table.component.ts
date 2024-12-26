import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { PersonService } from '../../services/person.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import {Person} from '../../models/Person';

@Component({
  selector: 'app-person-table',
  templateUrl: './person-table.component.html',
  styleUrls: ['./person-table.component.scss'],
})
export class PersonTableComponent implements OnInit {
  displayedColumns: string[] = ['id', 'idNumber', 'name', 'email', 'birthDate', 'gender', 'phone', 'actions'];
  dataSource = new MatTableDataSource<Person>();
  isEditingPerson:boolean = false;
  newPerson: Partial<Person> = {};
  selectedPerson: Person = {
    id: 0,
    idNumber: '',
    name: '',
    email: '',
    gender: '',
    phone: '',
    birthDate: '',
  };
  constructor(private personService: PersonService, private snackBar: MatSnackBar) {}

  ngOnInit(): void {
    this.fetchPeople();
  }

  fetchPeople(): void {
    this.personService.getAllPeople().subscribe({
      next: (data) => (this.dataSource.data = data,console.log(data)),
      error: () => this.snackBar.open('Failed to load people', 'Close', { duration: 3000 }),
    });
  }

  addPerson(): void {
    if (this.newPerson.name && this.newPerson.idNumber && this.newPerson.birthDate) {
      this.personService.createPerson(this.newPerson as Person).subscribe({
        next: () => {
          this.fetchPeople();
          this.newPerson = {};
          this.snackBar.open('Person added successfully', 'Close', { duration: 3000 });
        },
        error: () => this.snackBar.open('Failed to add person', 'Close', { duration: 3000 }),
      });
    } else {
      this.snackBar.open('Please fill all required fields', 'Close', { duration: 3000 });
    }
  }

  updatePerson(): void {
    if (this.selectedPerson && this.selectedPerson.name &&
      this.selectedPerson.idNumber && this.selectedPerson.birthDate) {

    this.personService.updatePerson(this.selectedPerson.id, this.selectedPerson).subscribe({
      next:
        () => {
          this.snackBar.open('Person updated successfully', 'Close', { duration: 3000 })
       , this.isEditingPerson = false, this.fetchPeople()
      },

       error: () => this.snackBar.open('Failed to update person', 'Close', { duration: 3000 }),
    });
  } else {
      this.snackBar.open('Please select a person and fill all required fields', 'Close', { duration: 3000 });
    }
  }

  deletePerson(id: number): void {
    this.personService.deletePerson(id).subscribe({
      next: () => {
        this.fetchPeople();
        this.snackBar.open('Person deleted successfully', 'Close', { duration: 3000 });
      },
      error: () => this.snackBar.open('Failed to delete person', 'Close', { duration: 3000 }),
    });
  }

  editPersonDetails(person: any): void {
    this.selectedPerson = person;
    this.selectedPerson.birthDate = new Date(person.birthDate).toISOString().split('T')[0];
    this.isEditingPerson = true;
    // Open a dialog, navigate to another page, or populate a form for editing
    console.log('Edit person:', person);
  }
}
