# Wasla API

## Overview
Wasla API is a web API developed using **ASP.NET Core 8.0**. It provides endpoints to assist travelers in navigating the best possible routes between different locations in **Egypt's governorates**. The API is secured using **JWT authentication** and **role-based authorization**, ensuring a secure and well-managed system. Additionally, it includes **health check endpoints**, comprehensive **Swagger documentation**, and a structured **database with seed data**.

### **Developed By:** Ahmed Fahmy

## **Features**
- **JWT Authentication & Role-based Authorization**
- **Admin Dashboard for managing travel data**
- **CRUD operations for Government, Region, and Available Regions**
- **User-friendly search functionality**
- **Health check endpoints for monitoring system status**
- **Swagger documentation for easy API exploration**
- **Database seeding with predefined data**
- **Custom middleware for enhanced security**
- **Performance optimizations for better scalability**

---

## **Prerequisites**
Before running the API, ensure you have the following installed:

- **.NET 8 SDK**
- **SQL Server**
- **Visual Studio 2022** or later

---

## **Getting Started**

### **1. Clone the Repository**
```sh
 git clone https://github.com/Ahmedfahmy8308/Wasla-Api
 cd wasla-api
```

### **2. Configure Environment**
Update `appsettings.json` or `appsettings.Development.json` with your database connection string and JWT settings.

### **3. Build and Run the Application**
1. Open the solution in **Visual Studio**.
2. Build the solution to restore dependencies.
3. Run the application using **HTTPS**.

### **4. Apply Database Migrations & Seed Data**
```sh
Update-Database
```
This will create the database schema and seed it with predefined **roles, an admin account, and travel data**.

---

## **API Endpoints**

### **Authentication**
| Endpoint | Method | Description |
|----------|--------|-------------|
| `/api/account/register` | `POST` | Register a new user |
| `/api/account/login` | `POST` | Authenticate and get a JWT token |

### **Admin Endpoints** (Requires Authentication & Admin Role)
| Endpoint | Method | Description |
|----------|--------|-------------|
| `/api/admin/government` | `GET` | Retrieve all governments |
| `/api/admin/government` | `POST` | Add a new government |
| `/api/admin/government` | `PUT` | Update government details |
| `/api/admin/government` | `DELETE` | Delete a government |
| `/api/admin/region` | `GET` | Retrieve all regions |
| `/api/admin/region` | `POST` | Add a new region |
| `/api/admin/region` | `PUT` | Update region details |
| `/api/admin/region` | `DELETE` | Delete a region |
| `/api/admin/availableregion` | `GET` | Retrieve all available regions |
| `/api/admin/availableregion` | `POST` | Add an available region |
| `/api/admin/availableregion` | `PUT` | Update available region details |
| `/api/admin/availableregion` | `DELETE` | Delete an available region |

### **User Endpoints**
| Endpoint | Method | Description |
|----------|--------|-------------|
| `/api/user/governments` | `GET` | Get a list of all governments |
| `/api/user/government/search/{word}` | `GET` | Search for a government |
| `/api/user/regions/{governmentId}` | `GET` | Get regions within a specific government |
| `/api/user/region/search/{word}` | `GET` | Search for a region |
| `/api/user/availableregions/{regionId}` | `GET` | Get available regions within a region |
| `/api/user/availableregion/search/{word}` | `GET` | Search for an available region |

### **Health Check Endpoints**
| Endpoint | Method | Description |
|----------|--------|-------------|
| `/api/health` | `GET` | Check if the API is running |
| `/api/health/db` | `GET` | Verify database connectivity |
| `/api/health/system` | `GET` | Get system health status (CPU & memory usage) |
| `/api/health/disk-space` | `GET` | Check available disk space |

---

## **Default Admin Credentials**
- **Username:** `Admin@wasla.com`
- **Password:** `Admin123!`

*You must login first to obtain a JWT token before accessing admin endpoints.*

---

## **Swagger Documentation**
Swagger is enabled in **development mode**. You can explore the API using the following URL:

📌 **Swagger UI:** [https://localhost:7178/swagger/index.html](https://localhost:7178/swagger/index.html)

---

## **Deployment & Hosting**
To deploy the API on a live server:
1. **Publish the API** using Visual Studio.
2. **Deploy it to a cloud provider** (e.g., **Azure**, **AWS**, **SmarterASP.NET**).
3. **Configure environment variables** (e.g., connection string, JWT settings).
4. **Ensure HTTPS is enabled** for secure communication.

---

## **Contributing**
Feel free to contribute by:
- Reporting bugs 🐞
- Suggesting new features 🚀
- Submitting pull requests 🔥

---

## **License**
This project is **open-source** and available under the **MIT License**.

---

## **Contact & Support**
For support or inquiries, contact **Ahmed Fahmy** via:
📩 Email: [fhmy8308@gmail.com](mailto:fhmy8308@gmail.com)  
🌐 GitHub: [AhmedFahmy8308](https://github.com/Ahmedfahmy8308)

---

### 🔥 *Happy Coding!* 🚀

