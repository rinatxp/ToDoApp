FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /DTO
COPY "DTO/DTO.csproj" .
RUN dotnet restore
COPY "DTO" .
RUN dotnet publish -c release -o /app

WORKDIR /src
COPY frontend/frontend.csproj .
RUN dotnet restore
COPY frontend .
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .
ENV BackendUrl="http://backend:5001/"

ENTRYPOINT ["dotnet", "frontend.dll", "--urls", "http://*:5000"]
