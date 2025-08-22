# ASP.NET Core Web API – Learning Project ??

This project is a **learning playground** where I practice and implement core concepts of **ASP.NET Core Web API development**.  
It covers everything from **Entity Framework relationships** to **API design**, and **authentication & authorization** with role-based access.

---

## ?? Topics Covered

### 1. Entity Framework Core Relationships
- **One-to-One (1:1)**  
  Example: `User ? Profile`  
- **One-to-Many (1:N)**  
  Example: `User ? Posts`, `Post ? Comments`   
- **Many-to-Many (M:N)**  
  Example: `Users ? Groups` (with a join table)

---

### 2. API Building
- CRUD (Create, Read, Update, Delete) endpoints
- DTOs & AutoMapper usage
- Pagination for large datasets
- API Versioning

---

### 3. Data Handling
- **Filtering** – get specific subsets of data  
- **Sorting** – order data by fields  
- **Searching** – search by keywords  
- **Pagination** – split large results into pages  

---

### 4. Authentication & Authorization
- **JWT (JSON Web Tokens) Authentication**
- **Role-based Authorization**  
  - `Admin`, `User`, `Student` roles  
- **Login & Register** endpoints
- Secure password hashing with **ASP.NET Core Identity**

---

## ??? Tech Stack
- **ASP.NET Core 9 Web API**
- **Entity Framework Core**
- **SQL Server**
- **JWT Authentication**
- **AutoMapper**
- **Scalar (API Documentation)**

---

## ?? Getting Started

### Prerequisites
- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/0.0)
- SQL Server or PostgreSQL
- Visual Studio / VS Code

### Installation
```bash
# Clone the repository
git clone https://github.com/lemongautam79/ASPNETCoreWebAPI.git

cd aspnetcore-webapi-learning

# Restore dependencies
dotnet restore

# Run migrations
Add-Migration "<migration_name>"
Update-database

# Run the API
dotnet run
