# Credit-card-using-Asp.net
# 💳 Secure & Dynamic Credit Card Registration System using ASP.NET Razor Pages (C#)

![WhatsApp Image 2025-05-20 at 20 14 34](https://github.com/user-attachments/assets/2b2e0cfb-3ab2-493c-a146-33dcc69b9dd7)
![WhatsApp Image 2025-05-20 at 20 14 34 (1)](https://github.com/user-attachments/assets/b006afbc-2fe3-480d-b228-f84f210f794c)
![WhatsApp Image 2025-05-20 at 20 14 34 (2)](https://github.com/user-attachments/assets/8bdf9ffd-915c-4ea2-bf75-39f5c345c6bd)

![Screenshot 2025-05-20 at 8 15 22 PM](https://github.com/user-attachments/assets/f9be4e43-14c0-4bea-a99b-6cbdba2d172c)

## 📌 Project Overview

This project is a **secure, multi-page web-based Credit Card Registration System** developed using **ASP.NET Core Razor Pages** with **C#**, designed for **ABC Bank**. It follows best practices in web development, data validation, and secure user input handling. The system dynamically interacts with a relational database using **Entity Framework Core** or **ADO.NET**, and implements **user-friendly UI** components along with secure **file upload** functionality.


---

## 🛠️ Technologies Used

- ASP.NET Core Razor Pages (.NET 6/.NET 7)
- C#
- Entity Framework Core / ADO.NET
- Microsoft SQL Server
- Visual Studio 2022
- HTML, CSS, Bootstrap
- Cookies & Sessions

---

## ⚙️ Features

- ✅ **Form Validation & Input Handling**
  - Required Field Validator
  - Regular Expression Validator
  - Compare Validator
  - Range Validator

- 📄 **Multi-Page Registration Flow**
  - Page 1: User Information
  - Page 2: Confirmation
  - Page 3: Submission and Thank You

- 📚 **Database Integration**
  - Relational database with Primary and Foreign Keys
  - Dynamic loading of options (DropDownList, CheckBoxList, RadioButtonList)

- 🗂️ **File Upload & Secure Storage**
  - Upload and store documents (e.g., proof of identity)
  - Save files securely in the database or local file system

- 🖥️ **Modern UI with 10+ Controls**
  - TextBox, DropDownList, RadioButtonList, CheckBoxList, FileUpload, etc.

- 🔐 **Security & Session Handling**
  - ASP.NET Session and Cookie Management
  - Anti-forgery protection and input sanitization

---

## 🧩 User Interface Controls Used (10+)

- `TextBox`
- `DropDownList`
- `RadioButtonList`
- `CheckBoxList`
- `FileUpload`
- `Button`
- `Label`
- `ValidationSummary`
- `Calendar`
- `Panel`

---

## 🏗️ Database Structure

- **Users Table**
  - `UserId` (PK)
  - `FullName`
  - `Email`
  - `DOB`
  - `CardTypeId` (FK)
  - `UploadedDocument`

- **CardTypes Table**
  - `CardTypeId` (PK)
  - `CardTypeName`

> Additional tables for dropdown/checkbox/radio list options can be added as needed.

---

## 🔑 How to Run This Project

1. Clone the repository:

```bash
git clone https://github.com/praveenarjun/Credit-card-using-Asp.net.git
cd credit-card-registration-system
