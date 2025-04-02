# Bloggie

Este es el proyecto **Bloggie**, una aplicación web para gestionar blogs. A continuación, se detallan los pasos para configurar y ejecutar el proyecto localmente.

## Requisitos

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

## Configuración del Proyecto

1. **Clonar el repositorio**
   
2. **Configurar la base de datos**

   Asegúrate de tener una instancia de SQL Server en ejecución. Luego, actualiza la cadena de conexión en el archivo `appsettings.json` con los detalles de tu servidor SQL.
    { "ConnectionStrings": { "DefaultConnection": "Server=tu-servidor;Database=BloggieDb;User Id=tu-usuario;Password=tu-contraseña;" } }
   
3. **Aplicar las migraciones**

   Abre la terminal integrada en Visual Studio y navega hasta el proyecto `Bloggie.Web`. Luego, ejecuta los siguientes comandos para aplicar las migraciones y crear la base de datos:
   dotnet ef database update

4. **Ejecutar el proyecto**

   En Visual Studio, selecciona `Bloggie.Web` como el proyecto de inicio y presiona `F5` para ejecutar la aplicación.

## Estructura del Proyecto

- **Bloggie.Web**: Proyecto principal de la aplicación web.
- **Bloggie.Web/Controllers**: Controladores de la aplicación.
- **Bloggie.Web/Models**: Modelos de dominio y ViewModels.
- **Bloggie.Web/Data**: Contexto de la base de datos y configuraciones de EF Core.

- ## Paquetes NuGet Instalados

A continuación se listan los paquetes NuGet instalados en el proyecto:

- `Microsoft.EntityFrameworkCore`
- `Microsoft.EntityFrameworkCore.SqlServer`
- `Microsoft.EntityFrameworkCore.Tools`
- `Microsoft.AspNetCore.Identity.EntityFrameworkCore`
- `Microsoft.AspNetCore.Identity.UI`
- `Microsoft.Extensions.Logging`
- `Microsoft.Extensions.Configuration`
- `Microsoft.Extensions.DependencyInjection`
- `Microsoft.VisualStudio.Web.CodeGeneration.Design`
- `Newtonsoft.Json`

## Contribuciones

Las contribuciones son bienvenidas. Por favor, abre un issue o un pull request para discutir cualquier cambio que desees realizar.

## Licencia

Este proyecto está licenciado bajo la [MIT License](LICENSE).


   

   
