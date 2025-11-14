# --- Стадия сборки (build) ---
FROM mcr.microsoft.com/dotnet/sdk:9.0-alpine AS build
WORKDIR /src

# Сначала просто скопируем ВСЕ файлы для диагностики
COPY . .

# Покажем что есть в директории
RUN ls -la

# Попробуем найти csproj файлы
RUN find . -name "*.csproj" -type f

# Если нашли файл, укажем его явно
# RUN dotnet restore YourProjectName.csproj

# Временно пропустим restore и попробуем publish
RUN dotnet publish -c Release -o /app/publish

# --- Стадия выполнения (runtime) ---
FROM mcr.microsoft.com/dotnet/aspnet:9.0-alpine
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "myapp.dll"]
