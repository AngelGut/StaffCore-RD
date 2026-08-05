========================================
STAFFCORE RD - Sistema de Gestión de Personal
========================================

Nombre: Angel David Gutierrez Contreras
Matrícula: 2024-1272

========================================
CREDENCIALES DE PRUEBA - ADMINISTRADOR
========================================

Email: admin@staffcore.com
Contraseña: Admin123

Nota: Esta es la primera cuenta creada en el sistema,
por lo que automáticamente tiene el rol "Administrador".

========================================
PASOS PARA EJECUTAR
========================================

1. Restaurar paquetes NuGet:
   dotnet restore

2. Aplicar migraciones a la BD:
   dotnet ef database update

3. Ejecutar la aplicación:
   dotnet run

4. Abrir navegador:
   http://localhost:5062

========================================
CARACTERÍSTICAS PRINCIPALES
========================================

✅ Autenticación con ASP.NET Identity
✅ Autorización basada en roles (Administrador, RRHH, Viewer)
✅ CRUD completo de personal
✅ Validaciones en cliente y servidor
✅ Bootstrap 5 para UI responsive
✅ Mensajes de éxito con TempData
✅ Control de acceso por URL
✅ Protección CSRF con [ValidateAntiForgeryToken]

========================================
ROLES DEL SISTEMA
========================================

- Administrador: Acceso total (CRUD + Delete)
- RRHH: Crear, leer, editar personal
- Viewer: Solo lectura

========================================
ESTRUCTURA DEL PROYECTO
========================================

Controllers/
├── AccountController.cs      (Autenticación)
└── StaffController.cs        (CRUD de Personal)

Models/
├── Staff.cs                  (Modelo de empleado)
├── LoginViewModel.cs
└── RegisterViewModel.cs

Views/
├── Account/
│   ├── Login.cshtml
│   ├── Register.cshtml
│   └── AccessDenied.cshtml
├── Staff/
│   ├── Index.cshtml
│   ├── Create.cshtml
│   ├── Edit.cshtml
│   └── Delete.cshtml
├── Home/
│   └── Index.cshtml
└── Shared/
    └── _Layout.cshtml

Data/
└── StaffDbContext.cs         (Entity Framework)

Migrations/
└── [Migrations automáticas]

========================================