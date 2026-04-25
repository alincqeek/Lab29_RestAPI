# Лабораторная работа №29: Создание RESTful API на ASP.NET Core

## Основная информация

**ФИО:** KuzVah 
**Группа:** ИСП-233  
**Дата:** 25.04.2026

## Краткое описание работы

В ходе лабораторной работы изучены принципы архитектуры REST и создан полноценный RESTful API на ASP.NET Core с использованием Controller-based подхода. Реализован контроллер для управления задачами (`TaskItem`) с полным набором CRUD-операций, дополнительными методами фильтрации, поиска, сортировки и статистики. Освоены инструменты тестирования API (Swagger UI, REST Client в VS Code), принципы работы DTO, правильные HTTP-статусы ответов, а также настройка CORS.

## Структура проекта
Lab29_RestAPI/
├── TaskApi/
│   ├── Controllers/
│   │   └── TasksController.cs
│   ├── Models/
│   │   ├── TaskItem.cs
│   │   ├── CreateTaskDto.cs
│   │   └── UpdateTaskDto.cs
│   ├── Properties/
│   │   └── launchSettings.json
│   ├── Program.cs
│   ├── requests.http
│   └── TaskApi.csproj
├── img/
│   ├── gitPushLab29_FIO.png
│   ├── step2_modelsLab29_FIO.png
│   ├── step3_swaggerLab29_FIO.png
│   ├── step4_swaggerTestsLab29_FIO.png
│   ├── step5_restClientLab29_FIO.png
│   ├── step6_extraRoutesLab29_FIO.png
│   └── step7_programLab29_FIO.png
├── .gitignore
├── .editorconfig
└── README.md


## Список реализованных маршрутов (API Endpoints)

| Метод  | URL | Описание |
|--------|-----|-----------|
| GET | `/api/tasks` | Получить все задачи (с фильтром `?completed=true/false`) |
| GET | `/api/tasks/{id}` | Получить задачу по ID |
| GET | `/api/tasks/search?query={text}` | Поиск задач по заголовку или описанию |
| GET | `/api/tasks/priority/{level}` | Получить задачи с указанным приоритетом (Low/Normal/High) |
| GET | `/api/tasks/stats` | Получить статистику (всего, выполнено, не выполнено, по приоритетам) |
| GET | `/api/tasks/sorted?by={field}&desc={bool}` | Сортировка задач (по приоритету или дате создания) |
| POST | `/api/tasks` | Создать новую задачу (принимает `CreateTaskDto`) |
| PUT | `/api/tasks/{id}` | Полностью обновить задачу (принимает `UpdateTaskDto`) |
| PATCH | `/api/tasks/{id}/complete` | Переключить статус выполнения задачи |
| DELETE | `/api/tasks/{id}` | Удалить задачу |

## Итоговая таблица: ASP.NET Core Controller-based API

| Аспект | ASP.NET Core Controllers |
|--------|---------------------------|
| Маршруты | `[HttpGet]` атрибут над методом |
| Группировка маршрутов | Класс-контроллер |
| Базовый URL | `[Route("api/[controller]")]` |
| Параметр пути | `(int id)` — параметр метода |
| Параметр запроса | `[FromQuery] bool? completed` |
| Тело запроса | `[FromBody] CreateTaskDto dto` |
| Ответ 200 | `return Ok(data)` |
| Ответ 201 | `return CreatedAtAction(...)` |
| Ответ 404 | `return NotFound(...)` |
| Ответ 204 | `return NoContent()` |
| Типизация данных | Строгая (C#) |
| Документация | Swagger (Swashbuckle) — устанавливается отдельно |

## Главные выводы

1. **REST — это стиль, а не стандарт**. Принципы REST (stateless, единый интерфейс, клиент-сервер) применимы к любому языку и фреймворку, а не только к ASP.NET.

2. **Контроллеры ASP.NET Core** выполняют ту же роль, что и Router в Express.js, но предоставляют встроенную генерацию документации (Swagger) и строгую типизацию C#, что снижает количество ошибок на этапе разработки.

3. **DTO (Data Transfer Object) защищают API**. Использование DTO (`CreateTaskDto`, `UpdateTaskDto`) позволяет серверу контролировать, какие поля клиент может передавать, предотвращая подмену служебных полей (`Id`, `CreatedAt`).

4. **Swagger UI и REST Client** ускоряют разработку и тестирование: первый позволяет интерактивно проверять API в браузере, второй — хранить набор запросов рядом с кодом (файлы `.http`), что удобно для повторного использования и командной работы.

5. **Правильные HTTP-статусы** являются частью контракта API. Клиент (будь то JavaScript, мобильное приложение или другой сервис) ориентируется на код ответа (`200`, `201`, `400`, `404`, `204`), а не только на тело ответа.