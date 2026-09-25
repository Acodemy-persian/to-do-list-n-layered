# ToDoList

یک Web API ساده برای مدیریت وظایف که با **.NET 10** و معماری لایه‌ای
پیاده‌سازی شده است.

## معماری

Solution شامل چهار پروژه است:

``` text
ToDoList
├── Domain
├── Application
├── DataAccess
└── Presentation
```

### Domain

شامل موجودیت‌های اصلی دامنه است.

-   `WorkItem`

### Application

شامل منطق و قراردادهای لایه Application است.

-   DTOهای مربوط به درخواست و پاسخ Task
-   Interface و پیاده‌سازی Serviceها
-   پروفایل‌های AutoMapper
-   مدل‌های استاندارد پاسخ Service
-   کدهای خطا

اجزای اصلی:

-   `ITaskService`
-   `TaskService`
-   `TaskMappingProfile`
-   `BaseServiceResponseModel`
-   `BaseServiceDataResponseModel<T>`
-   `ErrorCode`

### DataAccess

مسئول دسترسی به دیتابیس با استفاده از **Entity Framework Core** است.

-   `AppDbContext`
-   `ITaskRepository`
-   `TaskRepository`
-   اتصال به SQL Server

مجموعه اصلی موجودیت‌ها:

``` csharp
DbSet<WorkItem> WorkItems
```

### Presentation

لایه ASP.NET Core Web API است.

-   Controllerها
-   Dependency Injection
-   Swagger UI
-   فیلتر مدیریت نتیجه Service
-   ثبت وابستگی‌های Application و DataAccess

Controller اصلی:

``` text
/api/Task
```

## عملیات API

API مربوط به Task عملیات زیر را ارائه می‌دهد:

  Method   Endpoint           توضیح
  -------- ------------------ -------------------------
  POST     `/api/Task`        ایجاد Task
  GET      `/api/Task`        دریافت همه Taskها
  GET      `/api/Task/{id}`   دریافت یک Task با شناسه
  PUT      `/api/Task`        به‌روزرسانی Task
  DELETE   `/api/Task/{id}`   حذف Task

## فناوری‌ها

-   .NET 10
-   ASP.NET Core Web API
-   Entity Framework Core
-   SQL Server
-   AutoMapper
-   Swagger / OpenAPI
-   C#

## دیتابیس

برای ایجاد و به‌روزرسانی Schema دیتابیس از Migrationهای Entity Framework
Core استفاده می‌شود.

از ریشه Solution:

``` bash
dotnet ef migrations add <MigrationName> \
  --project DataAccess \
  --startup-project Presentation
```

اعمال Migrationها:

``` bash
dotnet ef database update \
  --project DataAccess \
  --startup-project Presentation
```

## اجرای API

از پروژه `Presentation` اجرا کنید:

``` bash
dotnet run
```

آدرس HTTP/HTTPS واقعی هنگام اجرای برنامه در Console نمایش داده می‌شود.

## Swagger UI

در محیط Development، رابط Swagger UI در مسیر زیر در دسترس است:

``` text
/swagger
```

برای مثال:

``` text
http://localhost:<port>/swagger
```

## مدیریت پاسخ‌ها

Serviceهای لایه Application از مدل‌های استاندارد پاسخ استفاده می‌کنند.

پاسخ‌های موفق از این مدل‌ها استفاده می‌کنند:

``` text
BaseServiceResponseModel
BaseServiceDataResponseModel<T>
```

خطاها با استفاده از `ErrorCode` مشخص می‌شوند:

-   `None`
-   `GeneralError`
-   `NotFound`
-   `Duplicate`

کلاس `HandleServiceResultAttribute` کدهای خطای Service را به HTTP Status
Code مناسب نگاشت می‌کند.

## وضعیت پروژه

این پروژه یک پروژه آموزشی/توسعه‌ای است که پیاده‌سازی یک ASP.NET Core Web
API لایه‌ای را با استفاده از Entity Framework Core، الگوهای Repository و
Service، DTOها، AutoMapper و پاسخ‌های استاندارد Service نشان می‌دهد.
