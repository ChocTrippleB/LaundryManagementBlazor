# SparkClean Laundry Management — Build Plan
**ONT401 Assignment B | Due: 22 May 2026**

---

## What Already Exists

### Backend Logic (Done)

| Pattern | Classes |
|---|---|
| Factory Method | `LaundryService` (base), `WashOnly`, `WashAndFold`, `DryCleaning`, `IroningService`, `ExpressSameDay` |
| Decorator | `OrderDecorator` (base), `StainRemoverDecorator`, `PerfumeTreatmentDecorator` |
| Observer | `ObservableOrder`, `OrderStatus` enum, `AdminDashboard`, `StaffNotifier`, `DriverNotifier`, `CustomerNotifier` |
| Strategy | `IPaymentStrategy`, `CreditCardPayment`, `EFTPayment` |
| Singleton | `OrderLogger` |
| Models | `LaundryOrder`, `Customer` |
| Interfaces | `ILaundryOrder`, `INotificationObserver`, `IOrderObserver`, `IPaymentStrategy`, `IOrderSubject` |

---

## What Is Missing

| Item | Details |
|---|---|
| **Abstract Factory** | `ILaundryPackageFactory` + `StandardPackageFactory`, `PremiumPackageFactory`, `BusinessPackageFactory`. Products: `IPackaging`, `IDeliveryMethod`, `IDetergentType` |
| **`LaundryAppService`** | In-memory singleton store: `List<OrderViewModel>`, `List<LogEntry>`, `List<NotificationEntry>`. Fires `StateChanged` event for UI refresh |
| **Observer wiring** | Replace `Console.WriteLine` in all observer classes with appends to `LaundryAppService` + invoke `StateChanged` |
| **OrderLogger wiring** | Persist log entries to `LaundryAppService.LogEntries` instead of Console |
| **Program.cs DI** | Register `LaundryAppService` as `AddSingleton` |
| **NavMenu.razor** | Replace default Counter/Weather links with app pages |
| **All UI pages** | Currently empty shells — to be built |
| **NotificationFeed.razor** | Shared component — currently empty |

---

## Navigation (No Login)

```
[Home] [New Order] [Customer View] [Driver View] [Staff View] [Admin Dashboard]
```

No authentication. Each view is role-simulated — just navigate to the page.

---

## Pages Plan

### 1. Home (`/`)
- Hero section: app name + tagline
- Cards showing all 6 design patterns and their role in the system
- "Place New Order" call-to-action button

### 2. New Order (`/order`) — 4-step wizard
| Step | What it does | Pattern |
|---|---|---|
| 1 — Pick Package | Standard / Premium / Business cards | Abstract Factory |
| 2 — Pick Service | Wash Only / Wash & Fold / Dry Cleaning / Ironing / Express | Factory Method |
| 3 — Add Extras | Stain Removal (+R25), Perfume Treatment (+R30) checkboxes. Live price total | Decorator |
| 4 — Payment | Credit Card / EFT radio. Submit logs + notifies observers | Strategy + Singleton + Observer |

### 3. Customer View (`/customer`)
- Order history list: ID, service, extras, total, status badge
- Notification feed panel (messages from `CustomerNotifier`)

### 4. Driver View (`/driver`)
- Orders in `PickupAssigned` and `OutForDelivery` states
- Action buttons: "Mark Picked Up" → updates status, triggers observers
- Notification feed (messages from `DriverNotifier`)

### 5. Staff View (`/staff`)
- Orders in `PickedUp` / `InProgress` states
- Action buttons: "Start Processing" → `InProgress`, "Mark Ready" → `ReadyForDelivery`
- Notification feed (messages from `StaffNotifier`)

### 6. Admin Dashboard (`/admin`)
- Full orders table (all statuses)
- OrderLogger panel — all log entries in real time (Singleton)
- Summary counters: Total Orders, In Progress, Delivered

---

## In-Memory Data Store (`LaundryAppService`)

Registered as `AddSingleton` in `Program.cs`. Holds all runtime state:

```csharp
List<OrderViewModel>     Orders           // all placed orders
List<LogEntry>           LogEntries       // from OrderLogger
List<NotificationEntry>  Notifications    // per role: Customer/Driver/Staff/Admin
event Action             StateChanged     // triggers StateHasChanged in Blazor pages
```

`NotificationEntry` shape:
```
Role | OrderId | Message | Timestamp
```

`OrderViewModel` shape:
```
OrderId | CustomerName | Package | ServiceType | Extras | Total | Status | CreatedAt
```

---

## Hardcoded Values (temporary — for UI skeleton phase)

- Customer name: "John Doe", Cell: "082 000 0000"
- Seed orders in `LaundryAppService` constructor for all status types
- Seed notifications for each role
- Credit card: last 4 digits "4242", name "John Doe"

---

## Build Order

### Phase 1 — UI Skeletons (DONE)
- [x] Create `PLAN.md`
- [x] Update `NavMenu.razor` — add all 6 nav links
- [x] `Home.razor` — hero + pattern cards
- [x] `Order.razor` — 4-step wizard (hardcoded, no backend wiring yet)
- [x] `Customer.razor` — order list + notification feed (hardcoded data)
- [x] `Driver.razor` — pickup list + status buttons (hardcoded data)
- [x] `Staff.razor` — processing queue + status buttons (hardcoded data)
- [x] `Admin.razor` — orders table + log panel (hardcoded data)
- [x] `NotificationFeed.razor` — shared notification component

### Phase 2 — Wire Backend
- [ ] Create `LaundryAppService` (in-memory store + event)
- [ ] Register services in `Program.cs`
- [ ] Implement Abstract Factory (Standard / Premium / Business)
- [ ] Update observer classes to write to `LaundryAppService` instead of Console
- [ ] Update `OrderLogger` to write to `LaundryAppService.LogEntries`
- [ ] Connect `Order.razor` wizard to real backend (Factory, Decorator, Strategy, Observer, Singleton)
- [ ] Connect status buttons in Driver/Staff views to `ObservableOrder.UpdateStatus()`

### Phase 3 — Polish
- [ ] Styling consistency (Bootstrap already included)
- [ ] Empty states (no orders yet)
- [ ] Order status timeline/stepper on Customer view
- [ ] README with run instructions

---

## Tech Stack

- **Framework**: Blazor Server (.NET 8) — Interactive Server render mode
- **Styling**: Bootstrap 5 (already bundled in `wwwroot/bootstrap`)
- **State**: In-memory `List`/`Dictionary` via singleton `LaundryAppService`
- **Real-time UI**: `StateHasChanged()` via `LaundryAppService.StateChanged` event
- **No database, no login, no SignalR needed**

---

## Assessment Rubric Mapping

| Criterion (10 marks each) | Where demonstrated |
|---|---|
| Strategy Pattern | Step 4 of New Order — payment method selection |
| Observer Pattern | Status update buttons in Driver/Staff views notify all role feeds |
| Decorator Pattern | Step 3 of New Order — extras checkboxes wrap the base order |
| Factory Method Pattern | Step 2 of New Order — service type selection |
| Abstract Factory Pattern | Step 1 of New Order — package tier selection |
| Singleton Pattern | Admin Dashboard — OrderLogger panel |
| UI and UX (5 marks) | Clean Bootstrap layout, role views, wizard flow |
| Creativity (5 marks) | Multi-role simulation, live notification feeds |
| Code Quality / OOP (10 marks) | Interfaces, loose coupling, DI |
| Presentation & Documentation (30 marks) | This plan + UML diagrams + report |
