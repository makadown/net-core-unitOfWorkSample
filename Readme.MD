# unitOfWorkSample

Ejercicio de implementacion de patron Unit Of Work.
Base de datos mySQL.

Kudos a:
https://anexsoft.com/implementacion-de-unit-of-work-services-y-repository-con-net-core-2-2

## Creación de proyecto

dotnet new webapi

## Scaffold de entidades en MYSQL

ejemplo
```
dotnet ef dbcontext scaffold "Server=localhost;port=3306;uid=root;password=abc123;Database=facturas;connect timeout=100" Pomelo.EntityFrameworkCore.MySql -o Core\Models -c MySqlContext
```
