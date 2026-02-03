# Инструкция по запуску приложения через Docker

## Требования
- Docker Desktop установлен и запущен
- Docker Compose (входит в Docker Desktop)

## Быстрый старт

1. **Откройте терминал в корне проекта** (где находится `docker-compose.yml`)

2. **Соберите и запустите контейнеры:**
   ```bash
   docker-compose up -d --build
   ```

3. **Проверьте, что контейнеры запущены:**
   ```bash
   docker-compose ps
   ```

4. **Откройте фронтенд:**
   - Откройте файл `FlipTask.html` в браузере
   - Или разместите его на веб-сервере

## Доступ к приложению

- **API:** http://localhost:8080/api/tasks
- **PostgreSQL:** localhost:5432
  - База данных: `To_Do_Flip`
  - Пользователь: `postgres`
  - Пароль: `123456`

## Полезные команды

### Остановить контейнеры
```bash
docker-compose down
```

### Остановить и удалить volumes (удалит данные БД)
```bash
docker-compose down -v
```

### Просмотр логов
```bash
docker-compose logs -f api
```

### Пересобрать контейнеры
```bash
docker-compose up -d --build
```

### Войти в контейнер API
```bash
docker exec -it todo_flip_api /bin/bash
```

### Войти в контейнер PostgreSQL
```bash
docker exec -it todo_flip_postgres psql -U postgres -d To_Do_Flip
```

## Структура

- `Dockerfile` - конфигурация для сборки образа .NET приложения
- `docker-compose.yml` - конфигурация для запуска всех сервисов
- `.dockerignore` - файлы, исключаемые из сборки

## Миграции базы данных

Миграции применяются автоматически при запуске контейнера API.

## Настройка для продакшена

Для продакшена рекомендуется:
1. Изменить пароли в `docker-compose.yml`
2. Использовать переменные окружения для секретов
3. Настроить HTTPS
4. Использовать reverse proxy (nginx)
5. Настроить резервное копирование базы данных
