
**API**:

1. **Clonar el Repositorio**:
   - Clona el Repositorio

2. **Instalar .NET 8**:
   - Asegúrate de tener instalado el .NET 8 y en su defecto visual studio 2022.

3. **Restaurar Dependencias**:
   - Navega al directorio del proyecto:
     ```CMD
     cd <nombre del directorio\backend\TaskManager
     ```
   - Restaura las dependencias del proyecto con el comando:
     ```CMD
     dotnet restore
     ```
4. **Base de datos**:
   - En principio se realizo la gestion con Entity Framework y SQLLite asi que es importante tener SQLLite instalado en el equipo. (Se descarga y se actualiza el path del equipo con la ruta del ejecutable)
   -Luego de asegurarnos que la cadena de conexion este en los appsettings debemos ejecutar la migracion para que genere el modelo de la tabla y agregue la data de prueba ejecutamos. 
     ```CMD
     cd  .\TaskManager.Insfrastructure
     ```
     ubicandonos sobre el proyecto de infraestructura realizamos los siguientes comandos
      ```CMD
     dotnet ef migrations add InitialCreate --startup-project ../TaskManager.API
     dotnet ef database update --startup-project ../TaskManager.API
     ```
     lo cual nos va ejecutar la migracion y actualizar la base de datos que creemos en memoria "SQLLite"

5. **Iniciar la Aplicación**:
   - **Desde la Línea de Comandos**: Vuelve a la raiz del proyecto e ingresa al proyecto TaskManager.API:
     ```CMD
     cd .\TaskManager.API\
     ```
     Ejecuta la aplicación con el comando siguiente
      ```CMD
     dotnet run
     ```
   - **Desde Visual Studio**: Abre la solucion en Visual Studio, establete el proyecto TaskManager.API como proyecto de inicio y ejecuta directamente. Esto abrirá la aplicación en el navegador predeterminado.

6. **Acceder a Swagger**:
   - **Desde la Línea de Comandos**: Abre tu navegador y visita [http://localhost:7066/swagger/index.html] (o la URL proporcionada en la consola).
   - **Desde Visual Studio**: La aplicación debería abrirse automáticamente en tu navegador. Si no es así, copia la URL proporcionada en la consola de salida de Visual Studio y pégala en el navegador.

7. **Endpoints**:
   - **Tasks**:
     - `GET /api/tasks`: Obtiene todas las tareas, los filtros se ingresan por query string. ejemplo [https://localhost:7066/api/tasks?title=prueba&isCompleted=true]
     si no se ingresa ningun filtro devuelve todos los datos.
     - `POST /api/tasks`: Crea una tarea
     - `Delete /api/tasks/{id}`: Elimina la tarea.
     - `PATCH /api/tasks/{id}`: Actualiza el estado de la tarea no se utiliza PUT ya que la actualizacion no es total, solo se le actualiza el estado en este caso la mejor opcion es PATCH.

8. **Realizar Consultas**:
   Utiliza la interfaz de Swagger para enviar solicitudes a los diferentes endpoints y ver las respuestas.
   Para más detalles sobre cada endpoint, consulta la documentación interactiva en Swagger.


**FRONTEND**:
## Requisitos

- [Node.js](https://nodejs.org/) (Versión 18.20 o superior recomendada)
- [Angular CLI](https://angular.io/cli) (Se instalará automáticamente al instalar las dependencias del proyecto)

## Instalación

1. **Clona el repositorio:**

2. **instalar Dependencias**:
   - Navega al directorio del proyecto:
     ```CMD
     cd <nombre del directorio\frontend\TaskManager.WEB\
     ```
   - instala las dependencias del proyecto con el comando:
     ```CMD
     npm install
     ```

3. **Ejecutar aplicación**:
   - Ejecuta la aplicación:
     ```CMD
     ng serve
     ``` Esto abrirá la aplicación en tu navegador predeterminado en http://localhost:4200. si  este se encuentra ocupado se debera tomar el que nos salga en consola.
   ```
4. **API**:
   -En caso de que el api se encuentre iniciada en un puerto distinto al https://localhost:7066 se debe realizar el ajuste en el archivo environment.ts para que no halla problemas
   con la comunicacion.



##Angel Larios Alvarado