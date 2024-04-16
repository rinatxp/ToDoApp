FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /DTO
COPY "DTO/DTO.csproj" .
RUN dotnet restore
COPY "DTO" .
RUN dotnet publish -c release -o /app

WORKDIR /src
COPY backend/backend.csproj .
RUN dotnet restore
COPY backend .
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "backend.dll", "--urls", "http://*:5001"]
