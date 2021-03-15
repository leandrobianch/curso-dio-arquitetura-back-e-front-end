# 
Projetando e desenvolvendo uma aplicação de login seguro usando ASP.NET Core MVC

1. Subindo o container docker em SQL SERVER
```
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=App@223020" --name sqldica -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest
```
