Write-Host "Starting Microservices Gateway and Catalog Service..." -ForegroundColor Cyan
# Run Gateway
Start-Process dotnet "run --project src/Gateways/Muonroi.Microservices.Gateway/Muonroi.Microservices.Gateway.csproj"
# Run Catalog
Start-Process dotnet "run --project src/Services/Muonroi.Microservices.Catalog/Muonroi.Microservices.Catalog.csproj"
Write-Host "Services are starting in background. Check console windows or logs." -ForegroundColor Green
