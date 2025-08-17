# TasksAPI

## Descripción
TasksAPI es una API REST desarrollada en .NET 8 para la gestión de tareas, diseñada con arquitectura limpia y buenas prácticas de desarrollo. Permite la administración de usuarios, autenticación, y gestión de tareas, integrando seguridad y persistencia eficiente.

## Estructura del Proyecto
```
TasksAPI/
├── Controllers/                # Controladores REST
├── Database/                   # Inicialización y scripts de base de datos
├── IAM/                        # Módulo de autenticación y autorización
│   ├── Application/
│   ├── Domain/
│   ├── Infrastructure/
│   └── Interfaces/
├── Management/                 # Lógica de negocio de gestión de tareas
│   ├── Application/
│   ├── Domain/
│   ├── Infrastructure/
│   └── Interfaces/
├── Shared/                     # Componentes compartidos
├── appsettings.json            # Configuración principal
├── Program.cs                  # Entrada principal de la aplicación
├── TasksAPI.csproj             # Archivo de proyecto .NET
└── README.md                   # Documentación
```

## Tecnologías y Librerías
- **.NET 8**
- **Entity Framework Core** (persistencia y migraciones)
- **JWT Bearer Authentication** (seguridad y autenticación)
- **BCrypt.Net** (hashing de contraseñas)
- **Azure.Identity** (integración opcional con Azure)
- **Humanizer** (utilidades para manipulación de datos)

## Instalación y Ejecución
1. Clona el repositorio:
   ```
   git clone <url-del-repositorio>
   ```
2. Restaura los paquetes NuGet:
   ```
   dotnet restore
   ```
3. Configura la cadena de conexión en `appsettings.json`.
4. Ejecuta las migraciones si es necesario:
   ```
   dotnet ef database update
   ```
5. Inicia la API:
   ```
   dotnet run
   ```

## Configuración
- `appsettings.json`: Configuración de base de datos, JWT y otros parámetros.
- `appsettings.Development.json`: Configuración específica para desarrollo.

## Módulos Principales
- **IAM**: Autenticación, autorización y gestión de usuarios.
- **Management**: Lógica de negocio para la gestión de tareas.
- **Shared**: Repositorios y utilidades compartidas.

## Ejemplo de Uso
Puedes probar los endpoints usando herramientas como Postman o el archivo `TasksAPI.http` incluido en el proyecto.

## Scripts de Base de Datos
Los scripts SQL se encuentran en `Database/Scripts/` para inicialización y consultas personalizadas.

## Créditos y Contacto
Desarrollado por el equipo de retail. Para dudas o soporte, contacta a: [tu-email@dominio.com]

---
Este proyecto sigue buenas prácticas de arquitectura limpia y está preparado para escalar y adaptarse a nuevas funcionalidades.

