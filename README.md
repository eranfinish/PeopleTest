# PeopleTest Project

## Overview
The **PeopleTest Project** is a web application designed to manage a database of people. It features an Angular front-end, a .NET 6 API backend, and a SQL Server database. The project showcases CRUD operations, two-way data binding, and integration with Material Design components.

## Features

### Frontend (Angular)
- **Two-way data binding**: Implemented using Angular's FormsModule and Material Design components.
- **Responsive UI**: Built with Angular Material components for a modern look.
- **CRUD Operations**: 
  - Add, edit, view, and delete people records.
  - Gender selection using a dropdown menu (e.g., Male/Female).
- **Validation**: Form fields include validation to ensure data integrity.

### Backend (ASP.NET Core 6 API)
- **Endpoints**: RESTful API built with ASP.NET Core.
  - Create, read, update, and delete (CRUD) endpoints for managing people.
- **Database Integration**: Uses Entity Framework Core for database management.
- **Migrations**: Database schema changes are managed using EF Core migrations.

### Database (SQL Server)
- **Schema**: Contains tables to store person details.
- **Stored Procedures**: Includes SQL procedures for optimized data access.

## Getting Started

### Prerequisites
- **Frontend**:
  - Node.js (v14+)
  - Angular CLI
- **Backend**:
  - .NET 6 SDK
  - SQL Server
- **Database**:
  - A running instance of SQL Server

### Installation
1. **Clone the Repository**:
   ```bash
   git clone https://github.com/your-username/PeopleTest.git
   cd PeopleTest
   ```

2. **Set up the Backend**:
   - Navigate to the backend project folder:
     ```bash
     cd PeopleTestServer/PeopleTest/PeopleTest.API
     ```
   - Update the connection string in `appsettings.json`.
   - Apply migrations:
     ```bash
     dotnet ef database update --startup-project ../PeopleTest.API
     ```
   - Run the API:
     ```bash
     dotnet run
     ```

3. **Set up the Frontend**:
   - Navigate to the frontend project folder:
     ```bash
     cd PeopleTestUI
     ```
   - Install dependencies:
     ```bash
     npm install
     ```
   - Run the application:
     ```bash
     ng serve
     ```

4. **Access the Application**:
   - Open your browser and go to `http://localhost:4200`.

## Project Structure

### Backend
- **PeopleTest.API**: Contains the API controllers and configurations.
- **PeopleTest.DAL**: Data Access Layer using Entity Framework Core.

### Frontend
- **Components**:
  - `person-table`: Displays a list of people.
  - `person-form`: Form for adding and editing people.
- **Services**:
  - `PersonService`: Handles API communication.

## Known Issues
- **Material Design Error**: Ensure that `mat-form-field` wraps a `MatFormFieldControl` (e.g., `<mat-select>` or `<input>`).

## Contributing
Contributions are welcome! Please follow the steps below:
1. Fork the repository.
2. Create a new branch (`feature/my-feature`).
3. Commit your changes.
4. Push to the branch.
5. Open a pull request.

## License
This project is licensed under the [MIT License](LICENSE).

---
Feel free to customize this README to suit your project’s specifics!
