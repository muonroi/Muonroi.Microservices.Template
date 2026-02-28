# Rule Engine Quick Start (Microservices Template)

## 1. Enable rule store

Configure `RuleStore` in service `appsettings`:

```json
{
  "RuleStore": {
    "RootPath": "rules",
    "UseContentRoot": true
  }
}
```

## 2. Register rule services

In `Program.cs` of `src/Services/<Name>.Catalog`:

```csharp
builder.Services.AddRuleEngineStore(builder.Configuration);
builder.Services.AddRuleEngine<ContainerContext>(o => o.ExecutionMode = RuleExecutionMode.Rules)
    .AddRule<ContainerValidationRule>()
    .AddRule<ContainerExistenceRule>()
    .AddHook<LoggingHook<ContainerContext>>();
```

## 3. Existing examples in this template

- `src/Services/Muonroi.Microservices.Catalog/Rules/B2B/B2BRegistrationRules.cs`
- `src/Services/Muonroi.Microservices.Catalog/Rules/ContainerValidationRule.cs`
- `src/Services/Muonroi.Microservices.Catalog/Rules/ContainerExistenceRule.cs`
- `src/Services/Muonroi.Microservices.Catalog/Rules/LoggingHook.cs`

## 4. API endpoint example

Use `RuleMode` to switch execution path:

```csharp
[RuleMode(RuleExecutionMode.Rules)]
[HttpPost("validate")]
public async Task<IActionResult> Validate([FromBody] ContainerRequest req) { ... }
```

## 5. Generate rules from code-first methods

```bash
muonroi-rule extract --source ./Services/OrderService.cs --output ./Rules/Generated --namespace MyApp.Rules
muonroi-rule verify --source ./Services/OrderService.cs --rules ./Rules/Generated
muonroi-rule register --rules ./Rules/Generated --output ./Rules/Generated/RuleRegistration.g.cs
```

## 6. Learn more

- https://github.com/muonroi/Muonroi.Docs/blob/main/docs/rule-engine-guide.md
- https://github.com/muonroi/Muonroi.Docs/blob/main/docs/rule-engine-testing-guide.md
