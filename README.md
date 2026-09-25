## Стек

- ASP.NET Core 9 MVC
- Entity Framework Core 9 (Npgsql provider)
- PostgreSQL


### Клонировать репозиторий

```bash
git clone https://github.com/Croc53/Test-task-wersta.git
cd Test-task-wersta/TetsTaskWersta
```

### Создать базу данных

```bash
psql -U postgres -c "CREATE DATABASE test_task_wersta;"
```

### Настроить строку подключения

В `appsettings.json` (в папке проекта) указать свои учётные данные PostgreSQL:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=test_task_wersta;Username=postgres;Password=postgres"
}
```

### Применить миграции

```bash
dotnet tool install --global dotnet-ef
dotnet ef database update
```

### Запустить приложение

```bash
dotnet run
```
