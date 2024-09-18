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
```

## Configuración en `appsettings.json`

Para configurar la cadena de conexión a la base de datos, asegúrate de que tu archivo `appsettings.json` contenga la siguiente configuración:

```json
{
...
  "ConnectionStrings": {
    "DefaultConnection": "Agrega aqui tu cadena de conexión"
  },
...
}
```

## Ejecutar las Migraciones

Para asegurarte de que la base de datos esté actualizada con las últimas migraciones, sigue estos pasos:

### 1. Agregar una Migración Inicial

Primero, debes agregar una migración inicial que refleje el esquema actual de tu modelo de datos en la base de datos. Ejecuta el siguiente comando desde la raíz de tu solución:

```bash
dotnet ef migrations add InitialCreate --project ProyectAdmin.Infrastructure --startup-project ProyectAdmin.Web
```

### 2. Aplicar las Migraciones a la Base de Datos

Una vez que hayas creado la migración, debes aplicarla a la base de datos para que el esquema se actualice. Ejecuta el siguiente comando:


```bash
dotnet ef database update --project ProyectAdmin.Infrastructure --startup-project ProyectAdmin.Web
```



