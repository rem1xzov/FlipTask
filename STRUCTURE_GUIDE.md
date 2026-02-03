# 📚 Руководство по структуре проекта FlipTask

## 🎯 Быстрая навигация

### 🗄️ Все файлы БАЗЫ ДАННЫХ находятся здесь:
```
📂 To-Do_Flip.DataAccess/
   ├── Entity/              ← Модели таблиц БД
   ├── DbContext/          ← Контекст БД
   ├── Configuration/      ← Конфигурации EF
   └── Migrations/         ← Миграции БД
```

### 📦 Все файлы МОДЕЛЕЙ находятся здесь:
```
📂 To-Do_Flip.Store/
   └── Model/              ← Доменные модели

📂 To-Do_Flip.DataAccess/
   └── Entity/             ← Entity модели (для БД)
```

## 📊 Детальная структура

### 🗄️ База данных (Database)

**Расположение:** `To-Do_Flip.DataAccess/`

| Папка | Содержимое | Файлы |
|-------|-----------|-------|
| `Entity/` | Entity Framework модели | `To-Do_Flip_Entity.cs` |
| `DbContext/` | Контекст БД | `To_Do_Flip_Context.cs` |
| `Configuration/` | Конфигурации EF | `To_Do_Flip_Configuration.cs` |
| `Migrations/` | Миграции БД | `20260201125620_InitialCreate.cs` и др. |

### 📦 Модели (Models)

**Расположение:** 
- Доменные модели: `To-Do_Flip.Store/Model/`
- Entity модели: `To-Do_Flip.DataAccess/Entity/`

| Тип модели | Расположение | Файл | Назначение |
|-----------|-------------|------|-----------|
| Доменная модель | `Store/Model/` | `To_Do.cs` | Бизнес-логика и валидация |
| Entity модель | `DataAccess/Entity/` | `To-Do_Flip_Entity.cs` | Работа с БД через EF |

## 🔍 Где что искать

### Ищу файлы БД?
→ Иди в `To-Do_Flip.DataAccess/`

### Ищу модели?
→ Доменные: `To-Do_Flip.Store/Model/`
→ Entity (БД): `To-Do_Flip.DataAccess/Entity/`

### Ищу миграции?
→ `To-Do_Flip.DataAccess/Migrations/`

### Ищу конфигурацию БД?
→ `To-Do_Flip.DataAccess/Configuration/`

## 📁 Полная структура проекта

```
To-Do_Flip/
│
├── 📂 To-Do_Flip/                    # Web API
│   ├── Controller/                   # API контроллеры
│   ├── Contract/                     # DTOs
│   └── Program.cs                     # Точка входа
│
├── 📂 To-Do_Flip.Application/         # Бизнес-логика
│   ├── Service/                       # Сервисы
│   └── Repository/                    # Репозитории
│
├── 📂 To-Do_Flip.DataAccess/          # 🗄️ ВСЕ БД-СВЯЗАННОЕ
│   ├── Entity/                        # Entity модели
│   ├── DbContext/                     # Контекст БД
│   ├── Configuration/                 # Конфигурации EF
│   └── Migrations/                    # Миграции БД
│
└── 📂 To-Do_Flip.Store/               # 📦 ДОМЕННЫЕ МОДЕЛИ
    └── Model/                         # Доменные модели
```

## 💡 Примечания

- ✅ Все БД-связанное находится в `DataAccess`
- ✅ Все доменные модели находятся в `Store`
- ✅ Структура следует принципам Clean Architecture
- ✅ Четкое разделение ответственности

## 🔗 Полезные ссылки

- [README.md](../README.md) - Основная документация
- [PROJECT_STRUCTURE.md](../PROJECT_STRUCTURE.md) - Детальная структура
- [MIGRATIONS_COMMANDS.md](./To-Do_Flip.DataAccess/MIGRATIONS_COMMANDS.md) - Команды миграций
