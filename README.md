📚 Library Management System

A full-featured Library Management System built with ASP.NET Core Web API and SQL Server using Entity Framework Core.
This project provides role-based access (Admin, Librarian, Member), JWT Authentication, and Swagger API documentation.





🚀 Features

🔑 Authentication & Authorization (JWT-based)

👨‍💼 Role Management (Admin, Librarian, Member)

📖 Book Management (Add, Update, Delete, Search)

🔄 Borrow & Return Transactions

👥 User Management

📊 API Documentation with Swagger

🗂 Database Integration with EF Core & SQL Server




🛠 Tech Stack

Backend: ASP.NET Core Web API

Database: SQL Server

ORM: Entity Framework Core

Authentication: JWT (JSON Web Token)

Documentation: Swagger

Tools: Visual Studio, Postman, Git




📂 Project Structure

LibraryManagementSystem/
│-- Controllers/        # API Controllers  
│-- Models/             # Entity models  
│-- Data/               # DbContext and Migrations  
│-- Services/           # Business logic layer  
│-- Repositories/       # Data access layer  
│-- DTOs/               # Data Transfer Objects  
│-- Program.cs          # Application startup  
│-- appsettings.json    # Configurations





⚙ Setup & Installation

1. Clone the repository:

 git clone
 https://github.com/Sayali-1710/PROJECT--LIBRARY_MANAGEMENT_SYSTEM


2. Update appsettings.json with your SQL Server connection string.


3. Run migrations:

   dotnet ef database update


4. Start the project:

   dotnet run


5. Open Swagger at:

  http://localhost:5243/swagger/index.html



🧪 API Testing

  Use Swagger UI or Postman Collection (included in repo).

  Example login request:

  {
   "username": "admin",
   "password": "admin123"
  }





🔑 User Roles

  Role	Permissions

  Admin	Manage books, users, system settings
  Librarian	Issue/return books, manage users
  Member	Search, borrow, return books





🏆 Why This Project is Special?

  ✅ Follows Clean Architecture (Controller → Service → Repository → DB)

  ✅ JWT-secured APIs like in real-world enterprise apps

  ✅ Perfect for learning ASP.NET Core Web API + SQL Server + EF Core

  ✅ Ready-to-use for college projects or portfolio showcase





🤝 Contribution

   Contributions are welcome! Please fork the repo and create a pull request.
   
## 👨‍💻 Collaborators

- [Sayali Todkar](https://github.com/Sayali-1710)
- [Vaibhavi Mogare](https://github.com/VaibhaviMogare)
  
