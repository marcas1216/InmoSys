# 🏠 InmoSys - Sistema de Gestión Inmobiliaria

## 📖 Documentación Completa

La documentación técnica detallada del proyecto está disponible aquí:  
[**🔗 Ver Documentación Técnica con DeepSeek Wiki**](https://deepwiki.com/marcas1216/InmoSys)

---

## 🛠️ Stack Tecnológico

| Tecnología | Versión |
|------------|---------|
| **.NET** | 8.0 |
| **SQL Server** | 18.10 |
| **C#** | 12.0 |
| **nUnit** | 3.14.0 |
| **Entity Framework Core** | 8.0.19 |

---

## 📋 Prerrequisitos

Antes de ejecutar el proyecto, asegúrate de tener instalado:

- 🖥️ **IDE .NET** (Visual Studio o Visual Studio Code con extensión C#)
- 🗄️ **SQL Server Express LocalDB**
- 📊 **SQL Server Management Studio (SSMS)** 
- 🔹 **Postman** para pruebas de API


---

## 🚀 Guía de Ejecución Rápida

### Paso 1: Levantar Servidor de Base de Datos
```bash
# Iniciar LocalDB con el nombre requerido
sqllocaldb create "Generals"
sqllocaldb start "Generals"

## 🧪 Pruebas con Postman

### 1. **Importar colección**
   - **Archivo:** `InmoSys.postman_collection.json`

### 2. **Generar token**
Primero, ejecute la petición de Login para obtener el token de autenticación, necesario para ejecutar y probar las demás solicitudes.

📊 **Documentación Adjunta**

| Documento            | Descripción                          | Archivo                                              |
|--------------------- |--------------------------------------|------------------------------------------------------|
| Diseño Técnico       | Arquitectura y diseño del sistema    | DT Gestión de Información Inmobiliaría.pdf           |
| Pruebas Funcionales  | Casos de prueba y validaciones       | PF Gestión de Información Inmobiliaria - InmoSys.pdf |
| Diccionario de Datos | Estructura completa de base de datos | Diccionario_Datos_InmoSys.pdf                        |


