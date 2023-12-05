# Inwentaryzacja

This repository presents my contribution to the group project. <br>
Final product had more functionalities done by other members of our project group. <br>
Images at the bottom of readme.

## Technologies

<li>
 C#
</li>
<li>
 .NET 7.0
</li>
<li>
 ASP.NET Core
</li>
<li>
 Angular 16
</li>
<li>
 Typescript
</li>
<li>
 PostgreSQL
</li>
<li>
 Docker
</li>

## Docker instruction
<details>
  <summary>Docker / Migracje</summary>
  1. Instalacja Dockera

Jeżeli pojawi się komunikat, to należy zaktualizować WSL: w cmd użyć:
```wsl --update```

2. Pobranie PostgreSQL:
```docker pull postgres```

3. Tworzenie nowego kontenera "RekordSI":
```docker run -d -p 5432:5432 --name RekordSI -e PGUSER=postgres -e POSTGRES_HOST_AUTH_METHOD=trust postgres```

4. Wchodzenie do konsoli dockera:
```docker exec -it RekordSI bash```

5. Tworzenie bazy danych "inventory" dla użytkownika "postgres":
```createdb -U postgres inventory```

6. Wyjście z dockerowej konsoli:
```exit```



7. Aktualizacja bazy danych:

Dla Visual Studio:
W Konsoli menadżera pakietów:
```Update-Database```

lub

Poza IDE:
CMD w folderze z aplikacją backendową (ten który zawiera Program.cs)
```dotnet ef database update --connection "Server=localhost;Port=5432;Database=inventory;User Id=postgres;"```

Jeżeli pojawił się błąd i komunikat mówi o braku narzędzia dotnet ef, uruchom polecenie:
```dotnet tool install --global dotnet-ef```



Tworzenie nowej migracji (to robimy tylko jak zaszły duże zmiany w modelu bazodanowym):

Po dużych zmianach Modelowych w programie należy usunąć ModelSnapshot z folderu Migrations (może być konieczne usunięcie poprzednich migracji).

Dla Visual Studio:
W Konsoli menadżera pakietów:
```Add-Migration```

lub

Poza IDE:
CMD w folderze z aplikacją backendową (ten który zawiera Program.cs)
```dotnet ef migrations add NazwaMigracji```
  
</details>

## Images
![image 1](https://github.com/Motrixox/Inwentaryzacja/blob/main/images/1.PNG?raw=true)
![image 2](https://github.com/Motrixox/Inwentaryzacja/blob/main/images/2.PNG?raw=true)
![image 3](https://github.com/Motrixox/Inwentaryzacja/blob/main/images/3.PNG?raw=true)
![image 4](https://github.com/Motrixox/Inwentaryzacja/blob/main/images/4.PNG?raw=true)
![image 5](https://github.com/Motrixox/Inwentaryzacja/blob/main/images/5.PNG?raw=true)
![image 6](https://github.com/Motrixox/Inwentaryzacja/blob/main/images/6.PNG?raw=true)
![image 7](https://github.com/Motrixox/Inwentaryzacja/blob/main/images/7.PNG?raw=true)
![image 8](https://github.com/Motrixox/Inwentaryzacja/blob/main/images/8.PNG?raw=true)
![image 9](https://github.com/Motrixox/Inwentaryzacja/blob/main/images/9.PNG?raw=true)
![image 10](https://github.com/Motrixox/Inwentaryzacja/blob/main/images/10.PNG?raw=true)
![image 11](https://github.com/Motrixox/Inwentaryzacja/blob/main/images/11.PNG?raw=true)
![image 12](https://github.com/Motrixox/Inwentaryzacja/blob/main/images/12.PNG?raw=true)
![image 13](https://github.com/Motrixox/Inwentaryzacja/blob/main/images/13.PNG?raw=true)
![image 14](https://github.com/Motrixox/Inwentaryzacja/blob/main/images/14.PNG?raw=true)
