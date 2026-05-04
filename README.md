# JobTracker Pro

![.NET Core](https://img.shields.io/badge/.NET%2010-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![SQLite](https://img.shields.io/badge/SQLite-07405E?style=for-the-badge&logo=sqlite&logoColor=white)
![Azure](https://img.shields.io/badge/azure-%230072C6.svg?style=for-the-badge&logo=microsoftazure&logoColor=white)
![JavaScript](https://img.shields.io/badge/javascript-%23323330.svg?style=for-the-badge&logo=javascript&logoColor=%23F7DF1E)

A full-stack job application tracking system built from the ground up to demonstrate modern backend architecture, data security, and seamless API integration.

**Live Demo:** [Click here to view the live deployment](https://marcelos-jobtracker.azurewebsites.net)

## 🚀 Features
- **RESTful API:** Fully functional CRUD endpoints (`GET`, `POST`, `PUT`, `DELETE`).
- **Data Security:** Implements Data Transfer Objects (DTOs) to prevent over-posting vulnerabilities and secure sensitive database columns.
- **ORM Integration:** Uses Entity Framework Core with code-first migrations for dynamic SQLite database generation.
- **Responsive Frontend:** A sleek, dark-mode vanilla JavaScript SPA (Single Page Application) that communicates asynchronously via the Fetch API.
- **Automated CI/CD:** Integrated with GitHub Actions for automated building and deployment to Microsoft Azure.

## 🧠 Technical Architecture
This project intentionally avoids heavy scaffolding tools to showcase a deep understanding of core mechanics:
- **Dependency Injection:** Database contexts are injected into the controllers to maintain loose coupling.
- **Asynchronous Operations:** All database calls utilize `async/await` to prevent thread blocking and ensure scalability.
- **Stateless Communication:** The frontend operates entirely independently, fetching state directly from the REST API without page reloads.

## 🛠️ Tech Stack
* **Backend:** C#, ASP.NET Core (.NET 10)
* **Database:** SQLite, Entity Framework Core (EF Core)
* **Frontend:** HTML5, CSS3, Vanilla JavaScript
* **Hosting/Deployment:** Microsoft Azure App Service, GitHub Actions

## 💻 Running Locally

### Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download)

### Setup
1. Clone the repository:
   ```bash
   git clone https://github.com/ml986318/JobTrackerApi.git
   cd JobTrackerApi
   ```
2. Build and run the server (Entity Framework will automatically build the SQLite database on startup):
   ```bash
   dotnet run
   ```
3. Open a browser and navigate to the local Frontend UI to view the dashboard!

## 👨‍💻 Developer
Built by Marcelo Legaspi.
