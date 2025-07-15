# RiskTrackSCF - API de Creación 
## Descripción

**RiskTrackSCF_UserCreatorAPI** es un microservicio RESTful diseñado como parte del ecosistema **RiskTrackSCF**. Su principal responsabilidad es la gestión de usuarios y compañias, proporcionando endpoints para registrar nuevos usuarios y compañias, 
y consultar la información de los existentes.

Esta API está construida con el framework Spring Boot y utiliza Spring Data JPA para la persistencia de datos en una base de datos MySQL.

## Características Principales

*   **Registro de Usuarios:** Endpoint para crear un nuevo usuario en el sistema.
*   **Consulta de Usuarios:** Endpoints para obtener una lista de todos los usuarios o un usuario específico por su ID.
*   **Registro de Compañias:** Endpoint para crear una nueva compañia en el sistema.
*   **Consulta de Compañias:** Endpoints para obtener una lista de todas las compañias o una compañia específico por su ID.
*   **Arquitectura REST:** Sigue los principios de la arquitectura REST para una integración sencilla.

## Requisitos Previos

*   **.NET SDK** (se recomienda .NET 6.0 o superior).
*   **Microsoft SQL Server** (una instancia local o remota).

## Instalación y Ejecución

1.  **Clona el repositorio:**
    ```bash
    git clone https://github.com/Kpiiale/RiskTrackSCF_UserCreatorAPI.git
    cd RiskTrackSCF_UserCreatorAPI
    ```

2.  **Configura la aplicación:**
    *   Crea el archivo `appsettings.json` en el proyecto.
    *   Modifica los valores de configuración según la guía que se detalla en appsettings.template.json reemplazando lo que se encuentra en mayúsculas con tus datos. 

3.  **Ejecuta la aplicación desde la terminal:**
    ```bash
    # Restaura las dependencias (paquetes NuGet)
    dotnet restore

    # Compila el proyecto
    dotnet build

    # Inicia la aplicación
    dotnet run
    ```
