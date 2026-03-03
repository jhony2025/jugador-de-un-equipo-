# Torneo de Fútbol — Gestión de Equipos y Jugadores

## Descripción
Este repositorio contiene una pequeña aplicación de consola en C# para gestionar equipos y jugadores de un torneo de fútbol. Permite registrar equipos, agregar y eliminar jugadores, buscar jugadores y contar jugadores por equipo. El código principal se encuentra en `jugador1.cs`.

## Características
- Registrar equipos.
- Agregar jugadores a equipos (sin duplicados por equipo).
- Eliminar jugadores.
- Buscar en qué equipo(s) está un jugador.
- Contar jugadores por equipo.
- Entradas validadas para minimizar errores en tiempo de ejecución.

## Estructura del repositorio
- `jugador1.cs` — Código fuente principal (aplicación de consola en C#).
- `README.md` — Este archivo con instrucciones y ejemplos.

## Requisitos
- .NET SDK (recomendado) instalado para compilar y ejecutar con `dotnet`.
	- Comprobar instalación:

```powershell
dotnet --version
```

- Opcional: compilador `csc` (parte de algunas instalaciones de .NET/Visual Studio) si prefieres compilar con `csc`.

## Ejecución rápida (usando `dotnet`)
Se ha probado creando un proyecto temporal que usa `jugador1.cs`. Para ejecutar localmente con `dotnet` puedes crear un proyecto y reemplazar `Program.cs` por `jugador1.cs`, o ejecutar desde el proyecto temporal que se creó durante las pruebas:

```powershell
# Crear proyecto y ejecutar (ejemplo)
dotnet new console -o build_temp --force
Copy-Item "jugador1.cs" -Destination "build_temp\Program.cs" -Force
dotnet run --project build_temp
```

Cuando corra, verás un menú interactivo. Ejemplo de uso:
1. Seleccionar opción `1` para registrar equipo.
2. Ingresar nombre del equipo (se aplica `.Trim()` y es caso-insensible).
3. Seleccionar opción `2` para agregar jugador y seguir las instrucciones.

## Compilar con `csc` (opcional)
Si tienes `csc` disponible, puedes compilar directamente:

```powershell
csc "jugador1.cs"
.\jugador1.exe
```

> Nota: Si `csc` no está en el PATH, usa el método `dotnet` mostrado arriba.

## Cambios y validaciones realizadas
- Se añadieron validaciones para entradas de consola (`int.TryParse`, comprobaciones de `null`/vacío y `.Trim()`), para evitar excepciones al introducir valores inválidos.
- El diccionario de equipos y los conjuntos de jugadores usan comparadores insensibles a mayúsculas (`StringComparer.OrdinalIgnoreCase`), para tratar "Real" y "real" como el mismo equipo/jugador.
- Se añadieron mensajes de usuario para entradas inválidas.

## Buenas prácticas y recomendaciones
- Ingresar números válidos en el menú (1–7). Si se ingresa texto, el programa pedirá reintento.
- Evitar nombres vacíos para equipos o jugadores.
- Para ampliar la app: persistencia (archivo/BD), exportar/importar listas, interfaz gráfica o web.

## Contribuciones
- Forkea el repositorio y abre un PR describiendo los cambios.
- Para cambios en la lógica, añade pruebas unitarias y documenta el comportamiento.

- (MIT) si deseas compartir el código públicamente.
---

- Autor: Johnny Alberto Vera Vaca 
- Universidad Estatal Amazónica 
