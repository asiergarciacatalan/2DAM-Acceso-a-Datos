# 🗄️ Acceso a Datos — 2º DAM

![C#](https://img.shields.io/badge/C%23-239120?logo=csharp&logoColor=white) ![.NET](https://img.shields.io/badge/.NET-512BD4?logo=dotnet&logoColor=white) ![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?logo=microsoftsqlserver&logoColor=white)

Prácticas de la asignatura **Acceso a Datos** del ciclo de Desarrollo de Aplicaciones Multiplataforma (curso 2026-2027). Trabajo con C# y .NET la persistencia de información: ficheros, formatos de intercambio y bases de datos.

## 📂 Contenido

| Carpeta | Qué hay | Conceptos |
|---|---|---|
| [`Tema1-Programacion-CSharp`](Tema1-Programacion-CSharp) | Ejercicios de iniciación a C# (.NET Framework 4.8 y .NET 10) | Tipos, colecciones, POO, herencia, interfaces |
| [`Tema2-Persistencia-Ficheros`](Tema2-Persistencia-Ficheros) | **MedidorFormatos**: lee y compara CSV, JSON y XML | `System.Text.Json`, `XmlSerializer`, validación de ficheros corruptos |
| [`Tema3-Persistencia-Base-de-Datos`](Tema3-Persistencia-Base-de-Datos) | Scripts SQL Server | Claves, restricciones `CHECK`, borrado lógico |
| [`Investigacion-Cassandra-vs-SQLServer`](Investigacion-Cassandra-vs-SQLServer) | Presentación y guion comparando NoSQL y SQL | Modelo de datos, escalabilidad, casos de uso |

## ⭐ Proyecto destacado: MedidorFormatos

Aplicación de consola que carga el mismo conjunto de datos (coches) desde **CSV, JSON y XML**, compara resultados entre formatos y comprueba cómo reacciona ante ficheros mal formados (campo vacío, separador de más, coma olvidada, etiqueta sin cerrar…), incluidos en `pruebas/`.

```bash
cd Tema2-Persistencia-Ficheros/MedidorFormatos
dotnet run
```

## 🛠️ Requisitos
- .NET 10 SDK (y .NET Framework 4.8 para los proyectos del Tema 1)
- Visual Studio 2022 o superior
- SQL Server Express para los scripts del Tema 3

---
👤 **Asier García Catalán** · [GitHub](https://github.com/asiergarciacatalan)
