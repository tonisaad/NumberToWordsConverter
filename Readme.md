# Number to Words Converter API

A .NET Web API solution that converts currency amounts (numbers with optional decimal cents) into their English words representation

---

## Prerequisites

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download) (or matching .NET SDK configured for the project)
- Any modern IDE/editor (JetBrains Rider, Visual Studio) or the `dotnet` CLI

---

## Solution Structure

- **`NumberToWordsConverter.Api`**: ASP.NET Core Web API project hosting the conversion endpoint.
- **`NumberToWordsConverter.Tests`**: Unit test suite covering conversion logic and edge cases.

---

## How to Build

From the root directory of the repository, execute:

```bash
dotnet build NumberToWordsConverter.sln
```

To perform a clean build:

```bash
dotnet clean NumberToWordsConverter.sln
dotnet build NumberToWordsConverter.sln -c Release
```

---

## How to Run & Host

### Running Locally with .NET CLI

To start the API application:

```bash
dotnet run --project NumberToWordsConverter.Api/NumberToWordsConverter.Api.csproj
```

By default, the application listens on:
- **HTTP**: `http://localhost:5188`
- **HTTPS**: `https://localhost:7109`

### Running via JetBrains Rider / Visual Studio

1. Open `NumberToWordsConverter.sln`.
2. Select the `NumberToWordsConverter.Api` run profile (HTTP or HTTPS).
3. Press **Run** (or `Shift + F10` / `Ctrl + F5`).

### Publishing for Production Hosting

To publish self-contained or framework-dependent binaries:

```bash
dotnet publish NumberToWordsConverter.Api/NumberToWordsConverter.Api.csproj -c Release -o ./publish
```

You can host the output DLL (`NumberToWordsConverter.Api.dll`) on:
- **Kestrel / Reverse Proxy (Nginx, Apache, IIS)**: `dotnet ./publish/NumberToWordsConverter.Api.dll`
- **Docker / Container Hosting**: Package the publish directory into an ASP.NET runtime image.
- **Azure App Service / AWS / Cloud hosting**: Deploy the published output folder directly.

---

## How to Interact with the API

### Endpoint Overview

- **Route**: `POST /api/converter`
- **Content-Type**: `application/json`

### Request Payload

| Field | Type | Required | Description | Example |
| :--- | :--- | :--- | :--- | :--- |
| `amount` | string | Yes | Numerical amount with optional decimal cents | `"123.45"` |

#### Request Body Example:
```json
{
  "amount": "123.45"
}
```

### Example Interaction Methods

#### 1. Using `curl` (PowerShell / Bash)

```bash
curl -X POST http://localhost:5188/api/converter \
  -H "Content-Type: application/json" \
  -d "{\"amount\": \"123.45\"}"
```

In PowerShell:
```powershell
Invoke-RestMethod -Uri "http://localhost:5188/api/converter" -Method Post -ContentType "application/json" -Body '{"amount": "123.45"}'
```

#### 2. Using HTTP Client (`NumberToWordsConverter.Api.http`)

The project includes an `.http` scratch file located at `NumberToWordsConverter.Api/NumberToWordsConverter.Api.http`. You can execute requests directly from JetBrains Rider or VS Code REST Client:

```http
POST http://localhost:5188/api/converter
Content-Type: application/json

{
  "amount": "123.45"
}
```

#### 3. OpenAPI Specification

When running in `Development` environment mode, OpenAPI specification is available at:
- `http://localhost:5188/openapi/v1.json`

---

## Running Unit Tests

To run the unit test suite:

```bash
dotnet test NumberToWordsConverter.Tests/NumberToWordsConverter.Tests.csproj
```

Or run all tests in the solution:

```bash
dotnet test NumberToWordsConverter.sln
```
