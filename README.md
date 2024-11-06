# Driving License Management System (DVLD)

**Driving License Management System (DVLD)** is a C# application built using the .NET Framework, ADO.NET, and WinForms. This system streamlines the process of managing driver and vehicle licenses, enabling regulatory bodies to efficiently handle license issuance, renewal, replacement, and blocking.

## Features

### 1. License Services
- **New License Issuance**: Applicants select a license category (e.g., motorcycles, commercial vehicles) and go through required testing steps.
- **Renewal**: Supports license renewals with mandatory vision tests.
- **Replacement**:
  - **Lost License Replacement**: Issues a replacement for a lost license.
  - **Damaged License Replacement**: Issues a replacement for a damaged license.
- **International License Issuance**: Available for standard license holders; issues internationally recognized licenses.
- **License Unblocking**: Unblocks licenses upon fine payment and administrative approval.

### 2. License Categories
Each license class has specific age, validity, and fee requirements:
- **Category 1**: Small Motorcycles – Age 18+, valid for 5 years.
- **Category 2**: Heavy Motorcycles – Age 21+, valid for 5 years.
- **Category 3**: Light Vehicles – Age 18+, valid for 10 years.
- **Category 4**: Commercial Vehicles – Age 21+, valid for 10 years.
- **Category 5**: Agricultural Vehicles – Age 21+, valid for 10 years.
- **Category 6**: Small/Medium Buses – Age 21+, valid for 10 years.
- **Category 7**: Heavy Trucks and Vehicles – Age 21+, valid for 10 years.

### 3. Applicant Requirements
- **Eligibility**: Each license category has age and qualification criteria.
- **Documentation**: Includes ID and proof of completed driving training.
- **Testing**: Sequentially completes medical, theoretical, and practical exams.

### 4. Administration
Comprehensive administrative features include:
- **User Management**: Manages system users, assigning roles and permissions.
- **Person Management**: Maintains applicant details, ensuring unique IDs.
- **Application Management**: Tracks applications, statuses, and updates.
- **Test and Fee Management**: Adjusts fees and requirements for each test type.
- **License Blocking**: Manages license suspension, recording block/unblock reasons and dates.

## Technical Specifications

- **Technology Stack**:
  - **Language**: C#
  - **Framework**: .NET Framework
  - **Database Access**: ADO.NET
  - **User Interface**: WinForms

- **Database Interaction**:
  - Database operations are performed using ADO.NET for data access and management.
  - Supports CRUD operations on applicants, licenses, and applications.

- **Request Information**:
  - Tracks request number, date, applicant ID, request type, status, and fees.

## Database Setup

To set up the **DVLD** database, follow these steps using SQL Server Management Studio (SSMS) to restore from the `DVLD.bak` file.

### Steps to Restore the Database

1. **Open SQL Server Management Studio (SSMS)** and connect to your SQL Server instance.
2. In the **Object Explorer**, right-click on **Databases** and select **Restore Database...**.
3. In the **Restore Database** dialog:
   - Under **Source**, select **Device**, then click **[...]** to browse.
   - Click **Add** and navigate to your `DVLD.bak` file to select it.
4. Under **Destination**, ensure the **Database** name is set to **DVLD** (or a name that aligns with your project).
5. Review the **Files** and **Options** tabs to confirm paths and settings as necessary.
6. Click **OK** to restore the database.

### Update Connection String

After restoring, update your application's connection string to connect to the `DVLD` database. Here’s an example connection string format to use in your C# project:

```csharp
string connectionString = "Data Source=YourServerName;Initial Catalog=DVLD;Integrated Security=True;";
