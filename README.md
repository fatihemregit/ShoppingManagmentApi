# 🛒 Shopping Management API

[![DotNet](https://img.shields.io/badge/.NET-5.0+-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![License](https://img.shields.io/badge/license-MIT-green)](LICENSE)

[**English**](https://github.com/fatihemregit/ShoppingManagmentApi/blob/master/README.md) | [**Türkçe**](https://github.com/fatihemregit/ShoppingManagmentApi/blob/master/Docs/README_TR.md)
## 🇺🇸 English

### 📝 Project Overview
**Shopping Management API** is a specialized backend solution developed to eliminate the "manual calculator struggle" during grocery shopping. It allows users to track product prices in real-time by scanning barcodes and automatically calculates the total amount of the shopping cart.

### 💡 The Story Behind the Project (Personal Problem)
This project was born out of a real-life necessity. While shopping, calculating the total price of products one by one using a standard calculator app is tedious and inefficient.

I developed this API to solve this exact problem. Currently, it works in tandem with a private mobile application. The workflow is simple: I scan the product's barcode; if the price has changed, I update it instantly, and the system calculates the total for my current session. This combination turns a manual, tiring process into a seamless digital experience.

### 🚀 Usage Scenario
1.  **At the Store:** You pick up a product and scan its barcode via the mobile app.
2.  **Instant Sync:** The app fetches the latest price from this API.
3.  **Price Update:** If you notice the shelf price is different from the system, you update it with one click.
4.  **Live Total:** As you add more items, the API keeps track of the "Shopping Session" and gives you the final amount before you even reach the checkout counter.

### 🛠 Tech Stack
* **Framework:** .NET / ASP.NET Core
* **Database:** PostgreSQL / MS SQL Server
* **ORM:** Entity Framework Core
* **Architecture:** RESTful API

### 🔧 Installation & Setup
1.  **Clone the repo:**
    ```bash
    git clone [https://github.com/fatihemregit/ShoppingManagmentApi.git](https://github.com/fatihemregit/ShoppingManagmentApi.git)
    ```
2.  **Configuration:** Update the `appsettings.json` file with your database connection string.
3.  **Apply Migrations:**
    ```bash
    dotnet ef database update
    ```
4.  **Run the project:**
    ```bash
    dotnet run
    ```

### 🗺 Future Roadmap
* **Refactoring:** Improving code quality and performance.
* **Price Analytics:** Tracking price inflation over time (e.g., calculating the price change percentage of a specific snack between January 2025 and June 2025).
* **Advanced Statistics:** Monthly spending reports and category-based analysis.
### Project Log
[English Project Log Here](https://github.com/fatihemregit/ShoppingManagmentApi/blob/master/Docs/projectLogs/EN_project_log.md)

Developed by [Fatih Emre KILINÇ](https://github.com/fatihemregit)