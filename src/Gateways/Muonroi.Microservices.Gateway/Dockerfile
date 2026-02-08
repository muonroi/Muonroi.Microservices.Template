FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Gateways/Muonroi.Microservices.Gateway/Muonroi.Microservices.Gateway.csproj", "src/Gateways/Muonroi.Microservices.Gateway/"]
RUN dotnet restore "./src/Gateways/Muonroi.Microservices.Gateway/Muonroi.Microservices.Gateway.csproj"
COPY . .
WORKDIR "/src/src/Gateways/Muonroi.Microservices.Gateway"
RUN dotnet build "./Muonroi.Microservices.Gateway.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Muonroi.Microservices.Gateway.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Muonroi.Microservices.Gateway.dll"]
