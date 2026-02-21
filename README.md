# Muonroi.Microservices.Template

A .NET solution template for building distributed Microservices applications using ASP.NET Core, YARP Gateway, and the Muonroi.BuildingBlock library. Ideal for large-scale systems requiring independent scalability and deployment.

## Quick Start

```bash
# 1. Install template
dotnet new install Muonroi.Microservices.Template

# 2. Create new project
dotnet new mr-micro-sln -n MyMicroservices

# 3. Setup
cd MyMicroservices/MyMicroservices
dotnet restore

# 4. Run Catalog service migrations
cd src/Services/MyMicroservices.Catalog
dotnet ef migrations add InitialCreate --project ../MyMicroservices.Data
dotnet ef database update --project ../MyMicroservices.Data

# 5. Run Catalog service
dotnet run

# 6. (Optional) Run Gateway
cd ../../Gateways/MyMicroservices.Gateway
dotnet run
```

Catalog Service: `https://localhost:5001/swagger`
Gateway: `http://localhost:5067` or `https://localhost:7225`

Call Catalog through Gateway (routes are prefixed):
`http://localhost:5067/api/v1/catalog/<endpoint>`

## Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) or later
- (Optional) [Docker Desktop](https://www.docker.com/products/docker-desktop) - for containerized deployment
- (Optional) [EF Core CLI](https://docs.microsoft.com/en-us/ef/core/cli/dotnet): `dotnet tool install --global dotnet-ef`

## Installation

### From NuGet (recommended)

```bash
dotnet new install Muonroi.Microservices.Template
```

### From source

```bash
git clone <your-private-url>/Muonroi.Microservices.Template.git
cd Muonroi.Microservices.Template
dotnet new install ./
```

### Verify installation

```bash
dotnet new list | grep "mr-micro-sln"
```

## Usage

### Create new project

```bash
dotnet new mr-micro-sln -n <ProjectName> [--ui <angular|react|mvc|none>]
```

| Parameter | Short | Description | Default |
|-----------|-------|-------------|---------|
| `--name` | `-n` | Solution/project name | (required) |
| `--UiFramework` | `--ui` | Frontend shell scaffold (`angular`, `react`, `mvc`, `none`) | `none` |

### Examples

```bash
# Create microservices solution
dotnet new mr-micro-sln -n ECommerceServices

# Creates: CatalogService, Gateway, docker-compose

# Create microservices solution with MVC shell starter
dotnet new mr-micro-sln -n ECommerceServices --ui mvc
```

## Project Structure

```
MyMicroservices/
├── MyMicroservices.sln
├── docker-compose.yml                      # Multi-service orchestration
├── docker-compose.override.yml
├── src/
│   ├── Gateways/                           # API Gateway Layer
│   │   └── MyMicroservices.Gateway/        # YARP Reverse Proxy
│   │       ├── appsettings.json
│   │       ├── Program.cs
│   │       └── yarp-config.json           # Route configuration
│   └── Services/                           # Microservices
│       ├── MyMicroservices.Catalog/        # Catalog Service
│       │   ├── appsettings.json
│       │   ├── appsettings.Development.json
│       │   ├── Controllers/
│       │   ├── Program.cs
│       │   └── Dockerfile
│       ├── MyMicroservices.Core/           # Shared domain
│       │   ├── Entities/
│       │   └── Interfaces/
│       └── MyMicroservices.Data/           # Data layer
│           ├── CatalogDbContext.cs
│           └── Repositories/
└── README.md
```

## Configuration

### Per-Service Configuration

Each microservice has its own appsettings:

```json
{
  "DatabaseConfigs": {
    "DbType": "Sqlite",
    "ConnectionStrings": {
      "SqliteConnectionString": "Data Source=catalog.db"
    }
  },
  "TokenConfigs": {
    "Issuer": "https://catalog-service:5001",
    "Audience": "https://catalog-service:5001",
    "SymmetricSecretKey": "your-secret-key-minimum-32-characters!",
    "UseRsa": false,
    "ExpiryMinutes": 60
  },
  "EnableEncryption": false
}
```

### Supported Database Types

| DbType | Connection String Key |
|--------|----------------------|
| `Sqlite` | `SqliteConnectionString` |
| `SqlServer` | `SqlServerConnectionString` |
| `MySql` | `MySqlConnectionString` |
| `PostgreSql` | `PostgreSqlConnectionString` |
| `MongoDb` | `MongoDbConnectionString` |

### Gateway Configuration (YARP)

Configure service routes in `src/Gateways/MyMicroservices.Gateway/appsettings.json`:

```json
{
  "ReverseProxy": {
    "Routes": {
      "catalog-route": {
        "ClusterId": "catalog-cluster",
        "Match": {
          "Path": "/api/v1/catalog/{**catch-all}"
        },
        "Transforms": [
          { "PathPattern": "{**catch-all}" }
        ]
      }
    },
    "Clusters": {
      "catalog-cluster": {
        "Destinations": {
          "destination1": {
            "Address": "http://localhost:5000"
          }
        }
      }
    }
  }
}
```

Notes:
- Gateway only receives traffic when you call it directly. Calling the Catalog service URL bypasses the gateway.
- The `PathPattern` transform removes `/api/v1/catalog` before forwarding to the service.
- Ensure the destination scheme/port matches the Catalog service (`http://localhost:5000` or `https://localhost:5001`).

### Feature Flags

Toggle features per service:

```json
{
  "FeatureFlags": {
    "UseGrpc": true,
    "UseServiceDiscovery": true,
    "UseMessageBus": true,
    "UseBackgroundJobs": false,
    "UseEnsureCreatedFallback": true
  }
}
```

### Enterprise Operations (E4/E5)

For each service that needs enterprise management endpoints:

```json
{
  "EnterpriseOps": {
    "EnableComplianceEndpoints": false,
    "EnableOperationsEndpoints": false
  }
}
```

When enabled in a service:
- `EnableComplianceEndpoints`: maps `MapMComplianceEndpoints()`
- `EnableOperationsEndpoints`: maps `MapMEnterpriseOperationsEndpoints()`

Ops scripts included in `scripts/`:
- `check-enterprise-upgrade-compat.ps1`
- `check-enterprise-slo-gates.ps1`

SLO presets included in `deploy/enterprise/slo-presets/`:
- `balanced.json`
- `strict.json`
- `regulated.json`

Note: if your `Muonroi.BuildingBlock` package version does not include E4/E5 endpoint extensions yet, these toggles are ignored safely.

## Database Migrations

Each service manages its own database:

```bash
# Catalog service migration
cd src/Services/MyMicroservices.Catalog
dotnet ef migrations add "InitialCreate" \
    -p ../MyMicroservices.Data \
    -o Persistence/Migrations

dotnet ef database update \
    -p ../MyMicroservices.Data
```

## Running Services

### Development Mode

Run each service individually:

```bash
# Terminal 1 - Catalog Service
cd src/Services/MyMicroservices.Catalog
dotnet run

# Terminal 2 - Gateway
cd src/Gateways/MyMicroservices.Gateway
dotnet run
```

### Docker Compose (recommended)

```bash
# Build and run all services
docker-compose up --build

# Run in background
docker-compose up -d

# Stop services
docker-compose down

# View logs
docker-compose logs -f catalog
```

Services will be available at:
- Gateway: `http://localhost:5067` (or `https://localhost:7225`)
- Catalog: `http://localhost:5000` (or `https://localhost:5001`)

## Microservices Architecture

### Why Microservices?

- **Independent Scalability** - Scale services based on demand
- **Technology Diversity** - Use different tech stacks per service
- **Fault Isolation** - Service failures don't affect others
- **Independent Deployment** - Deploy services independently

### Service Communication

Services communicate via:

1. **HTTP/REST** - Synchronous via API Gateway
2. **gRPC** - High-performance inter-service calls
3. **Message Bus** - Asynchronous events (Kafka/RabbitMQ)
4. **Service Discovery** - Dynamic service location (Consul)

### Adding New Service

1. Create service folder under `src/Services/`:
   ```bash
   src/Services/
   └── MyMicroservices.Orders/        # New service
       ├── Controllers/
       ├── Program.cs
       ├── Dockerfile
       └── appsettings.json
   ```

2. Add service to `docker-compose.yml`:
   ```yaml
   orders:
     build:
       context: .
       dockerfile: src/Services/MyMicroservices.Orders/Dockerfile
     ports:
       - "5002:80"
     environment:
       - ASPNETCORE_ENVIRONMENT=Development
   ```

3. Add route to Gateway `yarp-config.json`

4. Create separate database for the service

## Features

- **Microservices Architecture** - Independent, scalable services
- **YARP API Gateway** - Modern reverse proxy with dynamic routing
- **Docker Support** - Full containerization with docker-compose
- **Service-per-Database** - Each service owns its data
- **Authentication & Authorization** - JWT with distributed auth
- **Structured Logging** - Service-specific log files
- **Caching** - Redis for distributed caching
- **Multi-tenancy** - Tenant isolation per service
- **Service Discovery** - Consul integration
- **Message Bus** - Kafka/RabbitMQ via MassTransit
- **gRPC Communication** - High-performance inter-service calls
- **Health Checks** - Service health monitoring
- **Distributed Tracing** - OpenTelemetry support

## Best Practices

✅ **DO:**
- Design services around business capabilities
- Use API Gateway for external clients
- Implement circuit breakers for resilience
- Use message bus for async communication
- Monitor service health and metrics
- Use separate databases per service

❌ **DON'T:**
- Share databases between services
- Create chatty inter-service calls
- Make synchronous calls for non-critical operations
- Deploy all services together
- Skip health checks and monitoring

## Deployment

### Docker Deployment

```bash
# Build images
docker-compose build

# Push to registry
docker tag myservices-catalog:latest myregistry/catalog:1.0
docker push myregistry/catalog:1.0

# Deploy to production
docker-compose -f docker-compose.prod.yml up -d
```

### Kubernetes Deployment

See [k8s/README.md](k8s/README.md) for Kubernetes manifests.

## Documentation

Private docs are centralized in `Muonroi.Docs`:

- [License Capability Model](https://github.com/muonroi/Muonroi.Docs/blob/main/docs/enterprise/license-capability-model.md)
- [Control Plane MVP](https://github.com/muonroi/Muonroi.Docs/blob/main/docs/enterprise/control-plane-mvp.md)
- [Enterprise Secure Profile (E2)](https://github.com/muonroi/Muonroi.Docs/blob/main/docs/enterprise/enterprise-secure-profile-e2.md)
- [Enterprise Centralized Authorization (E3)](https://github.com/muonroi/Muonroi.Docs/blob/main/docs/enterprise/enterprise-centralized-authorization-e3.md)
- [Enterprise Compliance (E4)](https://github.com/muonroi/Muonroi.Docs/blob/main/docs/enterprise/enterprise-compliance-e4.md)
- [Enterprise Operations (E5)](https://github.com/muonroi/Muonroi.Docs/blob/main/docs/enterprise/enterprise-operations-e5.md)

## Troubleshooting

### "Connection string is not provided"

Ensure each service has correct `DbType` and connection string:

```json
{
  "DatabaseConfigs": {
    "DbType": "PostgreSql",
    "ConnectionStrings": {
      "PostgreSqlConnectionString": "..."
    }
  }
}
```

### "The input is not a valid Base-64 string"

Set `"EnableEncryption": false` in each service's appsettings.

### Gateway not routing

Check `src/Gateways/MyMicroservices.Gateway/appsettings.json` routes and ensure the destination URL matches the Catalog service. Also ensure you call the gateway URL (not the Catalog URL).

### Docker services not communicating

Ensure services use docker-compose network names:
```json
"Address": "http://catalog:80"  // Not localhost
```

### Migration errors

Always specify `-p` and startup project for each service separately.

## Edition Notes

- Template package is MIT.
- Generated services run in Free mode by default (`LicenseConfigs:LicenseFilePath = null`).
- If you turn on premium integrations (gRPC, message bus, distributed cache, enterprise audit/security flows), provide a paid Muonroi license with matching feature keys.

## License

MIT License. See [LICENSE.txt](LICENSE.txt) for details.
