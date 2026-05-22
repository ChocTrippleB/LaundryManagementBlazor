# SparkClean – Laundry Management System

## Project Overview

SparkClean is a Laundry Pickup & Delivery web application developed for the ONT401 Assignment.

Built with **Blazor Server (.NET 8.0)**, the system demonstrates six software design patterns through an interactive laundry ordering and tracking platform with four distinct user roles.

Customers can:
- Book laundry services through a 4-step order wizard
- Select laundry packages and service types
- Add custom extras (stain removal, perfume treatment)
- Pay via Credit Card or EFT
- Track order status and receive real-time notifications

---

## Group Members

| Name      | Responsibility                        |
|-----------|---------------------------------------|
| Marcellos | Singleton + Project Setup             |
| Rohit     | Factory Method + Abstract Factory     |
| Amity     | Strategy Pattern                      |
| Bantu     | Observer Pattern                      |
| Jodi      | Decorator Pattern                     |
| All       | Documentation                         |

---

## Technologies Used

- C# / .NET 8.0
- Blazor Server (Interactive Server render mode)
- Bootstrap 5
- Visual Studio 2022
- GitHub

---

## Design Patterns Implemented

| Pattern          | Location                    | Purpose                                                    |
|------------------|-----------------------------|------------------------------------------------------------|
| Singleton        | `Services/Singleton/`       | Global `OrderLogger` — one shared instance across the app  |
| Factory Method   | `Services/Factory/`         | Creates individual laundry service instances (Wash, Dry Clean, etc.) |
| Abstract Factory | `Services/AbstractFactory/` | Creates cohesive package families (Standard, Premium, Business) |
| Strategy         | `Services/Strategy/`        | Swappable payment algorithms (Credit Card, EFT)            |
| Observer         | `Services/Observer/`        | Notifies Customer, Driver, Staff, and Admin on status changes |
| Decorator        | `Services/Decorator/`       | Wraps orders with optional extras (stain removal, fragrance) |

---

## Project Structure

```
LaundryManagementBlazor/
├── Components/
│   ├── Pages/
│   │   ├── Home.razor          # Landing page with pattern cards & role navigation
│   │   ├── Order.razor         # 4-step order placement wizard
│   │   ├── Customer.razor      # Order tracking & customer notifications
│   │   ├── Driver.razor        # Pickup & delivery task management
│   │   ├── Staff.razor         # Facility order processing
│   │   └── Admin.razor         # Dashboard, KPIs, order log (Singleton)
│   ├── Layout/
│   │   ├── MainLayout.razor
│   │   └── NavMenu.razor
│   └── Shared/
│       ├── OrderStatusBadge.razor
│       ├── ProgressTracker.razor
│       └── NotificationFeed.razor
├── Models/
│   ├── LaundryOrder.cs         # Base order (Decorator target)
│   ├── Customer.cs             # Customer with payment strategy reference
│   └── OrderViewModel.cs       # View models & DTOs
├── Services/
│   ├── LaundryAppService.cs    # Main orchestrator (registered as Singleton via DI)
│   ├── AbstractFactory/        # Package family factories
│   ├── Factory/                # Laundry service factories
│   ├── Strategy/               # Payment strategy implementations
│   ├── Decorator/              # Order extra decorators
│   ├── Observer/               # Order status observers
│   └── Singleton/              # OrderLogger
├── interfaces/                 # All pattern interfaces
├── wwwroot/                    # Static assets & Bootstrap CSS
└── Program.cs                  # DI registration & app startup
```

---

## How To Run

1. Open `LaundryManagementBlazor.sln` in Visual Studio 2022
2. Build the solution (`Ctrl + Shift + B`)
3. Run with `Ctrl + F5` (or `F5` to debug)
4. The app opens at `https://localhost:PORT` in your browser

---

## Application Pages & User Roles

| Page         | Route       | Role     | Description                                                  |
|--------------|-------------|----------|--------------------------------------------------------------|
| Home         | `/`         | All      | Overview of the system and design patterns                   |
| Order        | `/order`    | Customer | 4-step wizard: Package → Service → Extras → Payment         |
| Customer     | `/customer` | Customer | View placed orders and real-time notifications               |
| Driver       | `/driver`   | Driver   | Manage pickup/delivery tasks, update order statuses          |
| Staff        | `/staff`    | Staff    | Process facility orders, update processing status            |
| Admin        | `/admin`    | Admin    | Full order table, assign drivers, KPIs, and order logger     |

---

## Order Lifecycle

```
Placed → PickupAssigned → PickedUp → InProgress → ReadyForDelivery → OutForDelivery → Delivered
```

At each status transition, all registered observers (Customer, Driver, Staff, Admin) are automatically notified.

---

## Available Services & Pricing (ZAR)

| Service           | Price  |
|-------------------|--------|
| Wash Only         | R 80   |
| Wash & Fold       | R 120  |
| Dry Cleaning      | R 200  |
| Ironing           | R 90   |
| Express Same-Day  | R 250  |

**Optional Extras:**
- Stain Removal — R 25
- Perfume Treatment — R 30

**Packages:** Standard · Premium · Business

---

## Assignment Information

| Field       | Detail              |
|-------------|---------------------|
| Course      | ONT401              |
| Assignment  | Assignment 2        |
| Semester    | Semester 1 – 2026   |

---

> This project was developed for educational purposes to demonstrate software design patterns in a real-world Blazor web application.
