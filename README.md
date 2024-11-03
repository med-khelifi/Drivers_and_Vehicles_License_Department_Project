Driving License Management System (DVLD)
Driving License Management System (DVLD) is a C# application built using the .NET Framework, ADO.NET, and WinForms. This system streamlines the process of managing driver and vehicle licenses, enabling regulatory bodies to efficiently handle license issuance, renewal, replacement, and blocking.

Features
1. License Services
New License Issuance: Applicants select a license category (e.g., motorcycles, commercial vehicles) and go through required testing steps.
Renewal: Supports license renewals with mandatory vision tests.
Replacement:
Lost License Replacement: Issues a replacement for a lost license.
Damaged License Replacement: Issues a replacement for a damaged license.
International License Issuance: Available for standard license holders; issues internationally recognized licenses.
License Unblocking: Unblocks licenses upon fine payment and administrative approval.
2. License Categories
Each license class has specific age, validity, and fee requirements:

Category 1: Small Motorcycles – Age 18+, valid for 5 years.
Category 2: Heavy Motorcycles – Age 21+, valid for 5 years.
Category 3: Light Vehicles – Age 18+, valid for 10 years.
Category 4: Commercial Vehicles – Age 21+, valid for 10 years.
Category 5: Agricultural Vehicles – Age 21+, valid for 10 years.
Category 6: Buses – Age 21+, valid for 10 years.
Category 7: Heavy Trucks – Age 21+, valid for 10 years.
3. Applicant Requirements
Eligibility: Each license category has age and qualification criteria.
Documentation: Includes ID and proof of completed driving training.
Testing: Sequentially completes medical, theoretical, and practical exams.
4. Administration
Comprehensive administrative features include:

User Management: Manages system users, assigning roles and permissions.
Person Management: Maintains applicant details, ensuring unique IDs.
Application Management: Tracks applications, statuses, and updates.
Test and Fee Management: Adjusts fees and requirements for each test type.
License Blocking: Manages license suspension, recording block/unblock reasons and dates.
Technical Specifications
Technology Stack:

Language: C#
Framework: .NET Framework
Database Access: ADO.NET
User Interface: WinForms
Database Interaction:

Database operations are performed using ADO.NET for data access and management.
Supports CRUD operations on applicants, licenses, and applications.
Request Information:

Tracks request number, date, applicant ID, request type, status, and fees.
Getting Started
Clone the Repository: git clone [repository URL]
Set Up Database: Configure your SQL Server database as per the system requirements.
Update Connection Strings: Set the database connection strings in the application configuration file.
Run the Application: Launch the application in Visual Studio to begin managing licenses.
Usage
This application is tailored for regulatory authorities aiming to manage the licensing process with improved oversight, efficient workflow, and compliance with road safety standards.

