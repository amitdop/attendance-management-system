# 🏗️ System Architecture

## Overview

The Attendance Management System is built using a layered architecture pattern with ASP.NET Web Forms and SQL Server. This document describes the system architecture, components, and design patterns.

---

## 🏛️ Architectural Layers

```
┌─────────────────────────────────────────┐
│       Presentation Layer (UI)           │
│   - ASP.NET Web Forms (.aspx)           │
│   - HTML, CSS, JavaScript               │
└──────────────┬──────────────────────────┘
               │
┌──────────────┴──────────────────────────┐
│    Business Logic Layer (BLL)           │
│   - Service Classes                     │
│   - Business Rules                      │
│   - Validation Logic                    │
└──────────────┬──────────────────────────┘
               │
┌──────────────┴──────────────────────────┐
│   Data Access Layer (DAL)               │
│   - Database Queries                    │
│   - Entity Operations                   │
│   - Connection Management               │
└──────────────┬──────────────────────────┘
               │
┌──────────────┴──────────────────────────┐
│      Database Layer (SQL Server)        │
│   - Tables, Views, Stored Procedures    │
│   - Indexes, Constraints                │
└─────────────────────────────────────────┘
```

---

## 📁 Project Structure

```
attendance-management-system/
│
├── App_Code/                          # Business Logic & Utilities
│   ├── Services/                      # Service classes
│   │   ├── AttendanceService.cs
│   │   ├── StudentService.cs
│   │   ├── TeacherService.cs
│   │   ├── AdminService.cs
│   │   └── ReportService.cs
│   │
│   ├── Models/                        # Data models
│   │   ├── Student.cs
│   │   ├── Teacher.cs
│   │   ├── Attendance.cs
│   │   └── Class.cs
│   │
│   ├── Utilities/                     # Helper classes
│   │   ├── DatabaseHelper.cs
│   │   ├── ValidationHelper.cs
│   │   └── SecurityHelper.cs
│   │
│   └── Constants/                     # Application constants
│       └── AppConstants.cs
│
├── Attendance_Data/                   # Data Access Layer
│   ├── StudentData.cs
│   ├── TeacherData.cs
│   ├── AttendanceData.cs
│   ├── ClassData.cs
│   └── SubjectData.cs
│
├── Pages/                             # Presentation Layer
│   ├── Admin/
│   │   ├── Dashboard.aspx
│   │   ├── ManageStudents.aspx
│   │   ├── ManageTeachers.aspx
│   │   └── Reports.aspx
│   │
│   ├── Teacher/
│   │   ├── Dashboard.aspx
│   │   ├── MarkAttendance.aspx
│   │   └── ViewReports.aspx
│   │
│   ├── Student/
│   │   ├── Dashboard.aspx
│   │   ├── ViewAttendance.aspx
│   │   └── DownloadCertificate.aspx
│   │
│   ├── Auth/
│   │   ├── Login.aspx
│   │   ├── Logout.aspx
│   │   └── ChangePassword.aspx
│   │
│   └── Default.aspx
│
├── CSS/                               # Stylesheets
│   ├── style.css
│   ├── bootstrap.css
│   └── responsive.css
│
├── Scripts/                           # JavaScript files
│   ├── jquery.js
│   ├── validation.js
│   └── utils.js
│
├── Database/                          # SQL Scripts
│   ├── schema.sql                     # Table definitions
│   ├── stored_procedures.sql
│   ├── sample_data.sql
│   └── indexes.sql
│
├── Web.config                         # Application configuration
├── Global.asax                        # Application events
├── Master.Master                      # Master page
└── README.md
```

---

## 🔄 Data Flow

### User Request Flow

```
1. User Request (Browser)
   └─> HTTP Request
       └─> ASP.NET Page (.aspx)
           └─> Code Behind (.aspx.cs)
               └─> Service Layer (BLL)
                   └─> Data Access Layer (DAL)
                       └─> Database Query
                           └─> SQL Server
                               └─> Result Set
                                   └─> Back to DAL
                                       └─> Back to Service
                                           └─> Back to Code Behind
                                               └─> Render HTML
                                                   └─> HTTP Response
                                                       └─> Browser Renders Page
```

---

## 🗄️ Database Schema

### Core Tables

#### Users Table
```sql
Users
├── UserID (PK)
├── Username (Unique)
├── PasswordHash
├── Email
├── RoleID (FK)
├── IsActive
├── CreatedDate
└── LastLoginDate
```

#### Students Table
```sql
Students
├── StudentID (PK)
├── UserID (FK)
├── RollNumber (Unique)
├── ClassName
├── EnrollmentDate
├── Status
└── ContactNumber
```

#### Teachers Table
```sql
Teachers
├── TeacherID (PK)
├── UserID (FK)
├── EmployeeID (Unique)
├── Department
├── JoiningDate
└── Qualifications
```

#### Attendance Table
```sql
Attendance
├── AttendanceID (PK)
├── StudentID (FK)
├── SubjectID (FK)
├── AttendanceDate
├── Status (Present/Absent)
├── MarkedByTeacherID (FK)
└── Remarks
```

#### Classes Table
```sql
Classes
├── ClassID (PK)
├── ClassName (Unique)
├── Capacity
├── ClassTeacherID (FK)
└── CreatedDate
```

#### Subjects Table
```sql
Subjects
├── SubjectID (PK)
├── SubjectName
├── TeacherID (FK)
├── ClassID (FK)
├── Credits
└── Description
```

---

## 🔐 Security Architecture

### Authentication & Authorization

```
Login Request
    │
    ├─> Validate Credentials
    │   └─> Check against Users table
    │
    ├─> Verify Role & Permissions
    │   └─> Load Role-based Access Control
    │
    ├─> Create Session
    │   └─> Store in Session/Cookie
    │
    └─> Redirect to Dashboard
        └─> Verify permissions on each page
```

### Key Security Measures

- ✅ **Password Hashing** - Passwords stored as hashes (not plain text)
- ✅ **Session Management** - Secure session tokens
- ✅ **SQL Injection Prevention** - Parameterized queries
- ✅ **Role-Based Access Control** - Different permissions per role
- ✅ **Input Validation** - All user inputs validated
- ✅ **CSRF Protection** - Anti-CSRF tokens in forms
- ✅ **Secure Headers** - HTTP security headers configured

---

## 🔄 Key Workflows

### Attendance Marking Workflow

```
Teacher Login
    │
    └─> View Classes/Subjects
        │
        └─> Select Class
            │
            └─> Load Students List
                │
                └─> Mark Attendance
                    │
                    ├─> Validate Input
                    │
                    └─> Save to Database
                        │
                        └─> Send Confirmation
```

### Report Generation Workflow

```
Request Report
    │
    ├─> Get Report Type
    │
    ├─> Fetch Data from DB
    │   └─> Apply Filters & Calculations
    │
    ├─> Process Data
    │   └─> Calculate Percentages
    │
    ├─> Generate Report
    │   ├─> Format Data
    │   └─> Create Document
    │
    └─> Return to User
        └─> Download/View
```

---

## 🎯 Design Patterns Used

### 1. **Layered Architecture**
- Separation of concerns
- Independent layer development
- Easy to test and maintain

### 2. **MVC Pattern** (in code-behind)
- Model: Data objects
- View: .aspx pages
- Controller: Code-behind logic

### 3. **Singleton Pattern**
- Database connection pooling
- Configuration management

### 4. **Repository Pattern**
- Data Access Layer abstraction
- Consistent data access methods

### 5. **Service Locator Pattern**
- Dependency injection
- Loose coupling

---

## 📊 Performance Considerations

### Database Optimization
- ✅ **Indexes** on frequently queried columns
- ✅ **Foreign Keys** for referential integrity
- ✅ **Connection Pooling** for performance
- ✅ **Stored Procedures** for complex queries
- ✅ **Query Optimization** with proper SQL

### Caching Strategy
- Cache frequently accessed data
- Invalidate on updates
- Use Application-level caching

### Page Performance
- ✅ Minimal postbacks
- ✅ Efficient query execution
- ✅ Compressed static assets
- ✅ Pagination for large datasets

---

## 🔌 Integration Points

### External Systems (if applicable)
- Email notifications (SMTP)
- SMS alerts (if needed)
- Excel exports
- PDF report generation

---

## 📈 Scalability

### Current Approach
- Single-server deployment
- Centralized database

### Future Scalability Options
- Load balancing for web servers
- Database replication
- Caching layer (Redis)
- Microservices architecture
- Cloud deployment

---

## 🛠️ Technology Stack

| Layer | Technology |
|-------|-----------|
| Frontend | HTML5, CSS3, JavaScript |
| Backend | C#, ASP.NET Web Forms |
| ORM | ADO.NET |
| Database | SQL Server |
| Server | IIS |
| Framework | .NET Framework 4.7.2+ |

---

## 📋 Deployment Architecture

```
┌─────────────────┐
│   End Users     │
│   (Browser)     │
└────────┬────────┘
         │ HTTPS
┌────────┴────────┐
│   IIS Server    │
│  (Web Server)   │
└────────┬────────┘
         │ TCP
┌────────┴─────────────┐
│  SQL Server         │
│  (Database Server)  │
└─────────────────────┘
```

---

## 🔄 Deployment Strategy

- **Development** - Local SQL Server + IIS
- **Testing** - Test environment with copy of prod data
- **Staging** - Pre-production environment
- **Production** - Live server with full data

---

## 📚 Related Documentation

- [README.md](README.md) - Project overview
- [CONTRIBUTING.md](CONTRIBUTING.md) - Contribution guidelines
- Database schema documentation
- API/Service documentation

---

**Last Updated:** July 2026
