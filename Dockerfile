# Etapa de compilación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar archivos y restaurar
COPY . .
RUN dotnet restore

# Publicar la aplicación
RUN dotnet publish -c Release -o /app/publish

# Etapa final (ejecución)
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

# ¡OJO! Cambia "NanoGuardian.Api.dll" por el nombre real de tu proyecto si es distinto
ENTRYPOINT ["dotnet", "NanoGuardian.Api.dll"]
