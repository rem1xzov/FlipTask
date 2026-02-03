# Команды для работы с миграциями Entity Framework Core

## Важно
Все команды выполняются из папки проекта **To-Do_Flip.DataAccess**

---

## Создание новой миграции

```powershell
cd C:\Users\bkrav\RiderProjects\To-Do_Flip\To-Do_Flip.DataAccess
dotnet ef migrations add <ИмяМиграции> --startup-project ..\To-Do_Flip\To-Do_Flip.csproj --context To_Do_Flip_Context
```

**Пример:**
```powershell
dotnet ef migrations add AddUserTable --startup-project ..\To-Do_Flip\To-Do_Flip.csproj --context To_Do_Flip_Context
```

---

## Применение миграций к базе данных (обновление БД)

```powershell
cd C:\Users\bkrav\RiderProjects\To-Do_Flip\To-Do_Flip.DataAccess
dotnet ef database update --startup-project ..\To-Do_Flip\To-Do_Flip.csproj --context To_Do_Flip_Context
```

**Применить конкретную миграцию:**
```powershell
dotnet ef database update <ИмяМиграции> --startup-project ..\To-Do_Flip\To-Do_Flip.csproj --context To_Do_Flip_Context
```

**Откатить все миграции:**
```powershell
dotnet ef database update 0 --startup-project ..\To-Do_Flip\To-Do_Flip.csproj --context To_Do_Flip_Context
```

---

## Удаление последней миграции (если она еще не применена)

```powershell
cd C:\Users\bkrav\RiderProjects\To-Do_Flip\To-Do_Flip.DataAccess
dotnet ef migrations remove --startup-project ..\To-Do_Flip\To-Do_Flip.csproj --context To_Do_Flip_Context
```

---

## Просмотр списка миграций

```powershell
cd C:\Users\bkrav\RiderProjects\To-Do_Flip\To-Do_Flip.DataAccess
dotnet ef migrations list --startup-project ..\To-Do_Flip\To-Do_Flip.csproj --context To_Do_Flip_Context
```

---

## Создание скрипта SQL из миграций

**Создать SQL скрипт для всех миграций:**
```powershell
cd C:\Users\bkrav\RiderProjects\To-Do_Flip\To-Do_Flip.DataAccess
dotnet ef migrations script --startup-project ..\To-Do_Flip\To-Do_Flip.csproj --context To_Do_Flip_Context --output migration.sql
```

**Создать SQL скрипт между двумя миграциями:**
```powershell
dotnet ef migrations script <ОтМиграции> <ДоМиграции> --startup-project ..\To-Do_Flip\To-Do_Flip.csproj --context To_Do_Flip_Context --output migration.sql
```

---

## Типичный рабочий процесс

1. **Внести изменения в Entity или DbContext**
2. **Создать миграцию:**
   ```powershell
   dotnet ef migrations add <ИмяМиграции> --startup-project ..\To-Do_Flip\To-Do_Flip.csproj --context To_Do_Flip_Context
   ```
3. **Проверить созданные файлы миграции** в папке `Migrations`
4. **Применить миграцию к БД:**
   ```powershell
   dotnet ef database update --startup-project ..\To-Do_Flip\To-Do_Flip.csproj --context To_Do_Flip_Context
   ```

---

## Примечания

- **Строка подключения** к базе данных настраивается в `appsettings.json` главного проекта (To-Do_Flip)
- **Контекст БД:** `To_Do_Flip_Context`
- **Провайдер БД:** PostgreSQL (Npgsql)
- Все миграции хранятся в папке `Migrations` проекта DataAccess
