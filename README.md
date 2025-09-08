# 🏠 InmoSys - Sistema de Gestión Inmobiliaria

## 📖 Documentación Completa

La documentación técnica detallada del proyecto está disponible aquí:  
[**🔗 Ver Documentación Técnica con DeepSeek Wiki**](https://deepwiki.com/marcas1216/InmoSys)

---

## 🛠️ Stack Tecnológico

| Tecnología | Versión |
|------------|---------|
| **.NET** | 5.0+ |
| **SQL Server** | 2019+ |
| **C#** | 9.0+ |
| **nUnit** | 3.13+ |
| **Entity Framework Core** | 5.0+ |
| **ASP.NET Core** | 5.0+ |

---

## 📋 Prerrequisitos

Antes de ejecutar el proyecto, asegúrate de tener instalado:

- [ ] .NET 5.0 SDK o superior
- [ ] SQL Server Express LocalDB
- [ ] SQL Server Management Studio (SSMS) - Opcional pero recomendado
- [ ] Postman para pruebas de API

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

