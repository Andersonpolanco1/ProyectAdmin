# ProyectAdmin

ProyectAdmin es una solución desarrollada en .NET 8 que incluye una aplicación web y una capa de infraestructura. Utiliza Entity Framework Core para el acceso a datos y está configurada para trabajar con SQL Server.

## Instalación de Paquetes

Para trabajar con el proyecto, primero necesitas instalar las siguientes librerías en el proyecto de infraestructura (`ProyectAdmin.Infrastructure`):

- **Microsoft.EntityFrameworkCore.Tools**: Herramientas para trabajar con Entity Framework Core.
- **Microsoft.EntityFrameworkCore.Design**: Paquete de diseño para EF Core, necesario para las herramientas de migración.
- **Microsoft.EntityFrameworkCore.SqlServer**: Proveedor de EF Core para SQL Server.

Puedes instalar estos paquetes ejecutando los siguientes comandos en la raíz del proyecto de infraestructura:

```bash
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer

