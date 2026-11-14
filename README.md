# 🗄️ Acceso a Datos — 2º DAM

![C#](https://img.shields.io/badge/C%23-239120?logo=csharp&logoColor=white) ![.NET](https://img.shields.io/badge/.NET-512BD4?logo=dotnet&logoColor=white) ![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?logo=microsoftsqlserver&logoColor=white)

Prácticas de la asignatura **Acceso a Datos** del ciclo de Desarrollo de Aplicaciones Multiplataforma (curso 2026-2027). Trabajo con C# y .NET la persistencia de información: ficheros, formatos de intercambio y bases de datos.

## 📂 Contenido

| Carpeta | Qué hay | Conceptos |
|---|---|---|
| [`Tema1-Programacion-CSharp`](Tema1-Programacion-CSharp) | `EjerciciosTema1`: 27 ejercicios (Ejercicio01-10, C1_C7, C8_C9, C10, C13) | Tipos, condicionales, bucles, colecciones, métodos, POO, herencia, interfaces, records, LINQ |
| [`Tema2-Persistencia-Ficheros`](Tema2-Persistencia-Ficheros) | `EjerciciosTema2`: 18 ejercicios (Ejercicio01-10, C1_C2, C4) y **MedidorFormatos** | `File`, `Directory`, `Path`, `using`, CSV, `System.Text.Json`, `XmlSerializer`, binarios y `Seek` |
| [`Tema3-Persistencia-Base-de-Datos`](Tema3-Persistencia-Base-de-Datos) | `EjerciciosTema3`: 10 ejercicios con ADO.NET, **CRUD_Personal** y scripts SQL | `SqlConnection`, parámetros, inyección SQL, borrado lógico, patrón Repository, transacciones |
| [`Investigacion-Cassandra-vs-SQLServer`](Investigacion-Cassandra-vs-SQLServer) | Presentación y guion comparando NoSQL y SQL | Modelo de datos, escalabilidad, casos de uso |

## ▶️ Cómo abrir los ejercicios

Cada tema tiene una solución (`.slnx`) que abre todos sus ejercicios en Visual Studio:

- `Tema1-Programacion-CSharp/EjerciciosTema1/EjerciciosTema1.slnx`
- `Tema2-Persistencia-Ficheros/EjerciciosTema2/EjerciciosTema2.slnx`
- `Tema3-Persistencia-Base-de-Datos/EjerciciosTema3/EjerciciosTema3.slnx`

Cada ejercicio es un proyecto de consola independiente: clic derecho → *Establecer como proyecto de inicio* y ejecutar.
En el Tema 3 ejecuta primero `Ejercicio01`, que crea la base de datos `Tema03` en SQL Server LocalDB.

## ⭐ Proyecto destacado: MedidorFormatos

Aplicación de consola que carga el mismo conjunto de datos (coches) desde **CSV, JSON y XML**, compara resultados entre formatos y comprueba cómo reacciona ante ficheros mal formados (campo vacío, separador de más, coma olvidada, etiqueta sin cerrar…), incluidos en `pruebas/`.

```bash
cd Tema2-Persistencia-Ficheros/MedidorFormatos
dotnet run
```

## 🛠️ Requisitos
- .NET 10 SDK (y .NET Framework 4.8 para los proyectos del Tema 1)
- Visual Studio 2022 o superior
- SQL Server LocalDB (viene con Visual Studio) para el Tema 3

---
👤 **Asier García Catalán** · [GitHub](https://github.com/asiergarciacatalan)
