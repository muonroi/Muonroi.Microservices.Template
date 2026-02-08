FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/Muonroi.Microservices.Catalog/Muonroi.Microservices.Catalog.csproj", "src/Services/Muonroi.Microservices.Catalog/"]
COPY ["src/Services/Muonroi.Microservices.Core/Muonroi.Microservices.Core.csproj", "src/Services/Muonroi.Microservices.Core/"]
COPY ["src/Services/Muonroi.Microservices.Data/Muonroi.Microservices.Data.csproj", "src/Services/Muonroi.Microservices.Data/"]
RUN dotnet restore "./src/Services/Muonroi.Microservices.Catalog/Muonroi.Microservices.Catalog.csproj"
COPY . .
WORKDIR "/src/src/Services/Muonroi.Microservices.Catalog"
RUN dotnet build "./Muonroi.Microservices.Catalog.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Muonroi.Microservices.Catalog.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Muonroi.Microservices.Catalog.dll"]
