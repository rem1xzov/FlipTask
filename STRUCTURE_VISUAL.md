# 🎨 Визуальная структура FlipTask

Структура проекта организована по папкам, аналогично [Flip](https://github.com/rem1xzov/Flip).

## 📊 Древовидная структура

```
To-Do_Flip/
│
├── 📄 README.md                          # Основная документация
├── 📄 LICENSE                            # Лицензия MIT
├── 📄 .gitignore                         # Игнорируемые файлы
├── 📄 Dockerfile                         # Docker конфигурация
├── 📄 docker-compose.yml                 # Docker Compose
├── 📄 To-Do_Flip.sln                     # Solution файл
│
├── 📂 To-Do_Flip/                        # 🌐 Web API
│   ├── 📂 Controllers/                   
│   │   └── 📄 To_Do_Flip_Controller.cs
│   │
│   ├── 📂 Contract/                     
│   │   ├── 📄 To_Do_Flip_Request.cs
│   │   └── 📄 To_Do_Flip_Response.cs
│   │
│   ├── 📂 Properties/                   
│   │   └── 📄 launchSettings.json
│   │
│   ├── 📄 Program.cs
│   ├── 📄 appsettings.json
│   ├── 📄 appsettings.Development.json
│   ├── 📄 appsettings.Example.json
│   ├── 📄 To-Do_Flip.csproj
│   └── 📄 README.md
│
├── 📂 To-Do_Flip.Application/            # 🧠 Application Layer
│   ├── 📂 Service/                       
│   │   ├── 📄 To_Do_Flip_IService.cs
│   │   └── 📄 To_Do_Flip_Service.cs
│   │
│   ├── 📂 Repository/                    
│   │   ├── 📄 To_Do_Flip_IRepository.cs
│   │   └── 📄 To_Do_Flip_Repository.cs
│   │
│   ├── 📄 To-Do_Flip.Application.csproj
│   └── 📄 README.md
│
├── 📂 To-Do_Flip.DataAccess/             # 🗄️ ВСЕ БД-СВЯЗАННОЕ
│   ├── 📂 Entity/                        # Entity модели
│   │   └── 📄 To-Do_Flip_Entity.cs
│   │
│   ├── 📂 DbContext/                     # Контекст БД
│   │   └── 📄 To_Do_Flip_Context.cs
│   │
│   ├── 📂 Configuration/                 # Конфигурации EF
│   │   └── 📄 To_Do_Flip_Configuration.cs
│   │
│   ├── 📂 Migrations/                    # Миграции БД
│   │   ├── 📄 20260201125620_InitialCreate.cs
│   │   ├── 📄 20260201125620_InitialCreate.Designer.cs
│   │   └── 📄 To_Do_Flip_ContextModelSnapshot.cs
│   │
│   ├── 📄 To-Do_Flip.DataAccess.csproj
│   ├── 📄 README.md
│   └── 📄 MIGRATIONS_COMMANDS.md
│
└── 📂 To-Do_Flip.Store/                  # 📦 МОДЕЛИ
    ├── 📂 Model/                         # Доменные модели
    │   └── 📄 To_Do.cs
    │
    ├── 📄 To-Do_Flip.Store.csproj
    └── 📄 README.md
```

## 🎯 Ключевые папки (как в Flip)

### 🌐 Controllers/
**Расположение:** `To-Do_Flip/Controllers/`
- API контроллеры для обработки HTTP запросов
- Аналогично `Controllers/` в Flip

### 🗄️ Database (ВСЕ БД-СВЯЗАННОЕ)
**Расположение:** `To-Do_Flip.DataAccess/`
- `Entity/` - Entity модели (таблицы БД)
- `DbContext/` - Контекст БД
- `Configuration/` - Конфигурации EF
- `Migrations/` - Миграции БД
- Аналогично `FlipStoreAnon.DbContext/` в Flip

### 📦 Models (МОДЕЛИ)
**Расположение:** `To-Do_Flip.Store/Model/`
- Доменные модели с бизнес-логикой
- Аналогично `FlipChatStore/` в Flip

## 📚 Документация в каждой папке

Каждая основная папка содержит README.md:
- ✅ `To-Do_Flip/README.md`
- ✅ `To-Do_Flip.Application/README.md`
- ✅ `To-Do_Flip.DataAccess/README.md`
- ✅ `To-Do_Flip.Store/README.md`

## 🔗 Связанные файлы

- [ORGANIZATION.md](./ORGANIZATION.md) - Подробная организация
- [FOLDER_STRUCTURE.md](./FOLDER_STRUCTURE.md) - Структура папок
- [STRUCTURE_GUIDE.md](./STRUCTURE_GUIDE.md) - Руководство

---

**Структура организована аналогично:** [Flip Repository](https://github.com/rem1xzov/Flip)
