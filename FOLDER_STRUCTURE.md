# 📂 Структура папок FlipTask

Визуальное представление организации проекта, аналогично [Flip](https://github.com/rem1xzov/Flip).

## 🎯 Основная структура

```
To-Do_Flip/
│
├── 📂 To-Do_Flip/                    # 🌐 Web API
│   ├── 📂 Controllers/               # API контроллеры
│   │   └── To_Do_Flip_Controller.cs
│   │
│   ├── 📂 Contract/                  # DTOs
│   │   ├── To_Do_Flip_Request.cs
│   │   └── To_Do_Flip_Response.cs
│   │
│   ├── 📂 Properties/                # Настройки
│   │   └── launchSettings.json
│   │
│   ├── Program.cs                    # Точка входа
│   ├── appsettings.json              # Конфигурация
│   └── README.md                     # Документация
│
├── 📂 To-Do_Flip.Application/         # 🧠 Application Layer
│   ├── 📂 Service/                   # Бизнес-логика
│   │   ├── To_Do_Flip_IService.cs
│   │   └── To_Do_Flip_Service.cs
│   │
│   ├── 📂 Repository/                 # Репозитории
│   │   ├── To_Do_Flip_IRepository.cs
│   │   └── To_Do_Flip_Repository.cs
│   │
│   └── README.md                     # Документация
│
├── 📂 To-Do_Flip.DataAccess/          # 🗄️ ВСЕ БД-СВЯЗАННОЕ
│   ├── 📂 Entity/                     # Entity модели
│   │   └── To-Do_Flip_Entity.cs
│   │
│   ├── 📂 DbContext/                  # Контекст БД
│   │   └── To_Do_Flip_Context.cs
│   │
│   ├── 📂 Configuration/              # Конфигурации EF
│   │   └── To_Do_Flip_Configuration.cs
│   │
│   ├── 📂 Migrations/                 # Миграции БД
│   │   ├── 20260201125620_InitialCreate.cs
│   │   ├── 20260201125620_InitialCreate.Designer.cs
│   │   └── To_Do_Flip_ContextModelSnapshot.cs
│   │
│   ├── README.md                      # Документация
│   └── MIGRATIONS_COMMANDS.md         # Команды миграций
│
└── 📂 To-Do_Flip.Store/               # 📦 МОДЕЛИ
    ├── 📂 Model/                      # Доменные модели
    │   └── To_Do.cs
    │
    └── README.md                      # Документация
```

## 🔍 Сравнение с Flip

### Flip структура:
```
FlipChatAnon/
├── Controllers/
├── Hubs/
├── Middleware/
├── FlipStoreAnon.DbContext/
│   ├── FlipDbContext.cs
│   └── Configuration/
└── FlipChatStore/
    ├── UserData.cs
    ├── ChatRoom.cs
    └── ...
```

### FlipTask структура:
```
To-Do_Flip/
├── To-Do_Flip/Controllers/          ← Аналогично Controllers/
├── To-Do_Flip.DataAccess/            ← Аналогично FlipStoreAnon.DbContext/
│   ├── DbContext/
│   ├── Entity/
│   ├── Configuration/
│   └── Migrations/
└── To-Do_Flip.Store/                 ← Аналогично FlipChatStore/
    └── Model/
```

## ✅ Преимущества организации

- ✅ Все БД-связанное в `DataAccess/` (как `DbContext/` в Flip)
- ✅ Все модели в `Store/` (как `Store/` в Flip)
- ✅ Все контроллеры в `Controllers/` (как в Flip)
- ✅ Четкая структура папок
- ✅ README в каждой папке для навигации

## 📚 Документация

- [ORGANIZATION.md](./ORGANIZATION.md) - Подробная организация
- [STRUCTURE_GUIDE.md](./STRUCTURE_GUIDE.md) - Руководство по структуре
- [README.md](./README.md) - Основная документация

---

**Структура организована аналогично:** [Flip Repository](https://github.com/rem1xzov/Flip)
