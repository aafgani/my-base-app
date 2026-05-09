[Back to ReadMe](../README.md)

# 📦 Overview

SuperApp initially starts as a Money Manager XLS/XLSX importer.

The application allows users to upload exported financial reports from mobile finance apps, parse the transactions, store them into SQL Server, and generate custom dashboards and reports.

This project is also used as a playground for exploring:

- Cloud-native architecture
- Azure services
- Event-driven design
- DevOps practices
- Modern .NET development

## Architecture

```
User Upload
↓
ASP.NET Core Minimal API
↓
Excel Parser (ClosedXML)
↓
SQL Server
↓
Azure Queue Storage
↓
Azure Function
↓
Email Notification
```

## Repository Structure

```
SuperApp/
├── src/
│ ├── api/
│ ├── database/
│ ├── shared/
│ └── worker/
├── docs/
├── infra/
├── samples/
└── superapp.code-workspace

```

## Tech Stack

| Area                  | Technology               |
| --------------------- | ------------------------ |
| Backend API           | ASP.NET Core Minimal API |
| Database              | SQL Server               |
| ORM                   | Entity Framework Core    |
| SQL Project           | SDK-style SQL Project    |
| Excel Reader          | ClosedXML                |
| Background Processing | Azure Functions          |
| Queue                 | Azure Queue Storage      |
| Dashboard             | AdminLTE                 |
| Infrastructure        | Bicep                    |
| Containerization      | Docker                   |
| CI/CD                 | GitHub Actions           |
