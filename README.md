
The project was created by Oleksandr Havlytskyi for educational purposes.
____
**Technology or principles have been mastered( or repeated):** ASP.NET Core MVC, Razor Pages, DI, MSSQL Serve, Drapper, ADO.NET, DAO. 
____
**The purpose of the project:** Learn to create a web application(website) to store/get data in a database not use the framework.

**Task description:** 1. Створити додаток обліку даних користувачів (Дані про працівників компанії), використовуючи ООП на c# Asp.net.
Зберігання даних та їх використання зробити на рівні БД ( привевши до НФ )

Що потрібно зберігати:

1) Відділ.
2) Посада.
3) ПІБ.
4) Адреса.
5) Телефон.
6) Дата народження.
7) Дата взяття на роботу.
8) Оклад
9) Інформація про компанію.
Подумати і правильно відокремити зберігання даних, щоб дані зберігалися атомарно.
використовувати прямі запити ( не ентіті )


Що до меню додатка:

1) Головна сторінка (Меню  +  Інформація про компанію)

2) сторінка перегляду персоналу з фільтрами пошуку
(тобто наявність фільтрів для швидкого пошуку персоналу ) наприклад по посаді, відділу, ПІБ тощо.
	2.1 Картка працівника -> передбачити можливість редагувати дані по працівнику.
3) Зарплатна звітність -> сторінка де можна в залежності від фільтрів отримати інформацію по працівниках, наприклад: вибрали відділ натиснули сформувати вивелась загальна сума окладів по цьому відділу… далі фільтри на свій розсуд (було б добре якщо це можна було б переглянути в табличці в самому додатку.
	3.1 Зробити вивантаження відфільтрованих даних в txt файл.
