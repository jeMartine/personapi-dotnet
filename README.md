# Lab 1 Arqui - Persona API con SQL Server
En este laboratorio tiene como objetivo la implementación de una aplicación monolítica utilizando el patrón Modelo-Vista-Controlador (MVC) junto con el patrón Data Access Object (DAO), usando el stack tecnológico de .NET 7, MS SQL Server 2022 y servicios REST documentados con Swagger 3, además con Docker Compose se pueden levantar ambos servicios de manera sencilla.

## Archivos DDL y DML
  - [persona DDl](https://github.com/jeMartine/personapi-dotnet/blob/main/ddl_persona_db.sql)
  - [persona DML](https://github.com/jeMartine/personapi-dotnet/blob/main/dml_persona_db.sql)


## Requisitos

- [Docker](https://www.docker.com/get-started) instalado
- [Docker Compose](https://docs.docker.com/compose/install/) instalado

## Clonar el proyecto

```bash
git clone https://github.com/jeMartine/personapi-dotnet
cd personapi-dotnet
```

## Levantar los contenedores con Docker

El proyecto incluye un `docker-compose.yml` que levanta dos servicios:  

1. **SQL Server** con la base de datos `persona_db` inicializada.  
2. **API .NET** que se conecta a la base de datos.

Para iniciar los contenedores:

```bash
docker-compose up --build
```

Esto hará lo siguiente:

- Construirá la imagen de SQL Server y la inicializará con los scripts DDL y DML.
- Construirá la imagen de la API y la conectará al contenedor de SQL Server.
- Los servicios estarán accesibles en:
  - API: `http://localhost:8080`
  - SQL Server: puerto `1433` en localhost (usuario: `sa`, contraseña: `Admin123!`)

## Detener los contenedores

```bash
docker-compose down
```

Para eliminar también los volúmenes (incluyendo la base de datos persistente):

```bash
docker-compose down -v
```

## Notas

- La API usa la conexión:  
  `Server=sqlserver,1433;Database=persona_db;User Id=sa;Password=Admin123!;TrustServerCertificate=True;`  
- SQL Server se inicializa automáticamente gracias al script `init-db.sh`.
- Si se presenta este error con `init-db.sh`.
  ```bash
  docker_sqlserver  | /bin/bash: /scripts/init-db.sh: /bin/bash^M: bad interpreter: No such file or directory dependency failed to start: container docker_sqlserver exited (126)
  ```
  Se recomienda abrir el archivo en Visual Studio Code o en algun editor que permita el cambio de salto de línea de `CRLF` a `lF`
  <img width="139" height="71" alt="image" src="https://github.com/user-attachments/assets/32e3c2e2-e16e-4749-9d4a-9f675bf41b30" />

  
