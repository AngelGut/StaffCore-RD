========================================
STAFFCORE RD - Sistema de Gestión de Personal
========================================

Nombre: Angel David Gutierrez Contreras
Matrícula: 2024-1272

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
CREDENCIALES DE PRUEBA
========================================

ADMINISTRADOR (Acceso Total):
├─ Email: admin@staffcore.com
├─ Contraseña: Admin123
└─ Permisos: CRUD + Delete + Gestionar Roles + Resumen

RRHH (Recursos Humanos):
├─ Email: rrhh@staffcore.com
├─ Contraseña: RRHh123!
└─ Permisos: Ver, Crear, Editar Personal + Resumen

VIEWER (Solo Lectura):
├─ Email: viewer@staffcore.com
├─ Contraseña: Viewer123!
└─ Permisos: Solo ver personal y detalles

========================================
¿CÓMO CREAR NUEVOS USUARIOS?
========================================

OPCIÓN 1: Crear como ADMINISTRADOR
1. Loguear con admin@staffcore.com / Admin123
2. En el Index del Personal, hacer clic en botón "👥 Gestionar Roles"
3. Hacer clic en "➕ Crear Usuario RRHH"
4. Ingresar email, contraseña y seleccionar rol
5. El usuario queda creado con ese rol

OPCIÓN 2: Registro automático
1. Ir a /Account/Register
2. Registrar nuevo usuario
3. Automáticamente se asigna:
   - Primer usuario → ADMINISTRADOR
   - Otros usuarios → VIEWER

OPCIÓN 3: Cambiar rol de usuario existente
1. Loguear como ADMINISTRADOR
2. Ir a "👥 Gestionar Roles"
3. Seleccionar nuevo rol del dropdown
4. Hacer clic en "Actualizar"

========================================
CARACTERÍSTICAS PRINCIPALES
========================================

✅ Autenticación con ASP.NET Identity
✅ Autorización basada en 3 roles (Admin, RRHH, Viewer)
✅ CRUD completo de personal
✅ Gestión de roles (crear usuarios con rol específico)
✅ Resumen estadístico por departamento
✅ Página de detalles de empleados
✅ Links clickeables para navegar
✅ Validaciones en cliente y servidor
✅ Bootstrap 5 para UI responsive
✅ Mensajes de éxito con TempData
✅ Protección CSRF
✅ Lockout de cuenta tras 3 intentos fallidos

========================================
CONTROL DE ACCESO POR ROL
========================================

ADMINISTRADOR:
├─ Ver personal ✅
├─ Crear empleado ✅
├─ Editar empleado ✅
├─ Eliminar empleado ✅
├─ Ver resumen estadístico ✅
├─ Ver detalles de empleado ✅
└─ Gestionar roles de usuarios ✅

RRHH:
├─ Ver personal ✅
├─ Crear empleado ✅
├─ Editar empleado ✅
├─ Eliminar empleado ❌
├─ Ver resumen estadístico ✅
└─ Ver detalles de empleado ✅

VIEWER:
├─ Ver personal ✅
├─ Crear empleado ❌
├─ Editar empleado ❌
├─ Eliminar empleado ❌
├─ Ver resumen estadístico ❌
└─ Ver detalles de empleado ✅

========================================
ESTRUCTURA DEL PROYECTO
========================================

Controllers/
├── AccountController.cs      (Autenticación + Gestión de Roles)
└── StaffController.cs        (CRUD de Personal)

Models/
├── Staff.cs                  (Modelo de empleado)
├── LoginViewModel.cs
├── RegisterViewModel.cs
├── RegisterUserAdminViewModel.cs
└── UserRoleViewModel.cs

Views/
├── Account/
│   ├── Login.cshtml
│   ├── Register.cshtml
│   ├── ManageRoles.cshtml   (Gestionar roles - Admin only)
│   ├── RegisterUser.cshtml   (Crear usuario - Admin only)
│   └── AccessDenied.cshtml
├── Staff/
│   ├── Index.cshtml         (Con botón Gestionar Roles para Admin)
│   ├── Create.cshtml
│   ├── Edit.cshtml
│   ├── Delete.cshtml
│   ├── Details.cshtml
│   └── Summary.cshtml
├── Home/
│   └── Index.cshtml
└── Shared/
    └── _Layout.cshtml

Data/
└── StaffDbContext.cs         (Entity Framework + Seed data)

Migrations/
└── [Migraciones automáticas]

========================================
ENDPOINTS PRINCIPALES
========================================

HOME:
GET  /                          → Página principal

ACCOUNT:
GET  /Account/Login             → Formulario de login
POST /Account/Login             → Procesar login
GET  /Account/Register          → Formulario de registro
POST /Account/Register          → Procesar registro
POST /Account/Logout            → Cerrar sesión
GET  /Account/AccessDenied      → Acceso denegado
GET  /Account/ManageRoles       → Gestionar roles (Admin)
POST /Account/ChangeRole        → Cambiar rol usuario (Admin)
GET  /Account/RegisterUser      → Crear usuario (Admin)
POST /Account/RegisterUser      → Procesar creación (Admin)

STAFF:
GET  /Staff/Index              → Lista de empleados
GET  /Staff/Create             → Formulario crear
POST /Staff/Create             → Procesar creación
GET  /Staff/Edit/{id}          → Formulario editar
POST /Staff/Edit/{id}          → Procesar edición
GET  /Staff/Delete/{id}        → Confirmar eliminación
POST /Staff/Delete/{id}        → Procesar eliminación
GET  /Staff/Details/{id}       → Detalles del empleado
GET  /Staff/Summary            → Resumen estadístico

========================================
DATOS DE SEED (PRECARGADOS)
========================================

1. Juan Carlos Pérez
   ├─ Cédula: 001-1234567-8
   ├─ Cargo: Jefe de Tecnología
   ├─ Departamento: Tecnología
   └─ Salario: RD$ 50,000.00

2. María Martínez Rodríguez
   ├─ Cédula: 002-9876543-2
   ├─ Cargo: Especialista de RRHH
   ├─ Departamento: Recursos Humanos
   └─ Salario: RD$ 35,000.00

========================================
REQUISITOS DEL SISTEMA
========================================

- .NET 8.0 o superior
- SQL Server (LocalDB o Enterprise)
- Visual Studio 2022 (recomendado)
- NuGet packages:
  ├─ Microsoft.AspNetCore.Identity.EntityFrameworkCore
  ├─ Microsoft.EntityFrameworkCore.SqlServer
  └─ Bootstrap 5

========================================
NOTAS DE SEGURIDAD
========================================

⚠️ Las credenciales mostradas son SOLO para pruebas
⚠️ Cambiar contraseñas antes de producción
⚠️ No compartir datos sensibles en repositorio
✅ CSRF Protection activada
✅ Account Lockout tras 3 intentos fallidos
✅ Validación de entrada en cliente y servidor

========================================