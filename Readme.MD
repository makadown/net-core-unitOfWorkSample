# unitOfWorkSample

Ejercicio de implementacion de patron Unit Of Work.
Base de datos mySQL.
Ese branch es basado en otro enfoque de uow

Kudos a:
https://www.codeproject.com/Articles/1157241/Very-Thin-Database-Layer-using-UnitOfWork-Pattern

## Creación de proyecto

dotnet new webapi

## Scaffold de entidades en MYSQL

ejemplo
```
dotnet ef dbcontext scaffold "Server=localhost;port=3306;uid=root;password=abc123;Database=facturas;connect timeout=100" Pomelo.EntityFrameworkCore.MySql -o Core\Models -c MySqlContext
```
