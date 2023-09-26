# SofTk_TechOil

**Descripción:** Este proyecto ha sido desarrollado utilizando .NET Core 6 y tiene como objetivo proporcionar una solución moderna y efectiva para la digitalización y automatización del proceso de control de horas de servicio en la empresa TechOil.

## Especificación de la Arquitectura

### Capa Controller
- **Descripción:** La Capa Controller se encarga de recibir las solicitudes HTTP entrantes, procesarlas y enviar las respuestas correspondientes. Juega un papel fundamental en la arquitectura de la aplicación y es responsable de la gestión de las rutas y la interacción con los endpoints de la API.

### Capa DataAccess
- **Descripción:** La Capa DataAccess es responsable de gestionar toda la interacción con la base de datos. Su objetivo es proporcionar una interfaz limpia y eficiente para acceder y manipular datos almacenados en la base de datos.

### Capa Entities
- **Descripción:** La Capa Entities se encarga de definir y modelar las estructuras de datos que representan las entidades de la aplicación. Estas entidades se corresponden con las tablas de la base de datos relacional y representan objetos del mundo real con sus propiedades y relaciones.

### Capa Repositories
- **Descripción:** En la Capa Repositories se definen las clases correspondientes para realizar el repositorio genérico y la unidad de trabajo.

### Capa Core
- **Descripción:** La Capa Core es el componente central que proporciona funcionalidades compartidas, estructura y lógica común que son esenciales para el funcionamiento de la aplicación en su conjunto. Se compone de varios subniveles:

	- **Helper:** En esta sección se define lógica que puede ser de utilidad para todo el proyecto, como métodos para encriptar/desencriptar contraseñas, paginación, etc.
	- **Interfaces:** Se definen las interfaces que utilizaremos en los servicios.
	- **Models:** En esta carpeta se definen modelos que representan objetos específicos o estructuras de datos utilizados en la aplicación. Esto incluye modelos de DTO, que se utilizan para transmitir datos entre las capas, así como modelos de dominio que representan conceptos de negocio.
	- **Services:** La carpeta Services contiene clases y lógica de servicio que implementan operaciones específicas de la aplicación. Estos servicios encapsulan la lógica de negocio y se utilizan en la Capa de Servicios para realizar operaciones complejas.

## Especificación de GIT

- **Descripción:** En este proyecto, se utiliza una estrategia de gestión de ramas que facilita la colaboración y el seguimiento de cada implementación. A continuación, se detallan algunas de las prácticas clave:

	- Todas las ramas se crean a partir de la rama `develop`. Esta rama representa la última versión de desarrollo y es donde se integran las características antes de su liberación.
	- Cada Pull Request (PR) está asociado a un número de historia o característica específica, lo que facilita la trazabilidad de los cambios en relación con los requisitos del proyecto.
	- Se sigue una política clara de gestión de ramas, donde `master` es la rama principal de producción y `develop` es la rama de desarrollo.
	- No se realizan cambios directamente en `master`. En su lugar, los cambios se integran a través de PRs desde `develop`.

Este enfoque de gestión de ramas asegura un flujo de trabajo ordenado y la capacidad de rastrear el progreso y los cambios en cada característica o mejora. Facilita la colaboración efectiva entre los miembros del equipo y mantiene un control de versiones preciso.




